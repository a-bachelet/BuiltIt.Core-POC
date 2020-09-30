using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildIt.Core.Domain.Migrations
{
    public partial class Add_Artist_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "AlbumArtist",
                columns: table => new
                {
                    ArtistGuid = table.Column<Guid>(nullable: false),
                    AlbumGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtist", x => new { x.ArtistGuid, x.AlbumGuid });
                    table.ForeignKey(
                        name: "FK_AlbumArtist_Album_AlbumGuid",
                        column: x => x.AlbumGuid,
                        principalTable: "Album",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumArtist_Artist_ArtistGuid",
                        column: x => x.ArtistGuid,
                        principalTable: "Artist",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongArtist",
                columns: table => new
                {
                    ArtistGuid = table.Column<Guid>(nullable: false),
                    SongGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtist", x => new { x.ArtistGuid, x.SongGuid });
                    table.ForeignKey(
                        name: "FK_SongArtist_Artist_ArtistGuid",
                        column: x => x.ArtistGuid,
                        principalTable: "Artist",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongArtist_Song_SongGuid",
                        column: x => x.SongGuid,
                        principalTable: "Song",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtist_AlbumGuid",
                table: "AlbumArtist",
                column: "AlbumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtist_SongGuid",
                table: "SongArtist",
                column: "SongGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumArtist");

            migrationBuilder.DropTable(
                name: "SongArtist");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
