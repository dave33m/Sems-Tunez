using SemsTunez.Application.DTOs.Public.Albums;
using SemsTunez.Application.Interfaces.Public;
using SemsTunez.Application.Interfaces.Repositories;

namespace SemsTunez.Application.Services.Public;

public class AlbumQueryService : IAlbumQueryService
{
    private readonly IAlbumRepository _albums;

    public AlbumQueryService(IAlbumRepository albums)
    {
        _albums = albums;
    }

    public async Task<List<AlbumResponse>> GetAllAsync()
        => (await _albums.GetAllAsync())
            .Where(a => a.IsPublished)
            .Select(Map)
            .ToList();

    public async Task<List<AlbumResponse>> GetByArtistAsync(Guid artistId)
        => (await _albums.GetAllAsync())
            .Where(a => a.IsPublished && a.ArtistId == artistId)
            .Select(Map)
            .ToList();

    public async Task<AlbumResponse> GetByIdAsync(Guid id)
    {
        var album = await _albums.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Album not found");

        if (!album.IsPublished)
            throw new InvalidOperationException("Album not published");

        return Map(album);
    }

    private static AlbumResponse Map(SemsTunez.Domain.Entities.Album a)
        => new(
            a.Id,
            a.ArtistId,
            a.Title,
            a.Description,
            a.CoverImageUrl,
            a.ReleaseDate
        );
}
