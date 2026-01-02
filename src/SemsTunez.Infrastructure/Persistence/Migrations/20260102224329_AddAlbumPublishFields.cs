using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SemsTunez.Infrastructure.persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbumPublishFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Albums",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Albums",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Albums");
        }
    }
}
