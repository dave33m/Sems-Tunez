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
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("tracks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.StorageKey).IsRequired();
            builder.Property(x => x.DurationSeconds).IsRequired();

            builder.HasIndex(x => x.ArtistId);
            builder.HasIndex(x => x.AlbumId);
        }
    }
}
