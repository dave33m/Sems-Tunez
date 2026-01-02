using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SemsTunez.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Infrastructure.Persistence.Configurations
{
    public class PlaylistTrackConfiguration : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.ToTable("playlist_tracks");

            builder.HasKey(x => new { x.PlaylistId, x.TrackId });

            builder.Property(x => x.Position).IsRequired();

            builder.HasIndex(x => x.PlaylistId);
        }
    }
}

