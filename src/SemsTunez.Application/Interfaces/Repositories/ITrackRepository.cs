using SemsTunez.Domain.Entities;

namespace SemsTunez.Application.Interfaces.Repositories;

public interface ITrackRepository
{
    Task<Track?> GetByIdAsync(Guid id);
    Task<List<Track>> GetAllAsync();
    Task AddAsync(Track track);
    Task UpdateAsync(Track track);
    Task DeleteAsync(Track track);
}
