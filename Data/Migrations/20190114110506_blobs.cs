using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class blobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AudioFile",
                table: "MusicTracks",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "MusicTracks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioFile",
                table: "MusicTracks");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "MusicTracks");
        }
    }
}
