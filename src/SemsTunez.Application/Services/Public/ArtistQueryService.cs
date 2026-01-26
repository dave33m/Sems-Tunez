using SemsTunez.Application.DTOs.Public.Artists;
using SemsTunez.Application.Interfaces.Public;
using SemsTunez.Application.Interfaces.Repositories;

namespace SemsTunez.Application.Services.Public;

public class ArtistQueryService : IArtistQueryService
{
    private readonly IArtistRepository _artists;

    public ArtistQueryService(IArtistRepository artists)
    {
        _artists = artists;
    }

    public async Task<List<ArtistResponse>> GetAllAsync()
        => (await _artists.GetAllAsync())
            .Select(a => new ArtistResponse(a.Id, a.Name, a.Bio, a.ImageUrl))
            .ToList();

    public async Task<ArtistResponse> GetByIdAsync(Guid id)
    {
        var artist = await _artists.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Artist not found");

        return new ArtistResponse(artist.Id, artist.Name, artist.Bio, artist.ImageUrl);
    }
}
