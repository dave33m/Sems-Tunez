using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Artist
{
    public record ArtistResponse(
     Guid Id,
     string Name,
     string? Bio,
     string? ImageUrl,
     bool IsVerified,
     DateTime CreatedAt
 );
}
