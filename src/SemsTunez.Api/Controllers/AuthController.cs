using Microsoft.AspNetCore.Mvc;
using SemsTunez.Application.DTOs.Auth;
using SemsTunez.Application.Interfaces.Auth;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SemsTunez.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        return Ok(await _authService.RegisterAsync(request));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        return Ok(await _authService.LoginAsync(request));
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp(VerifyOtpRequest request)
    {
        return Ok(await _authService.VerifyOtpAsync(request));
    }
    
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
    {
        return Ok(await _authService.ForgotPasswordAsync(request));
    }
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
    {
        return Ok(await _authService.ResetPasswordAsync(request));
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        return Ok(await _authService.ChangePasswordAsync(userId, request));
    }

}
