using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildIt.Core.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Album",
                table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Album", x => x.Guid); });

            migrationBuilder.CreateTable(
                "Song",
                table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ListenCount = table.Column<int>(nullable: false),
                    AlbumGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Guid);
                    table.ForeignKey(
                        "FK_Song_Album_AlbumGuid",
                        x => x.AlbumGuid,
                        "Album",
                        "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Song_AlbumGuid",
                "Song",
                "AlbumGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Song");

            migrationBuilder.DropTable(
                "Album");
        }
    }
}