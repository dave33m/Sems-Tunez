using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Albums
{
    public record CreateAlbumRequest(
     Guid ArtistId,
     string Title,
     string? Description,
     string? CoverImageUrl,
     DateOnly? ReleaseDate
 );
}
