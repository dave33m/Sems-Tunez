namespace SemsTunez.Application.DTOs.Tracks;

public record UpdateTrackRequest(
    string Title,
    int DurationSeconds,
    int? TrackNumber,
    bool IsExplicit
);
