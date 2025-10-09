using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booasacre.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoreValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CoreValues",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CoreValues",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CoreValues");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CoreValues",
                newName: "Name");
        }
    }
}
