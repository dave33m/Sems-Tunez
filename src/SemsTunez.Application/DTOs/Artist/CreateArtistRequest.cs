using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.DTOs.Artist
{
    public record CreateArtistRequest(
     string Name,
     string? Bio,
     string? ImageUrl
 );
}

