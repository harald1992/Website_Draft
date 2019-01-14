using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ImageAsURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioFile",
                table: "MusicTracks");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "MusicTracks");

            migrationBuilder.RenameColumn(
                name: "FileLocation",
                table: "MusicTracks",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "MusicTracks",
                newName: "FileLocation");

            migrationBuilder.AddColumn<byte[]>(
                name: "AudioFile",
                table: "MusicTracks",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "MusicTracks",
                nullable: true);
        }
    }
}
