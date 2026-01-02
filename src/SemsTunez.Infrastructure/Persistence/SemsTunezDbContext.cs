using Microsoft.EntityFrameworkCore;
using SemsTunez.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Infrastructure.Persistence
{
    public class SemsTunezDbContext : DbContext
    {
        public SemsTunezDbContext(DbContextOptions<SemsTunezDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Track> Tracks => Set<Track>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<PlaylistTrack> PlaylistTracks => Set<PlaylistTrack>();

        public DbSet<UserOtp> UserOtps => Set<UserOtp>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SemsTunezDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

