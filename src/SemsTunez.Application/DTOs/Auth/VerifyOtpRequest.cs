using SemsTunez.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Auth
{
    public record VerifyOtpRequest(
    string Email,
    OtpPurpose Purpose,
    string Otp
);
}
