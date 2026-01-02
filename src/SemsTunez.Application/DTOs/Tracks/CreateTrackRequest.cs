namespace SemsTunez.Application.DTOs.Tracks;

public record CreateTrackRequest(
    Guid ArtistId,
    Guid AlbumId,
    string Title,
    int DurationSeconds,
    string StorageKey,
    int? TrackNumber,
    bool IsExplicit
);

