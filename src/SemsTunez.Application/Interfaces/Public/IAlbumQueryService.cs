using SemsTunez.Application.DTOs.Public.Albums;

namespace SemsTunez.Application.Interfaces.Public;

public interface IAlbumQueryService
{
    Task<List<AlbumResponse>> GetAllAsync();
    Task<List<AlbumResponse>> GetByArtistAsync(Guid artistId);
    Task<AlbumResponse> GetByIdAsync(Guid id);
}
