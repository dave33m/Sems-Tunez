using SemsTunez.Domain.Common;

namespace SemsTunez.Domain.Entities;

public class Album : BaseEntity
{
    public Guid ArtistId { get; private set; }
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public string? CoverImageUrl { get; private set; }
    public DateOnly? ReleaseDate { get; private set; }
    public bool IsPublished { get; private set; }

    private Album() { }

    public Album(
        Guid artistId,
        string title,
        string? description = null,
        string? coverImageUrl = null,
        DateOnly? releaseDate = null)
    {
        ArtistId = artistId;
        Title = title;
        Description = description;
        CoverImageUrl = coverImageUrl;
        ReleaseDate = releaseDate;
        IsPublished = false;
    }

    public void UpdateDetails(
        string title,
        string? description,
        string? coverImageUrl,
        DateOnly? releaseDate)
    {
        Title = title;
        Description = description;
        CoverImageUrl = coverImageUrl;
        ReleaseDate = releaseDate;
    }

    public void Publish()
    {
        IsPublished = true;
    }
}
