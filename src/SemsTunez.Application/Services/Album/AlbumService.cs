using SemsTunez.Application.DTOs.Albums;
using SemsTunez.Application.Interfaces.Albums;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Domain.Entities;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albums;
    private readonly IArtistRepository _artists;

    public AlbumService(IAlbumRepository albums, IArtistRepository artists)
    {
        _albums = albums;
        _artists = artists;
    }

    public async Task<List<AlbumResponse>> GetAllAsync()
        => (await _albums.GetAllAsync()).Select(Map).ToList();

    public async Task<AlbumResponse> GetByIdAsync(Guid id)
        => Map(await _albums.GetByIdAsync(id) ?? throw new InvalidOperationException("Album not found"));

    public async Task<AlbumResponse> CreateAsync(CreateAlbumRequest request)
    {
        // ensure artist exists
        _ = await _artists.GetByIdAsync(request.ArtistId)
            ?? throw new InvalidOperationException("Artist not found");

        var album = new Album(
            request.ArtistId,
            request.Title,
            request.Description,
            request.CoverImageUrl,
            request.ReleaseDate
        );

        await _albums.AddAsync(album);
        return Map(album);
    }

    public async Task<AlbumResponse> UpdateAsync(Guid id, UpdateAlbumRequest request)
    {
        var album = await _albums.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Album not found");

        album.UpdateDetails(
            request.Title,
            request.Description,
            request.CoverImageUrl,
            request.ReleaseDate
        );

        await _albums.UpdateAsync(album);
        return Map(album);
    }

    public async Task PublishAsync(Guid id)
    {
        var album = await _albums.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Album not found");

        album.Publish();
        await _albums.UpdateAsync(album);
    }

    public async Task DeleteAsync(Guid id)
    {
        var album = await _albums.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Album not found");

        await _albums.DeleteAsync(album);
    }

    private static AlbumResponse Map(Album a)
        => new(
            a.Id,
            a.ArtistId,
            a.Title,
            a.Description,
            a.CoverImageUrl,
            a.ReleaseDate,
            a.IsPublished,
            a.CreatedAt
        );
}
