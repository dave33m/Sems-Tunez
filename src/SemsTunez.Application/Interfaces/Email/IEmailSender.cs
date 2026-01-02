using SemsTunez.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Interfaces.Email
{
    public interface IEmailSender
    {
        Task SendOtpAsync(string email, string otp, OtpPurpose purpose);
    }
}
