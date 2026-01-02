using SemsTunez.Application.DTOs.User;
using SemsTunez.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllAsync();
        Task<UserResponse> UpdateAsync(Guid userId, UpdateUserRequest request);
        Task DeleteAsync(Guid userId);
    }
}
