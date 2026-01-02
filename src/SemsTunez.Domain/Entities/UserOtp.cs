using SemsTunez.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Domain.Entities
{
    public class UserOtp
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public OtpPurpose Purpose { get; private set; }
        public string CodeHash { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool IsUsed { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private UserOtp() { } // EF Core

        public UserOtp(
            string email,
            OtpPurpose purpose,
            string codeHash,
            DateTime expiresAt)
        {
            Id = Guid.NewGuid();
            Email = email;
            Purpose = purpose;
            CodeHash = codeHash;
            ExpiresAt = expiresAt;
            CreatedAt = DateTime.UtcNow;
            IsUsed = false;
        }

        public bool IsExpired()
            => DateTime.UtcNow > ExpiresAt;

        public void MarkUsed()
            => IsUsed = true;
    }
}
