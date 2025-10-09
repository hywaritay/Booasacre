using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booasacre.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TeamMembers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TeamMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TeamMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "TeamMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TeamMembers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Statement",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Statement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Statement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Statement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Statement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Statement",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Statement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Statement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Statement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Services",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Services",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CoreValues",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CoreValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CoreValues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CoreValues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "CoreValues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CoreValues",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CoreValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "CoreValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CoreValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ContactInfo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ContactInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ContactInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "ContactInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContactInfo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Contact",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Contact",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Contact",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Contact",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Contact",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Consultation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Consultation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Consultation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Consultation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Consultation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Consultation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Consultation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Consultation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Consultation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Benefit",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Benefit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Benefit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Benefit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Benefit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Benefit",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Benefit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Benefit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Benefit",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Statement");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CoreValues");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Benefit");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Benefit");
        }
    }
}
