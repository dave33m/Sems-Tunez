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

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
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

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
            throw new InvalidOperationException("Invalid credentials");

        var isValidPassword = _passwordHasher.Verify(
            request.Password,
            user.PasswordHash
        );

        if (!isValidPassword)
            throw new InvalidOperationException("Invalid credentials");

        var token = _jwtTokenService.GenerateToken(user);

        return new LoginResponse(
            user.Id,
            token,
            "Login successful"
        );
    }
}
