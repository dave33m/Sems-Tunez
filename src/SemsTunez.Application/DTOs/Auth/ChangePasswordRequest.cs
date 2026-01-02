using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Auth
{
    public record ChangePasswordRequest(
     string CurrentPassword,
     string NewPassword
 );
}
