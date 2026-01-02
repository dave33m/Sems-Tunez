using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Domain.Entitites
{
    public class PlaylistTrack
    {
        public Guid PlaylistId { get; private set; }
        public Guid TrackId { get; private set; }
        public int Position { get; private set; }

        private PlaylistTrack() { }

        public PlaylistTrack(Guid playlistId, Guid trackId, int position)
        {
            PlaylistId = playlistId;
            TrackId = trackId;
            Position = position;
        }
    }
}
