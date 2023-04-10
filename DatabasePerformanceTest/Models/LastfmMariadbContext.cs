using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabasePerformanceTest.Models;

public partial class LastfmMariadbContext : DbContext
{
    public LastfmMariadbContext()
    {
    }

    public LastfmMariadbContext(DbContextOptions<LastfmMariadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Similar> Similars { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<SongsTag> SongsTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=forger;password=turpentine;database=lastfm.mariadb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Similar>(entity =>
        {
            entity.HasKey(e => new { e.TrackId, e.SimilarToTrackId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("similars");

            entity.HasIndex(e => e.SimilarToTrackId, "fk_tracks_similars_2");

            entity.Property(e => e.TrackId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("track_id");
            entity.Property(e => e.SimilarToTrackId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("similar_to_track_id");
            entity.Property(e => e.Similarity).HasColumnName("similarity");

            entity.HasOne(d => d.SimilarToTrack).WithMany(p => p.SimilarSimilarToTracks)
                .HasForeignKey(d => d.SimilarToTrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tracks_similars_2");

            entity.HasOne(d => d.Track).WithMany(p => p.SimilarTracks)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tracks_similars_1");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("PRIMARY");

            entity.ToTable("songs");

            entity.Property(e => e.TrackId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("track_id");
            entity.Property(e => e.Artist)
                .HasMaxLength(120)
                .HasColumnName("artist")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("timestamp(6)")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Title)
                .HasMaxLength(120)
                .HasColumnName("title")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<SongsTag>(entity =>
        {
            entity.HasKey(e => new { e.TrackId, e.TagId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("songs_tags");

            entity.HasIndex(e => e.TagId, "fk_songs_tags_tags_1");

            entity.Property(e => e.TrackId)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("track_id");
            entity.Property(e => e.TagId)
                .HasColumnType("int(11)")
                .HasColumnName("tag_id");
            entity.Property(e => e.Weight)
                .HasColumnType("tinyint(4)")
                .HasColumnName("weight");

            entity.HasOne(d => d.Tag).WithMany(p => p.SongsTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_songs_tags_tags_1");

            entity.HasOne(d => d.Track).WithMany(p => p.SongsTags)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_songs_tags_songs_1");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PRIMARY");

            entity.ToTable("tags");

            entity.Property(e => e.TagId)
                .HasColumnType("int(11)")
                .HasColumnName("tag_id");
            entity.Property(e => e.Title)
                .HasMaxLength(120)
                .HasColumnName("title")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
