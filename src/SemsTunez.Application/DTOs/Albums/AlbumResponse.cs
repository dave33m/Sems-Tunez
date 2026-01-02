using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Albums
{
    public record AlbumResponse(
    Guid Id,
    Guid ArtistId,
    string Title,
    string? Description,
    string? CoverImageUrl,
    DateOnly? ReleaseDate,
    bool IsPublished,
    DateTime CreatedAt
);
}
