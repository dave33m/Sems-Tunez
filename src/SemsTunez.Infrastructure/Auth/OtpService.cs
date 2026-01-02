using SemsTunez.Application.Interfaces.Auth;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Application.Interfaces.Security;
using SemsTunez.Domain.Entities;
using SemsTunez.Domain.Enums;
using SemsTunez.Application.Interfaces.Email;

namespace SemsTunez.Infrastructure.Auth;

public class OtpService : IOtpService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserOtpRepository _otpRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEmailSender _emailSender;

    private const int OTP_EXPIRY_MINUTES = 5;

    public OtpService(
      IUserRepository userRepository,
      IUserOtpRepository otpRepository,
      IPasswordHasher passwordHasher,
      IEmailSender emailSender)
    {
        _userRepository = userRepository;
        _otpRepository = otpRepository;
        _passwordHasher = passwordHasher;
        _emailSender = emailSender;
    }
    public async Task GenerateOtpAsync(string email, OtpPurpose purpose)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
            throw new InvalidOperationException("User not found");

        var otp = Random.Shared.Next(100000, 999999).ToString();
        var otpHash = _passwordHasher.Hash(otp);

        var entity = new UserOtp(
            email,
            purpose,
            otpHash,
            DateTime.UtcNow.AddMinutes(OTP_EXPIRY_MINUTES)
        );

        await _otpRepository.AddAsync(entity);
        await _otpRepository.SaveChangesAsync();
        await _emailSender.SendOtpAsync(email, otp, purpose);

    }

    public async Task<User> ValidateOtpAsync(string email, OtpPurpose purpose, string otp)
    {
        var user = await _userRepository.GetByEmailAsync(email)
            ?? throw new InvalidOperationException("User not found");

        var record = await _otpRepository.GetLatestValidAsync(email, purpose);
        if (record == null)
            throw new InvalidOperationException("Invalid or expired OTP");

        if (!_passwordHasher.Verify(otp, record.CodeHash))
            throw new InvalidOperationException("Invalid or expired OTP");

        record.MarkUsed();
        await _otpRepository.SaveChangesAsync();

        return user;
    }
}
