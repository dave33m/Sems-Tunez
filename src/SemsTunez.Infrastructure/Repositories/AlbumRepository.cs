using Microsoft.EntityFrameworkCore;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Domain.Entities;
using SemsTunez.Infrastructure.Persistence;

public class AlbumRepository : IAlbumRepository
{
    private readonly SemsTunezDbContext _db;

    public AlbumRepository(SemsTunezDbContext db)
    {
        _db = db;
    }

    public async Task<Album?> GetByIdAsync(Guid id)
        => await _db.Albums.FindAsync(id);

    public async Task<List<Album>> GetAllAsync()
        => await _db.Albums.AsNoTracking().ToListAsync();

    public async Task AddAsync(Album album)
    {
        _db.Albums.Add(album);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Album album)
    {
        _db.Albums.Update(album);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Album album)
    {
        _db.Albums.Remove(album);
        await _db.SaveChangesAsync();
    }
}
