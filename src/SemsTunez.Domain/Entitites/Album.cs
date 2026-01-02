using SemsTunez.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Domain.Entitites
{
    public class Album : BaseEntity
    {
        public Guid ArtistId { get; private set; }
        public string Title { get; private set; }
        public string? CoverImageUrl { get; private set; }
        public DateOnly? ReleaseDate { get; private set; }

        private Album() { }

        public Album(Guid artistId, string title, DateOnly? releaseDate = null, string? coverImageUrl = null)
        {
            ArtistId = artistId;
            Title = title;
            ReleaseDate = releaseDate;
            CoverImageUrl = coverImageUrl;
        }
    }
}
