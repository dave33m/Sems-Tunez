using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.User
{
    public record UserResponse(
      Guid Id,
      string Email,
      string DisplayName,
      string Role,
      DateTime CreatedAt
  );
}
