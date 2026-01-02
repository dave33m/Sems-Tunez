using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SemsTunez.Infrastructure.persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlignTrackWithStorageKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseAttribution",
                table: "tracks");

            migrationBuilder.DropColumn(
                name: "LicenseType",
                table: "tracks");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "tracks",
                newName: "IsPublished");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "tracks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExplicit",
                table: "tracks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TrackNumber",
                table: "tracks",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExplicit",
                table: "tracks");

            migrationBuilder.DropColumn(
                name: "TrackNumber",
                table: "tracks");

            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "tracks",
                newName: "IsActive");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "tracks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "LicenseAttribution",
                table: "tracks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseType",
                table: "tracks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
