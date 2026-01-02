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
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("playlists");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasIndex(x => x.UserId);
        }
    }
}
