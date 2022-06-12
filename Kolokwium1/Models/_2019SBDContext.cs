using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kolokwium1.Models
{
    public partial class _2019SBDContext : DbContext
    {
        public _2019SBDContext()
        {
        }

        public _2019SBDContext(DbContextOptions<_2019SBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=db-mssql;Database=2019SBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("s21096")
                .HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("PK__Album__BF9C2A2262EB5807");

                entity.ToTable("Album");

                entity.Property(e => e.IdAlbum).ValueGeneratedNever();

                entity.Property(e => e.AlbumName).HasMaxLength(30);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdMusicLabelNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdMusicLabel)
                    .HasConstraintName("FK__Album__IdMusicLa__06091E80");
            });

            modelBuilder.Entity<MusicLabel>(entity =>
            {
                entity.HasKey(e => e.IdMusicLabel)
                    .HasName("PK__MusicLab__0B109B47CB325DAB");

                entity.ToTable("MusicLabel");

                entity.Property(e => e.IdMusicLabel).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Musician>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                    .HasName("PK__Musician__4C96BD3025C06A5C");

                entity.ToTable("Musician");

                entity.Property(e => e.IdMusician).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(20);
            });

            modelBuilder.Entity<MusicianTrack>(entity =>
            {
                entity.HasKey(e => new { e.IdTrack, e.IdMusician })
                    .HasName("Musician_Track_PRIMARY");

                entity.ToTable("Musician_Track");

                entity.HasOne(d => d.IdMusicianNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.IdMusician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Musician___IdMus__0420D60E");

                entity.HasOne(d => d.IdTrackNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Musician___IdTra__032CB1D5");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.IdTrack)
                    .HasName("PK__Track__A74BDB9631942774");

                entity.ToTable("Track");

                entity.Property(e => e.IdTrack).ValueGeneratedNever();

                entity.Property(e => e.TrackName).HasMaxLength(20);

                entity.HasOne(d => d.IdMusicAlbumNavigation)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.IdMusicAlbum)
                    .HasConstraintName("FK__Track__IdMusicAl__0514FA47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
