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
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MemberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementImages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
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
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserMemberTypeMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MemberTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMemberTypeMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMemberTypeMappings_MemberTypes_MemberTypeId",
                        column: x => x.MemberTypeId,
                        principalTable: "MemberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMemberTypeMappings_users_UserId",
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
                table: "companies",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, "Kartal/Istanbul", "gymapp@gymapp.com", "GymApp", "+905535305501" });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "CompanyId", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, 1, "gymapp@gymapp.com", "GymApp", "+905535305501" });

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
                    { 21, "UserMemberTypeMapping.Admin" },
                    { 22, "UserMemberTypeMapping.Create" },
                    { 23, "UserMemberTypeMapping.Update" },
                    { 24, "UserMemberTypeMapping.Delete" },
                    { 25, "UserMemberTypeMapping.Read" },
                    { 26, "Movement.Admin" },
                    { 27, "Movement.Create" },
                    { 28, "Movement.Update" },
                    { 29, "Movement.Delete" },
                    { 30, "Movement.Read" },
                    { 31, "Customer.Admin" },
                    { 32, "Customer.Create" },
                    { 33, "Customer.Update" },
                    { 34, "Customer.Delete" },
                    { 35, "Customer.Read" },
                    { 36, "Company.Admin" },
                    { 37, "Company.Create" },
                    { 38, "Company.Update" },
                    { 39, "Company.Delete" },
                    { 40, "Company.Read" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AuthenticatorType", "CompanyId", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 1, 0, 1, 1, "gymapp@gymapp.com", "gymapp", "gymapp", new byte[] { 166, 167, 63, 22, 207, 196, 80, 241, 75, 161, 246, 82, 58, 115, 244, 235, 165, 140, 236, 113, 179, 210, 140, 156, 211, 253, 116, 5, 20, 67, 191, 208, 94, 1, 114, 92, 205, 233, 239, 61, 238, 115, 191, 95, 126, 32, 42, 153, 50, 24, 144, 176, 119, 111, 70, 66, 146, 153, 185, 219, 99, 191, 143, 105 }, new byte[] { 216, 75, 57, 198, 78, 103, 21, 229, 24, 51, 241, 36, 110, 100, 50, 152, 105, 82, 40, 170, 135, 24, 140, 160, 225, 242, 86, 210, 250, 167, 142, 202, 80, 240, 215, 172, 203, 149, 105, 75, 25, 154, 218, 136, 37, 133, 253, 150, 163, 26, 96, 250, 39, 26, 164, 77, 150, 226, 75, 191, 118, 141, 84, 99, 118, 89, 180, 5, 189, 24, 44, 246, 115, 14, 86, 243, 184, 199, 205, 100, 239, 97, 27, 163, 176, 187, 73, 139, 110, 182, 151, 251, 124, 199, 184, 58, 118, 109, 51, 70, 243, 211, 169, 208, 59, 236, 162, 28, 53, 124, 27, 215, 239, 64, 53, 172, 211, 80, 218, 85, 204, 192, 99, 139, 193, 112, 213, 179 }, true });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 11, 11, 1 },
                    { 12, 12, 1 },
                    { 13, 13, 1 },
                    { 14, 14, 1 },
                    { 15, 15, 1 },
                    { 16, 16, 1 },
                    { 17, 17, 1 },
                    { 18, 18, 1 },
                    { 19, 19, 1 },
                    { 20, 20, 1 },
                    { 21, 21, 1 },
                    { 22, 22, 1 },
                    { 23, 23, 1 },
                    { 24, 24, 1 },
                    { 25, 25, 1 },
                    { 26, 26, 1 },
                    { 27, 27, 1 },
                    { 28, 28, 1 },
                    { 29, 29, 1 },
                    { 30, 30, 1 },
                    { 31, 31, 1 },
                    { 32, 32, 1 },
                    { 33, 33, 1 },
                    { 34, 34, 1 },
                    { 35, 35, 1 },
                    { 36, 36, 1 },
                    { 37, 37, 1 },
                    { 38, 38, 1 },
                    { 39, 39, 1 },
                    { 40, 40, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberTypeMappings_MemberTypeId",
                table: "UserMemberTypeMappings",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberTypeMappings_UserId",
                table: "UserMemberTypeMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_useroperationclaims_OperationClaimId",
                table: "useroperationclaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_useroperationclaims_UserId",
                table: "useroperationclaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_CompanyId",
                table: "users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_users_CustomerId",
                table: "users",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyInformations");

            migrationBuilder.DropTable(
                name: "MovementImages");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserMemberTypeMappings");

            migrationBuilder.DropTable(
                name: "useroperationclaims");

            migrationBuilder.DropTable(
                name: "MemberTypes");

            migrationBuilder.DropTable(
                name: "operationclaims");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
