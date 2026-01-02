using SemsTunez.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Domain.Entitites
{
    public class Track : BaseEntity
    {
        public Guid ArtistId { get; private set; }
        public Guid? AlbumId { get; private set; }
        public string Title { get; private set; }
        public int DurationSeconds { get; private set; }
        public string StorageKey { get; private set; }
        public string LicenseType { get; private set; }
        public string LicenseAttribution { get; private set; }
        public bool IsActive { get; private set; }

        private Track() { }

        public Track(
            Guid artistId,
            string title,
            int durationSeconds,
            string storageKey,
            string licenseType,
            string licenseAttribution,
            Guid? albumId = null)
        {
            ArtistId = artistId;
            Title = title;
            DurationSeconds = durationSeconds;
            StorageKey = storageKey;
            LicenseType = licenseType;
            LicenseAttribution = licenseAttribution;
            AlbumId = albumId;
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
