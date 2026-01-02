using SemsTunez.Domain.Entities;
using SemsTunez.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Interfaces.Repositories;


public interface IUserOtpRepository
{
    Task AddAsync(UserOtp otp);
    Task<UserOtp?> GetLatestValidAsync(string email, OtpPurpose purpose);
    Task SaveChangesAsync();
    Task UpdateAsync(User user);

}
