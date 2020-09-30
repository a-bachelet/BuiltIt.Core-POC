﻿// <auto-generated />
using System;
using BuildIt.Core.Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildIt.Core.Domain.Migrations
{
    [DbContext(typeof(GenericDbContext))]
    [Migration("20200929192425_Add_Artist_Entity_Two")]
    partial class Add_Artist_Entity_Two
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Album", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.Property<Guid>("AlbumGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AlbumGuid", "ArtistGuid");

                    b.HasIndex("ArtistGuid");

                    b.ToTable("AlbumArtist");
                });

            modelBuilder.Entity("Artist", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Song", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ListenCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("AlbumGuid");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("SongArtist", b =>
                {
                    b.Property<Guid>("ArtistGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SongGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistGuid", "SongGuid");

                    b.HasIndex("SongGuid");

                    b.ToTable("SongArtist");
                });

            modelBuilder.Entity("AlbumArtist", b =>
                {
                    b.HasOne("Album", "Album")
                        .WithMany("AlbumArtists")
                        .HasForeignKey("AlbumGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Artist", "Artist")
                        .WithMany("AlbumArtists")
                        .HasForeignKey("ArtistGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Song", b =>
                {
                    b.HasOne("Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumGuid");
                });

            modelBuilder.Entity("SongArtist", b =>
                {
                    b.HasOne("Artist", "Artist")
                        .WithMany("SongArtists")
                        .HasForeignKey("ArtistGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Song", "Song")
                        .WithMany("SongArtists")
                        .HasForeignKey("SongGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
