using SemsTunez.Application.DTOs.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Interfaces.Albums
{
    public interface IAlbumService
    {
        Task<List<AlbumResponse>> GetAllAsync();
        Task<AlbumResponse> GetByIdAsync(Guid id);
        Task<AlbumResponse> CreateAsync(CreateAlbumRequest request);
        Task<AlbumResponse> UpdateAsync(Guid id, UpdateAlbumRequest request);
        Task PublishAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
