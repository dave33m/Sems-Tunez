using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemsTunez.Application.DTOs.Auth;


namespace SemsTunez.Application.Interfaces.Auth;

public interface IAuthService
{
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    Task<OtpInitiatedResponse> LoginAsync(LoginRequest request);
    Task<LoginResponse> VerifyOtpAsync(VerifyOtpRequest request);
    Task<OtpInitiatedResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
    Task<OtpInitiatedResponse> ResetPasswordAsync(ResetPasswordRequest request);
    Task<OtpInitiatedResponse> ChangePasswordAsync(Guid userId,ChangePasswordRequest request);


}

