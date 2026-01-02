using SemsTunez.Application.DTOs.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Application.Interfaces.Tracks
{
    public interface ITrackService
    {
        Task<List<TrackResponse>> GetAllAsync();
        Task<TrackResponse> GetByIdAsync(Guid id);
        Task<TrackResponse> CreateAsync(CreateTrackRequest request);
        Task<TrackResponse> UpdateAsync(Guid id, UpdateTrackRequest request);
        Task PublishAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
