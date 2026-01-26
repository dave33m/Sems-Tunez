using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Public.Artists
{
    public record ArtistResponse(
    Guid Id,
    string Name,
    string? Bio,
    string? ImageUrl
);
}
