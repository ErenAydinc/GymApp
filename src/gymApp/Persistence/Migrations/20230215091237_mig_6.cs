using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMovements", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 31, 79, 111, 110, 81, 206, 242, 252, 202, 248, 5, 4, 182, 253, 123, 45, 8, 227, 239, 88, 185, 128, 36, 188, 48, 55, 131, 169, 66, 60, 217, 235, 116, 174, 95, 139, 42, 214, 52, 25, 113, 28, 150, 225, 31, 90, 131, 221, 160, 83, 247, 142, 84, 195, 78, 238, 156, 100, 126, 207, 252, 76, 212, 58 }, new byte[] { 105, 75, 81, 238, 79, 161, 143, 92, 34, 46, 122, 212, 87, 12, 143, 170, 250, 113, 235, 229, 9, 162, 152, 248, 159, 101, 63, 192, 163, 196, 46, 42, 82, 202, 212, 77, 49, 220, 117, 174, 165, 80, 83, 1, 59, 119, 13, 1, 242, 82, 169, 27, 229, 97, 126, 111, 199, 105, 195, 97, 161, 248, 96, 100, 26, 219, 205, 201, 159, 193, 136, 242, 89, 215, 26, 13, 9, 18, 23, 117, 207, 209, 186, 99, 250, 41, 197, 174, 24, 20, 234, 27, 247, 171, 3, 245, 54, 75, 26, 39, 100, 108, 168, 236, 146, 61, 184, 69, 168, 97, 62, 181, 47, 113, 244, 251, 225, 213, 114, 190, 106, 29, 99, 251, 53, 212, 94, 185 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersMovements");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 15, 210, 146, 28, 221, 212, 201, 192, 105, 31, 23, 235, 65, 78, 129, 218, 234, 190, 227, 87, 255, 45, 248, 19, 147, 129, 144, 168, 178, 38, 191, 154, 7, 218, 202, 74, 140, 184, 235, 220, 51, 107, 51, 161, 237, 162, 177, 142, 166, 236, 246, 44, 107, 180, 155, 35, 136, 190, 166, 163, 20, 9, 206, 28 }, new byte[] { 132, 203, 230, 123, 114, 71, 247, 41, 11, 74, 188, 230, 200, 207, 30, 12, 128, 58, 250, 131, 25, 6, 156, 1, 112, 89, 159, 153, 127, 101, 75, 248, 197, 242, 221, 237, 245, 56, 59, 133, 47, 239, 161, 11, 225, 185, 242, 253, 96, 140, 244, 172, 210, 180, 94, 48, 245, 182, 107, 187, 44, 96, 64, 230, 17, 81, 19, 196, 45, 138, 173, 89, 210, 253, 205, 47, 178, 123, 182, 227, 46, 16, 241, 51, 40, 173, 82, 241, 107, 6, 102, 11, 42, 99, 172, 89, 242, 4, 111, 204, 75, 69, 161, 171, 178, 245, 230, 116, 113, 114, 110, 87, 196, 92, 43, 120, 169, 238, 253, 156, 0, 57, 245, 71, 197, 139, 146, 11 } });
        }
    }
}
