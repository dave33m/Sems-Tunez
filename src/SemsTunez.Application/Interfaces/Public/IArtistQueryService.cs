using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemsTunez.Application.DTOs.Public.Artists;

namespace SemsTunez.Application.Interfaces.Public
{
    public interface IArtistQueryService
    {
        Task<List<ArtistResponse>> GetAllAsync();
        Task<ArtistResponse> GetByIdAsync(Guid id);
    }
}
