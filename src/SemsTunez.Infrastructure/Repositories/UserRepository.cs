using Microsoft.EntityFrameworkCore;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Domain.Entities;
using SemsTunez.Infrastructure.Persistence;

namespace SemsTunez.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SemsTunezDbContext _context;

    public UserRepository(SemsTunezDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
