using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalTrainers");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersMovementSetAndRepetitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovementId = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    RepetitionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMovementSetAndRepetitions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 209, 7, 78, 216, 149, 5, 45, 43, 231, 125, 219, 83, 194, 47, 1, 23, 14, 135, 228, 22, 120, 116, 75, 78, 179, 192, 59, 53, 147, 8, 224, 189, 63, 214, 62, 125, 46, 42, 106, 202, 189, 209, 83, 173, 73, 169, 66, 13, 4, 169, 53, 111, 26, 214, 73, 12, 56, 28, 23, 180, 206, 170, 36, 238 }, new byte[] { 211, 30, 51, 239, 121, 13, 18, 114, 204, 226, 123, 142, 81, 129, 241, 138, 206, 42, 50, 72, 95, 207, 132, 205, 73, 172, 249, 58, 169, 47, 73, 178, 1, 177, 196, 117, 134, 8, 25, 176, 216, 100, 60, 248, 53, 127, 46, 248, 99, 6, 255, 211, 19, 49, 138, 243, 27, 91, 29, 114, 239, 97, 151, 217, 232, 105, 78, 163, 63, 106, 167, 214, 242, 21, 157, 14, 59, 33, 173, 229, 49, 133, 181, 155, 1, 118, 192, 65, 234, 77, 189, 32, 138, 1, 147, 58, 182, 197, 9, 247, 69, 12, 127, 238, 196, 160, 156, 162, 10, 228, 212, 11, 49, 154, 72, 246, 21, 154, 205, 96, 214, 190, 52, 85, 181, 181, 164, 201 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UsersMovementSetAndRepetitions");

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
                values: new object[] { new byte[] { 252, 159, 176, 119, 183, 104, 123, 183, 247, 110, 104, 197, 7, 104, 184, 159, 7, 98, 4, 129, 121, 236, 75, 140, 71, 134, 138, 60, 246, 216, 215, 174, 111, 119, 50, 142, 186, 203, 101, 212, 183, 204, 155, 184, 239, 224, 223, 155, 185, 37, 34, 152, 150, 76, 242, 201, 28, 51, 198, 195, 123, 207, 222, 87 }, new byte[] { 124, 184, 2, 251, 79, 221, 189, 159, 224, 20, 114, 18, 251, 194, 84, 2, 111, 58, 6, 114, 138, 169, 177, 249, 181, 138, 139, 182, 217, 167, 128, 71, 211, 16, 112, 220, 68, 204, 171, 225, 180, 71, 176, 9, 79, 20, 231, 181, 196, 77, 221, 233, 190, 64, 127, 222, 161, 117, 81, 194, 111, 67, 176, 68, 199, 14, 16, 11, 122, 93, 42, 29, 181, 127, 100, 233, 167, 1, 248, 48, 81, 170, 70, 87, 247, 123, 137, 199, 116, 105, 46, 50, 118, 34, 223, 19, 165, 212, 168, 41, 231, 235, 22, 37, 214, 110, 99, 114, 32, 210, 226, 222, 255, 215, 210, 36, 34, 130, 176, 32, 182, 161, 129, 177, 4, 213, 242, 121 } });
        }
    }
}
