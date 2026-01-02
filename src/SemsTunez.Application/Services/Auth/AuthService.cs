using SemsTunez.Application.DTOs.Auth;
using SemsTunez.Application.Interfaces.Auth;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Application.Interfaces.Security;
using SemsTunez.Domain.Entities;
using SemsTunez.Domain.Enums;

namespace SemsTunez.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IOtpService _otpService;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService,
        IOtpService otpService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
        _otpService = otpService;
    }

    
    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            throw new InvalidOperationException("User already exists");

        var passwordHash = _passwordHasher.Hash(request.Password);

        var user = new User(
            request.Email,
            passwordHash,
            request.DisplayName,
            UserRole.User
        );

        await _userRepository.AddAsync(user);

        return new RegisterResponse(
            user.Id,
            "Welcome to SemsTunez! Your account has been created."
        );
    }


    public async Task<OtpInitiatedResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
            throw new InvalidOperationException("Invalid credentials");

        var validPassword = _passwordHasher.Verify(
            request.Password,
            user.PasswordHash
        );

        if (!validPassword)
            throw new InvalidOperationException("Invalid credentials");

      
        await _otpService.GenerateOtpAsync(
            request.Email,
            OtpPurpose.Login
        );

        return new OtpInitiatedResponse(
            "An OTP has been sent to your email to complete login."
        );
    }

    public async Task<LoginResponse> VerifyOtpAsync(VerifyOtpRequest request)
    {
        var user = await _otpService.ValidateOtpAsync(
            request.Email,
            request.Purpose,
            request.Otp
        );

        var token = _jwtTokenService.GenerateToken(user);

        return new LoginResponse(
            user.Id,
            token,
            "Login successful"
        );
    }
    public async Task<OtpInitiatedResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user != null)
        {
            await _otpService.GenerateOtpAsync(
                request.Email,
                OtpPurpose.PasswordReset
            );
        }

        return new OtpInitiatedResponse(
            "If an account exists, a password reset OTP has been sent to your email."
        );
    }
    public async Task<OtpInitiatedResponse> ResetPasswordAsync(ResetPasswordRequest request)
    {

        var user = await _otpService.ValidateOtpAsync(
            request.Email,
            OtpPurpose.PasswordReset,
            request.Otp
        );

        var newPasswordHash = _passwordHasher.Hash(request.NewPassword);

        // Update user password
        user.UpdatePassword(newPasswordHash);

        await _userRepository.UpdateAsync(user);


        return new OtpInitiatedResponse(
            "Password reset successful. You can now log in."
        );
    }
    public async Task<OtpInitiatedResponse> ChangePasswordAsync(Guid userId,ChangePasswordRequest request)
    {
        var user = await _userRepository.GetByIdAsync(userId)
            ?? throw new InvalidOperationException("User not found");

        // Verify current password
        var valid = _passwordHasher.Verify(
            request.CurrentPassword,
            user.PasswordHash
        );

        if (!valid)
            throw new InvalidOperationException("Current password is incorrect");

        // Update password
        var newPasswordHash = _passwordHasher.Hash(request.NewPassword);
        user.UpdatePassword(newPasswordHash);

        await _userRepository.UpdateAsync(user);

        return new OtpInitiatedResponse(
            "Password changed successfully."
        );
    }

}


