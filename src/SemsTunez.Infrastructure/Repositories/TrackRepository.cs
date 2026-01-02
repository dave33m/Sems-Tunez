using Microsoft.EntityFrameworkCore;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Domain.Entities;
using SemsTunez.Infrastructure.Persistence;

public class TrackRepository : ITrackRepository
{
    private readonly SemsTunezDbContext _db;

    public TrackRepository(SemsTunezDbContext db)
    {
        _db = db;
    }

    public async Task<Track?> GetByIdAsync(Guid id)
        => await _db.Tracks.FindAsync(id);

    public async Task<List<Track>> GetAllAsync()
        => await _db.Tracks.AsNoTracking().ToListAsync();

    public async Task AddAsync(Track track)
    {
        _db.Tracks.Add(track);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Track track)
    {
        _db.Tracks.Update(track);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Track track)
    {
        _db.Tracks.Remove(track);
        await _db.SaveChangesAsync();
    }
}
