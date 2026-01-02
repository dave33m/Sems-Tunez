using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using SemsTunez.Application.Interfaces.Email;
using SemsTunez.Domain.Enums;

namespace SemsTunez.Infrastructure.Email;

public class SendGridEmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public SendGridEmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendOtpAsync(string email, string otp, OtpPurpose purpose)
    {
        var apiKey = _configuration["SendGrid:ApiKey"];
        var fromEmail = _configuration["SendGrid:FromEmail"];
        var fromName = _configuration["SendGrid:FromName"];

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("SendGrid API key not configured");

        var client = new SendGridClient(apiKey);

        var subject = purpose switch
        {
            OtpPurpose.Login => "Your SemsTunez Login Code",
            OtpPurpose.EmailVerification => "Verify your SemsTunez email",
            OtpPurpose.PasswordReset => "Reset your SemsTunez password",
            _ => "Your SemsTunez OTP Code"
        };

        var body = $"""
        Your one-time code is: {otp}

        This code expires in 5 minutes.

        If you did not request this, please ignore this email.
        """;

        var message = new SendGridMessage
        {
            From = new EmailAddress(fromEmail!, fromName),
            Subject = subject,
            PlainTextContent = body
        };

        message.AddTo(new EmailAddress(email));

        await client.SendEmailAsync(message);
    }
}
