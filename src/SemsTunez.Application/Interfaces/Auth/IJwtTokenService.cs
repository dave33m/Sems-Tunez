using SemsTunez.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Interfaces.Auth
{

    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
