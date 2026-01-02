using SemsTunez.Application.DTOs.Tracks;
using SemsTunez.Application.Interfaces.Repositories;
using SemsTunez.Application.Interfaces.Tracks;
using SemsTunez.Domain.Entities;

namespace SemsTunez.Application.Services.Tracks;

public class TrackService : ITrackService
{
    private readonly ITrackRepository _tracks;
    private readonly IAlbumRepository _albums;

    public TrackService(ITrackRepository tracks, IAlbumRepository albums)
    {
        _tracks = tracks;
        _albums = albums;
    }

    public async Task<List<TrackResponse>> GetAllAsync()
    {
        var tracks = await _tracks.GetAllAsync();
        return tracks.Select(Map).ToList();
    }

    public async Task<TrackResponse> GetByIdAsync(Guid id)
    {
        var track = await _tracks.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Track not found");

        return Map(track);
    }

    public async Task<TrackResponse> CreateAsync(CreateTrackRequest request)
    {
        _ = await _albums.GetByIdAsync(request.AlbumId)
            ?? throw new InvalidOperationException("Album not found");

        var track = new Track(
              request.ArtistId,
              request.AlbumId,
              request.Title,
              request.DurationSeconds,
              request.StorageKey,
              request.TrackNumber,
              request.IsExplicit
          );


        await _tracks.AddAsync(track);
        return Map(track);
    }

    public async Task<TrackResponse> UpdateAsync(Guid id, UpdateTrackRequest request)
    {
        var track = await _tracks.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Track not found");

        track.UpdateDetails(
            request.Title,
            request.DurationSeconds,
            request.TrackNumber,
            request.IsExplicit
        );

        await _tracks.UpdateAsync(track);
        return Map(track);
    }

    public async Task PublishAsync(Guid id)
    {
        var track = await _tracks.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Track not found");

        track.Publish();
        await _tracks.UpdateAsync(track);
    }

    public async Task DeleteAsync(Guid id)
    {
        var track = await _tracks.GetByIdAsync(id)
            ?? throw new InvalidOperationException("Track not found");

        await _tracks.DeleteAsync(track);
    }

    private static TrackResponse Map(Track t)
     => new(
         t.Id,
         t.ArtistId,
         t.AlbumId,
         t.Title,
         t.DurationSeconds,
         t.StorageKey,
         t.TrackNumber,
         t.IsExplicit,
         t.IsPublished,
         t.CreatedAt
     );
}
