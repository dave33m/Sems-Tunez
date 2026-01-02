using SemsTunez.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Interfaces.Repositories
{
    public interface IArtistRepository
    {
        Task<Artist?> GetByIdAsync(Guid id);
        Task<List<Artist>> GetAllAsync();
        Task AddAsync(Artist artist);
        Task UpdateAsync(Artist artist);
        Task DeleteAsync(Artist artist);
    }
}
