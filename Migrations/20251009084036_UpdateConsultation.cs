using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booasacre.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Services_ServiceId",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_ServiceId",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Consultation");

            migrationBuilder.AddColumn<int>(
                name: "FKServiceId",
                table: "Consultation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_FKServiceId",
                table: "Consultation",
                column: "FKServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Services_FKServiceId",
                table: "Consultation",
                column: "FKServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Services_FKServiceId",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_FKServiceId",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "FKServiceId",
                table: "Consultation");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Consultation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_ServiceId",
                table: "Consultation",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Services_ServiceId",
                table: "Consultation",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
