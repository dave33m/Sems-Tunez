using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SemsTunez.Infrastructure.persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddArtistVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "artists",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "artists");
        }
    }
}
