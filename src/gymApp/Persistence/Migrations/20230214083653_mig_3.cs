using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 93, 59, 233, 158, 15, 145, 22, 172, 230, 200, 58, 239, 151, 128, 6, 157, 204, 55, 68, 220, 118, 227, 104, 73, 165, 250, 166, 96, 16, 149, 227, 239, 203, 239, 133, 241, 237, 29, 60, 158, 16, 123, 165, 199, 149, 249, 99, 59, 55, 119, 205, 245, 88, 34, 137, 70, 139, 107, 65, 106, 164, 249, 242, 128 }, new byte[] { 110, 41, 27, 227, 141, 143, 14, 196, 74, 216, 151, 112, 27, 167, 241, 213, 50, 189, 241, 14, 8, 50, 254, 4, 65, 165, 55, 153, 119, 244, 123, 218, 32, 173, 157, 54, 13, 238, 154, 94, 249, 41, 25, 128, 235, 31, 95, 13, 206, 108, 247, 238, 111, 246, 71, 110, 43, 202, 69, 91, 90, 13, 237, 181, 106, 212, 89, 193, 173, 48, 118, 247, 57, 3, 28, 19, 215, 203, 241, 140, 158, 34, 92, 107, 68, 214, 71, 149, 153, 158, 105, 192, 33, 175, 123, 224, 166, 214, 239, 37, 139, 53, 107, 7, 222, 93, 64, 115, 143, 158, 80, 178, 128, 255, 6, 227, 104, 128, 23, 230, 72, 222, 57, 140, 224, 33, 227, 30 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalTrainers");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 102, 141, 150, 197, 136, 40, 187, 38, 144, 6, 224, 185, 145, 2, 127, 86, 247, 193, 84, 143, 32, 107, 45, 29, 18, 181, 231, 46, 45, 19, 59, 69, 237, 37, 74, 241, 216, 165, 154, 63, 195, 18, 210, 148, 58, 13, 55, 25, 77, 189, 68, 73, 175, 25, 175, 6, 78, 3, 209, 96, 87, 47, 175, 89 }, new byte[] { 252, 86, 226, 140, 136, 183, 32, 193, 132, 76, 206, 87, 17, 205, 49, 164, 83, 95, 184, 251, 210, 23, 219, 149, 200, 133, 170, 58, 16, 50, 29, 113, 11, 41, 97, 66, 183, 24, 44, 27, 50, 197, 84, 19, 141, 220, 218, 9, 239, 248, 225, 136, 33, 120, 108, 36, 116, 243, 7, 19, 40, 32, 90, 69, 39, 19, 231, 236, 64, 197, 124, 73, 146, 246, 167, 5, 64, 91, 116, 119, 224, 91, 160, 131, 151, 187, 57, 222, 132, 49, 55, 255, 169, 58, 244, 69, 160, 225, 219, 144, 100, 74, 74, 13, 235, 148, 156, 11, 94, 230, 172, 134, 232, 84, 32, 111, 96, 48, 13, 154, 33, 8, 82, 103, 200, 107, 43, 2 } });
        }
    }
}
