using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booasacre.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiKey = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ApiSecret = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    ApiTokenMinute = table.Column<int>(type: "int", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AccountFeeBank = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AccountFeeCompany = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ChannelName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LimitTransaction = table.Column<double>(type: "float", nullable: true),
                    LimitDaily = table.Column<double>(type: "float", nullable: true),
                    LimitTransactionWithCard = table.Column<double>(type: "float", nullable: true),
                    LimitDailyWithCard = table.Column<double>(type: "float", nullable: true),
                    InstantTransferLimitTransaction = table.Column<double>(type: "float", nullable: true),
                    LimitWithCard = table.Column<bool>(type: "bit", nullable: true),
                    TransferAnyToAny = table.Column<bool>(type: "bit", nullable: true),
                    TransferOtherBank = table.Column<bool>(type: "bit", nullable: true),
                    InstantTransfer = table.Column<bool>(type: "bit", nullable: true),
                    RewriteExplCode = table.Column<bool>(type: "bit", nullable: true),
                    Lastconnect = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    QueryString = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertNotif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sms = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EmailSubject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    EmailTo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    EmailCc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    EmailBcc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    EmailBody = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    TransmitEmail = table.Column<bool>(type: "bit", nullable: true),
                    TransmitPhone = table.Column<bool>(type: "bit", nullable: true),
                    FkUserId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertNotif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertNotif_ApiUser_FkUserId",
                        column: x => x.FkUserId,
                        principalTable: "ApiUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApiUserPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FkUserId = table.Column<int>(type: "int", nullable: true),
                    FkPermissionId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUserPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiUserPermission_ApiPermission_FkPermissionId",
                        column: x => x.FkPermissionId,
                        principalTable: "ApiPermission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApiUserPermission_ApiUser_FkUserId",
                        column: x => x.FkUserId,
                        principalTable: "ApiUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OneTimePassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Otp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TransmitEmail = table.Column<bool>(type: "bit", nullable: true),
                    TransmitStatus = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TransmitPhone = table.Column<bool>(type: "bit", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransmitEmailDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransmitPhoneDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsedTimeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FkUserId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimePassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimePassword_ApiUser_FkUserId",
                        column: x => x.FkUserId,
                        principalTable: "ApiUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertNotif_FkUserId",
                table: "AlertNotif",
                column: "FkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiUserPermission_FkPermissionId",
                table: "ApiUserPermission",
                column: "FkPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiUserPermission_FkUserId",
                table: "ApiUserPermission",
                column: "FkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OneTimePassword_FkUserId",
                table: "OneTimePassword",
                column: "FkUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertNotif");

            migrationBuilder.DropTable(
                name: "ApiUserPermission");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "OneTimePassword");

            migrationBuilder.DropTable(
                name: "ApiPermission");

            migrationBuilder.DropTable(
                name: "ApiUser");
        }
    }
}
