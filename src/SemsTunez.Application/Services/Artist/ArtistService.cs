using SemsTunez.Application.DTOs.Artist;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Domain.Entities;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artists;

    public ArtistService(IArtistRepository artists)
    {
        _artists = artists;
    }

    public async Task<List<ArtistResponse>> GetAllAsync()
    {
        var list = await _artists.GetAllAsync();
        return list.Select(Map).ToList();
    }

    public async Task<ArtistResponse> GetByIdAsync(Guid id)
    {
        var artist = await _artists.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Artist not found");

        return Map(artist);
    }

    public async Task<ArtistResponse> CreateAsync(CreateArtistRequest request)
    {
        var artist = new Artist(request.Name, request.Bio, request.ImageUrl);
        await _artists.AddAsync(artist);
        return Map(artist);
    }

    public async Task<ArtistResponse> UpdateAsync(Guid id, UpdateArtistRequest request)
    {
        var artist = await _artists.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Artist not found");

        artist.UpdateProfile(request.Name, request.Bio, request.ImageUrl);
        await _artists.UpdateAsync(artist);

        return Map(artist);
    }

    public async Task VerifyAsync(Guid id)
    {
        var artist = await _artists.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Artist not found");

        artist.Verify();
        await _artists.UpdateAsync(artist);
    }

    public async Task DeleteAsync(Guid id)
    {
        var artist = await _artists.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Artist not found");

        await _artists.DeleteAsync(artist);
    }

    private static ArtistResponse Map(Artist a)
        => new(
            a.Id,
            a.Name,
            a.Bio,
            a.ImageUrl,
            a.IsVerified,
            a.CreatedAt
        );
}
