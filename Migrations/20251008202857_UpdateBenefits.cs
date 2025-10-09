using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booasacre.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBenefits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefit_Services_ServiceId",
                table: "Benefit");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Benefit",
                newName: "FKServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Benefit_ServiceId",
                table: "Benefit",
                newName: "IX_Benefit_FKServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefit_Services_FKServiceId",
                table: "Benefit",
                column: "FKServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefit_Services_FKServiceId",
                table: "Benefit");

            migrationBuilder.RenameColumn(
                name: "FKServiceId",
                table: "Benefit",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Benefit_FKServiceId",
                table: "Benefit",
                newName: "IX_Benefit_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefit_Services_ServiceId",
                table: "Benefit",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
