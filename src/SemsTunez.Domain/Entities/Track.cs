using SemsTunez.Domain.Common;

namespace SemsTunez.Domain.Entities;

public class Track : BaseEntity
{
    public Guid ArtistId { get; private set; }
    public Guid AlbumId { get; private set; }

    public string Title { get; private set; } = null!;
    public int DurationSeconds { get; private set; }

    // Storage-level reference (S3 key, blob key, etc.)
    public string StorageKey { get; private set; } = null!;

    public int? TrackNumber { get; private set; }
    public bool IsExplicit { get; private set; }
    public bool IsPublished { get; private set; }

    private Track() { }

    public Track(
        Guid artistId,
        Guid albumId,
        string title,
        int durationSeconds,
        string storageKey,
        int? trackNumber,
        bool isExplicit)
    {
        ArtistId = artistId;
        AlbumId = albumId;
        Title = title;
        DurationSeconds = durationSeconds;
        StorageKey = storageKey;
        TrackNumber = trackNumber;
        IsExplicit = isExplicit;
        IsPublished = false;
    }

    public void UpdateDetails(
        string title,
        int durationSeconds,
        int? trackNumber,
        bool isExplicit)
    {
        Title = title;
        DurationSeconds = durationSeconds;
        TrackNumber = trackNumber;
        IsExplicit = isExplicit;
    }

    public void Publish()
    {
        IsPublished = true;
    }
}
