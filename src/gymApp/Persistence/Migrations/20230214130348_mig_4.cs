using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalTrainerStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PersonalTrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainerStudents", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 224, 160, 231, 63, 61, 180, 181, 54, 109, 78, 107, 152, 132, 167, 33, 227, 61, 251, 146, 220, 115, 83, 196, 33, 166, 214, 5, 105, 125, 164, 246, 160, 225, 250, 8, 48, 254, 232, 26, 122, 87, 206, 64, 205, 117, 92, 211, 250, 2, 236, 43, 184, 113, 114, 115, 2, 141, 241, 149, 54, 244, 242, 125 }, new byte[] { 163, 76, 88, 252, 0, 102, 232, 248, 220, 94, 148, 129, 156, 177, 52, 146, 103, 176, 20, 123, 190, 137, 248, 78, 150, 42, 188, 237, 78, 70, 242, 69, 240, 200, 12, 7, 62, 206, 170, 147, 241, 14, 176, 80, 49, 138, 95, 242, 233, 112, 196, 135, 233, 218, 195, 137, 137, 234, 56, 24, 183, 182, 58, 8, 193, 57, 82, 134, 195, 164, 28, 71, 192, 182, 91, 188, 89, 21, 198, 201, 139, 69, 140, 190, 56, 54, 233, 31, 10, 96, 57, 188, 34, 183, 54, 75, 223, 61, 112, 52, 5, 108, 98, 8, 197, 168, 127, 226, 222, 248, 157, 207, 117, 174, 100, 206, 210, 112, 214, 98, 35, 111, 77, 209, 179, 47, 5, 25 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalTrainerStudents");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 93, 59, 233, 158, 15, 145, 22, 172, 230, 200, 58, 239, 151, 128, 6, 157, 204, 55, 68, 220, 118, 227, 104, 73, 165, 250, 166, 96, 16, 149, 227, 239, 203, 239, 133, 241, 237, 29, 60, 158, 16, 123, 165, 199, 149, 249, 99, 59, 55, 119, 205, 245, 88, 34, 137, 70, 139, 107, 65, 106, 164, 249, 242, 128 }, new byte[] { 110, 41, 27, 227, 141, 143, 14, 196, 74, 216, 151, 112, 27, 167, 241, 213, 50, 189, 241, 14, 8, 50, 254, 4, 65, 165, 55, 153, 119, 244, 123, 218, 32, 173, 157, 54, 13, 238, 154, 94, 249, 41, 25, 128, 235, 31, 95, 13, 206, 108, 247, 238, 111, 246, 71, 110, 43, 202, 69, 91, 90, 13, 237, 181, 106, 212, 89, 193, 173, 48, 118, 247, 57, 3, 28, 19, 215, 203, 241, 140, 158, 34, 92, 107, 68, 214, 71, 149, 153, 158, 105, 192, 33, 175, 123, 224, 166, 214, 239, 37, 139, 53, 107, 7, 222, 93, 64, 115, 143, 158, 80, 178, 128, 255, 6, 227, 104, 128, 23, 230, 72, 222, 57, 140, 224, 33, 227, 30 } });
        }
    }
}
