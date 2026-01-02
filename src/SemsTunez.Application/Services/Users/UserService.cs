using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Services.Users
{
    using SemsTunez.Application.DTOs.User;
    using SemsTunez.Application.DTOs.Users;
    using SemsTunez.Application.Interfaces.Repositories;
    using SemsTunez.Application.Interfaces.Users;
    using SemsTunez.Domain.Enums;

    public class UserService : IUserService
    {
        private readonly IUserRepository _users;

        public UserService(IUserRepository users)
        {
            _users = users;
        }

        public async Task<List<UserResponse>> GetAllAsync()
        {
            var users = await _users.GetAllAsync();
            return users.Select(u => new UserResponse(
                u.Id, u.Email, u.DisplayName, u.Role.ToString(), u.CreatedAt
            )).ToList();
        }

        public async Task<UserResponse> UpdateAsync(Guid userId, UpdateUserRequest request)
        {
            var user = await _users.GetByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found");

            if (!string.IsNullOrWhiteSpace(request.DisplayName))
                user.UpdateDisplayName(request.DisplayName);

            if (!string.IsNullOrWhiteSpace(request.Role) &&
                Enum.TryParse<UserRole>(request.Role, true, out var role))
            {
                user.UpdateRole(role);
            }

            await _users.UpdateAsync(user);

            return new UserResponse(
                user.Id, user.Email, user.DisplayName, user.Role.ToString(), user.CreatedAt
            );
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = await _users.GetByIdAsync(userId)
                ?? throw new InvalidOperationException("User not found");

            await _users.DeleteAsync(user);
        }
    }

}
