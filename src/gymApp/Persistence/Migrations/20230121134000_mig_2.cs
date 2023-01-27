using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "MemberTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MemberTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MemberTypes",
                type: "longtext",
                nullable: false)
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

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 48, 23, 20, 103, 246, 109, 212, 14, 168, 4, 194, 239, 31, 68, 91, 211, 19, 228, 180, 220, 5, 71, 249, 179, 117, 32, 105, 218, 65, 104, 90, 164, 120, 123, 88, 98, 99, 23, 111, 154, 134, 242, 74, 0, 17, 247, 196, 17, 198, 193, 228, 116, 253, 210, 197, 117, 135, 31, 51, 227, 59, 221, 75, 177 }, new byte[] { 185, 14, 85, 197, 25, 199, 249, 101, 195, 151, 231, 161, 126, 83, 241, 143, 255, 124, 165, 187, 213, 192, 145, 239, 243, 125, 228, 144, 102, 61, 45, 216, 39, 182, 167, 25, 210, 149, 165, 0, 219, 103, 102, 12, 171, 242, 53, 118, 233, 62, 120, 169, 12, 217, 139, 97, 154, 48, 128, 244, 40, 169, 182, 126, 210, 250, 117, 224, 57, 46, 241, 23, 254, 187, 206, 1, 89, 89, 149, 206, 133, 181, 226, 60, 199, 190, 45, 141, 129, 160, 125, 27, 91, 177, 165, 4, 58, 231, 21, 65, 17, 39, 183, 14, 43, 75, 171, 180, 22, 5, 158, 177, 63, 220, 0, 53, 160, 65, 178, 206, 15, 16, 243, 167, 31, 137, 68, 58 } });

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberTypeMappings_MemberTypeId",
                table: "UserMemberTypeMappings",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberTypeMappings_UserId",
                table: "UserMemberTypeMappings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMemberTypeMappings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MemberTypes");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "MemberTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MemberTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 250, 209, 54, 116, 125, 1, 126, 238, 111, 156, 57, 234, 142, 140, 244, 249, 0, 44, 120, 199, 210, 138, 157, 85, 232, 43, 119, 183, 223, 102, 13, 119, 70, 182, 124, 68, 56, 255, 210, 84, 129, 21, 12, 95, 124, 100, 69, 205, 180, 0, 11, 183, 196, 74, 122, 218, 14, 36, 102, 98, 185, 32, 117, 155 }, new byte[] { 255, 66, 11, 188, 168, 195, 85, 91, 76, 11, 204, 149, 154, 254, 183, 7, 138, 118, 209, 2, 244, 194, 17, 29, 216, 123, 72, 74, 220, 59, 32, 199, 212, 159, 230, 236, 64, 212, 227, 68, 185, 23, 216, 48, 80, 173, 158, 159, 216, 198, 73, 61, 59, 77, 28, 181, 208, 198, 234, 101, 238, 120, 206, 142, 253, 177, 207, 63, 52, 1, 250, 67, 104, 16, 157, 228, 222, 38, 184, 19, 218, 74, 181, 54, 63, 52, 86, 145, 115, 123, 242, 46, 209, 34, 215, 187, 203, 93, 146, 222, 254, 198, 65, 241, 136, 52, 1, 25, 228, 8, 204, 26, 72, 184, 3, 192, 195, 56, 175, 61, 130, 29, 160, 53, 125, 117, 171, 69 } });
        }
    }
}
