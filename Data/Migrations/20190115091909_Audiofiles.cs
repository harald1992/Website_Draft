using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Audiofiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AudiofileUrl",
                table: "MusicTracks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudiofileUrl",
                table: "MusicTracks");
        }
    }
}
