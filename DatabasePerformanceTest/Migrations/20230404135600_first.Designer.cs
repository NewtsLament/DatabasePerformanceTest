﻿// <auto-generated />
using System;
using DatabasePerformanceTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabasePerformanceTest.Migrations
{
    [DbContext(typeof(SongsDbContext))]
    [Migration("20230404135600_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DatabasePerformanceTest.SimilarDbDto", b =>
                {
                    b.Property<string>("SongTrackId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SimilarToTrackId")
                        .HasColumnType("varchar(255)");

                    b.Property<float>("Similarity")
                        .HasColumnType("float");

                    b.HasKey("SongTrackId", "SimilarToTrackId");

                    b.HasIndex("SimilarToTrackId");

                    b.ToTable("Similars");
                });

            modelBuilder.Entity("DatabasePerformanceTest.SongDbDto", b =>
                {
                    b.Property<string>("TrackId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TrackId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("DatabasePerformanceTest.SongTagDbDto", b =>
                {
                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("SongTagDbDto")
                        .HasColumnType("varchar(255)");

                    b.Property<byte>("Weight")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("TrackId", "TagId");

                    b.HasIndex("SongTagDbDto");

                    b.HasIndex("TagId");

                    b.ToTable("SongTags");
                });

            modelBuilder.Entity("DatabasePerformanceTest.TagDbDto", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DatabasePerformanceTest.SimilarDbDto", b =>
                {
                    b.HasOne("DatabasePerformanceTest.SongDbDto", "SimilarTo")
                        .WithMany("Similars")
                        .HasForeignKey("SimilarToTrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SimilarTo");
                });

            modelBuilder.Entity("DatabasePerformanceTest.SongTagDbDto", b =>
                {
                    b.HasOne("DatabasePerformanceTest.SongDbDto", "Song")
                        .WithMany("SongTags")
                        .HasForeignKey("SongTagDbDto");

                    b.HasOne("DatabasePerformanceTest.TagDbDto", "Tag")
                        .WithMany("SongTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("DatabasePerformanceTest.SongDbDto", b =>
                {
                    b.Navigation("Similars");

                    b.Navigation("SongTags");
                });

            modelBuilder.Entity("DatabasePerformanceTest.TagDbDto", b =>
                {
                    b.Navigation("SongTags");
                });
#pragma warning restore 612, 618
        }
    }
}
