using SemsTunez.Domain.Entities;

namespace SemsTunez.Application.Interfaces.Repositories;

public interface IAlbumRepository
{
    Task<Album?> GetByIdAsync(Guid id);
    Task<List<Album>> GetAllAsync();
    Task AddAsync(Album album);
    Task UpdateAsync(Album album);
    Task DeleteAsync(Album album);
}
