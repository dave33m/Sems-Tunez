namespace SemsTunez.Application.DTOs.Tracks;

public record TrackResponse(
    Guid Id,
    Guid ArtistId,
    Guid AlbumId,
    string Title,
    int DurationSeconds,
    string StorageKey,
    int? TrackNumber,
    bool IsExplicit,
    bool IsPublished,
    DateTime CreatedAt
);

