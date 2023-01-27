using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BodyInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Length = table.Column<float>(type: "float", nullable: false),
                    Weight = table.Column<float>(type: "float", nullable: false),
                    Arm = table.Column<float>(type: "float", nullable: false),
                    Shoulder = table.Column<float>(type: "float", nullable: false),
                    Leg = table.Column<float>(type: "float", nullable: false),
                    Chest = table.Column<float>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyInformations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MemberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "operationclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operationclaims", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedByIp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RevokedByIp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReplacedByToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonRevoked = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "useroperationclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useroperationclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_useroperationclaims_operationclaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "operationclaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_useroperationclaims_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "operationclaims",
                columns: new[] { "Id", "FirstName" },
                values: new object[,]
                {
                    { 1, "BodyInformation.Admin" },
                    { 2, "BodyInformation.Create" },
                    { 3, "BodyInformation.Update" },
                    { 4, "BodyInformation.Delete" },
                    { 5, "BodyInformation.Read" },
                    { 6, "MemberType.Admin" },
                    { 7, "MemberType.Create" },
                    { 8, "MemberType.Update" },
                    { 9, "MemberType.Delete" },
                    { 10, "MemberType.Read" },
                    { 11, "OperationClaim.Admin" },
                    { 12, "OperationClaim.Create" },
                    { 13, "OperationClaim.Update" },
                    { 14, "OperationClaim.Delete" },
                    { 15, "OperationClaim.Read" },
                    { 16, "UserOperationClaim.Admin" },
                    { 17, "UserOperationClaim.Create" },
                    { 18, "UserOperationClaim.Update" },
                    { 19, "UserOperationClaim.Delete" },
                    { 20, "UserOperationClaim.Read" },
                    { 21, "UserGroup.Admin" },
                    { 22, "UserGroup.Create" },
                    { 23, "UserGroup.Update" },
                    { 24, "UserGroup.Delete" },
                    { 25, "UserGroup.Read" },
                    { 26, "UserGroupOperationClaimMapping.Admin" },
                    { 27, "UserGroupOperationClaimMapping.Create" },
                    { 28, "UserGroupOperationClaimMapping.Update" },
                    { 29, "UserGroupOperationClaimMapping.Delete" },
                    { 30, "UserGroupOperationClaimMapping.Read" },
                    { 31, "UserUserGroupMapping.Admin" },
                    { 32, "UserUserGroupMapping.Create" },
                    { 33, "UserUserGroupMapping.Update" },
                    { 34, "UserUserGroupMapping.Delete" },
                    { 35, "UserUserGroupMapping.Read" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AuthenticatorType", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 4, 0, "gymapp@gymapp.com", "gymapp", "gymapp", new byte[] { 250, 209, 54, 116, 125, 1, 126, 238, 111, 156, 57, 234, 142, 140, 244, 249, 0, 44, 120, 199, 210, 138, 157, 85, 232, 43, 119, 183, 223, 102, 13, 119, 70, 182, 124, 68, 56, 255, 210, 84, 129, 21, 12, 95, 124, 100, 69, 205, 180, 0, 11, 183, 196, 74, 122, 218, 14, 36, 102, 98, 185, 32, 117, 155 }, new byte[] { 255, 66, 11, 188, 168, 195, 85, 91, 76, 11, 204, 149, 154, 254, 183, 7, 138, 118, 209, 2, 244, 194, 17, 29, 216, 123, 72, 74, 220, 59, 32, 199, 212, 159, 230, 236, 64, 212, 227, 68, 185, 23, 216, 48, 80, 173, 158, 159, 216, 198, 73, 61, 59, 77, 28, 181, 208, 198, 234, 101, 238, 120, 206, 142, 253, 177, 207, 63, 52, 1, 250, 67, 104, 16, 157, 228, 222, 38, 184, 19, 218, 74, 181, 54, 63, 52, 86, 145, 115, 123, 242, 46, 209, 34, 215, 187, 203, 93, 146, 222, 254, 198, 65, 241, 136, 52, 1, 25, 228, 8, 204, 26, 72, 184, 3, 192, 195, 56, 175, 61, 130, 29, 160, 53, 125, 117, 171, 69 }, true });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 2, 4 },
                    { 3, 3, 4 },
                    { 4, 4, 4 },
                    { 5, 5, 4 },
                    { 6, 6, 4 },
                    { 7, 7, 4 },
                    { 8, 8, 4 },
                    { 9, 9, 4 },
                    { 10, 10, 4 },
                    { 11, 11, 4 },
                    { 12, 12, 4 },
                    { 13, 13, 4 },
                    { 14, 14, 4 },
                    { 15, 15, 4 },
                    { 16, 16, 4 },
                    { 17, 17, 4 },
                    { 18, 18, 4 },
                    { 19, 19, 4 },
                    { 20, 20, 4 },
                    { 21, 21, 4 },
                    { 22, 22, 4 },
                    { 23, 23, 4 },
                    { 24, 24, 4 },
                    { 25, 25, 4 },
                    { 26, 26, 4 },
                    { 27, 27, 4 },
                    { 28, 28, 4 },
                    { 29, 29, 4 },
                    { 30, 30, 4 },
                    { 31, 31, 4 },
                    { 32, 32, 4 },
                    { 33, 33, 4 },
                    { 34, 34, 4 },
                    { 35, 35, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_useroperationclaims_OperationClaimId",
                table: "useroperationclaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_useroperationclaims_UserId",
                table: "useroperationclaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyInformations");

            migrationBuilder.DropTable(
                name: "MemberTypes");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "useroperationclaims");

            migrationBuilder.DropTable(
                name: "operationclaims");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
