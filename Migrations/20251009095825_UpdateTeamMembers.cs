using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booasacre.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeamMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImageSize",
                table: "TeamMembers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "ImageSize",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "TeamMembers");
        }
    }
}
