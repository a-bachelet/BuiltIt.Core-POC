using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildIt.Core.Domain.Migrations
{
    public partial class Add_Artist_Entity_Two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumArtist",
                table: "AlbumArtist");

            migrationBuilder.DropIndex(
                name: "IX_AlbumArtist_AlbumGuid",
                table: "AlbumArtist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumArtist",
                table: "AlbumArtist",
                columns: new[] { "AlbumGuid", "ArtistGuid" });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtist_ArtistGuid",
                table: "AlbumArtist",
                column: "ArtistGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumArtist",
                table: "AlbumArtist");

            migrationBuilder.DropIndex(
                name: "IX_AlbumArtist_ArtistGuid",
                table: "AlbumArtist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumArtist",
                table: "AlbumArtist",
                columns: new[] { "ArtistGuid", "AlbumGuid" });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtist_AlbumGuid",
                table: "AlbumArtist",
                column: "AlbumGuid");
        }
    }
}
