using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Domain.Entities;
using SemsTunez.Domain.Enums;
using SemsTunez.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SemsTunez.Infrastructure.Repositories
{
    public class UserOtpRepository : IUserOtpRepository
    {
        private readonly SemsTunezDbContext _context;

        public UserOtpRepository(SemsTunezDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserOtp otp)
        {
            await _context.UserOtps.AddAsync(otp);
        }

        public async Task<UserOtp?> GetLatestValidAsync(string email, OtpPurpose purpose)
        {
            return await _context.UserOtps
                .Where(o =>
                    o.Email == email &&
                    o.Purpose == purpose &&
                    !o.IsUsed &&
                    o.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
