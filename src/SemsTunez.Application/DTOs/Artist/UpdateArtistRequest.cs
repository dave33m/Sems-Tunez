using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Artist
{
    public record UpdateArtistRequest(
    string Name,
    string? Bio,
    string? ImageUrl
);
}
