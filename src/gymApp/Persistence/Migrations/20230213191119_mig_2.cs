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
            migrationBuilder.CreateTable(
                name: "CustomerToMovementMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MovementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerToMovementMappings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 102, 141, 150, 197, 136, 40, 187, 38, 144, 6, 224, 185, 145, 2, 127, 86, 247, 193, 84, 143, 32, 107, 45, 29, 18, 181, 231, 46, 45, 19, 59, 69, 237, 37, 74, 241, 216, 165, 154, 63, 195, 18, 210, 148, 58, 13, 55, 25, 77, 189, 68, 73, 175, 25, 175, 6, 78, 3, 209, 96, 87, 47, 175, 89 }, new byte[] { 252, 86, 226, 140, 136, 183, 32, 193, 132, 76, 206, 87, 17, 205, 49, 164, 83, 95, 184, 251, 210, 23, 219, 149, 200, 133, 170, 58, 16, 50, 29, 113, 11, 41, 97, 66, 183, 24, 44, 27, 50, 197, 84, 19, 141, 220, 218, 9, 239, 248, 225, 136, 33, 120, 108, 36, 116, 243, 7, 19, 40, 32, 90, 69, 39, 19, 231, 236, 64, 197, 124, 73, 146, 246, 167, 5, 64, 91, 116, 119, 224, 91, 160, 131, 151, 187, 57, 222, 132, 49, 55, 255, 169, 58, 244, 69, 160, 225, 219, 144, 100, 74, 74, 13, 235, 148, 156, 11, 94, 230, 172, 134, 232, 84, 32, 111, 96, 48, 13, 154, 33, 8, 82, 103, 200, 107, 43, 2 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerToMovementMappings");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 166, 167, 63, 22, 207, 196, 80, 241, 75, 161, 246, 82, 58, 115, 244, 235, 165, 140, 236, 113, 179, 210, 140, 156, 211, 253, 116, 5, 20, 67, 191, 208, 94, 1, 114, 92, 205, 233, 239, 61, 238, 115, 191, 95, 126, 32, 42, 153, 50, 24, 144, 176, 119, 111, 70, 66, 146, 153, 185, 219, 99, 191, 143, 105 }, new byte[] { 216, 75, 57, 198, 78, 103, 21, 229, 24, 51, 241, 36, 110, 100, 50, 152, 105, 82, 40, 170, 135, 24, 140, 160, 225, 242, 86, 210, 250, 167, 142, 202, 80, 240, 215, 172, 203, 149, 105, 75, 25, 154, 218, 136, 37, 133, 253, 150, 163, 26, 96, 250, 39, 26, 164, 77, 150, 226, 75, 191, 118, 141, 84, 99, 118, 89, 180, 5, 189, 24, 44, 246, 115, 14, 86, 243, 184, 199, 205, 100, 239, 97, 27, 163, 176, 187, 73, 139, 110, 182, 151, 251, 124, 199, 184, 58, 118, 109, 51, 70, 243, 211, 169, 208, 59, 236, 162, 28, 53, 124, 27, 215, 239, 64, 53, 172, 211, 80, 218, 85, 204, 192, 99, 139, 193, 112, 213, 179 } });
        }
    }
}
