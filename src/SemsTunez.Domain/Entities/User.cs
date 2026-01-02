using SemsTunez.Domain.Common;
using SemsTunez.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string DisplayName { get; private set; }
        public UserRole Role { get; private set; }

        private User() { }

        public User(string email, string passwordHash, string displayName, UserRole role)
        {
            Email = email;
            PasswordHash = passwordHash;
            DisplayName = displayName;
            Role = role;
        }
        public void UpdatePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }
        public void UpdateDisplayName(string displayName)
        {
            DisplayName = displayName;
        }

        public void UpdateRole(UserRole role)
        {
            Role = role;
        }

    }

}

