using SemsTunez.Application.DTOs.Artist;

public interface IArtistService
{
    Task<List<ArtistResponse>> GetAllAsync();
    Task<ArtistResponse> GetByIdAsync(Guid id);
    Task<ArtistResponse> CreateAsync(CreateArtistRequest request);
    Task<ArtistResponse> UpdateAsync(Guid id, UpdateArtistRequest request);
    Task DeleteAsync(Guid id);
    Task VerifyAsync(Guid id);
}
