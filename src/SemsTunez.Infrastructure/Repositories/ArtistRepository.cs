using Microsoft.EntityFrameworkCore;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Domain.Entities;
using SemsTunez.Infrastructure.Persistence;

public class ArtistRepository : IArtistRepository
{
    private readonly SemsTunezDbContext _db;

    public ArtistRepository(SemsTunezDbContext db)
    {
        _db = db;
    }

    public async Task<Artist?> GetByIdAsync(Guid id)
        => await _db.Artists.FindAsync(id);

    public async Task<List<Artist>> GetAllAsync()
        => await _db.Artists.AsNoTracking().ToListAsync();

    public async Task AddAsync(Artist artist)
    {
        _db.Artists.Add(artist);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Artist artist)
    {
        _db.Artists.Update(artist);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Artist artist)
    {
        _db.Artists.Remove(artist);
        await _db.SaveChangesAsync();
    }
}
