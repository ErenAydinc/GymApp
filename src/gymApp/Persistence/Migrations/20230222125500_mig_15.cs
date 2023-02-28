using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersMovementSetAndRepetitions");

            migrationBuilder.AddColumn<int>(
                name: "RepetitionNumber",
                table: "UsersMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SetNumber",
                table: "UsersMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 152, 65, 74, 236, 101, 241, 12, 126, 77, 26, 123, 129, 105, 86, 13, 140, 184, 189, 157, 95, 251, 90, 12, 130, 55, 110, 189, 49, 107, 97, 210, 26, 19, 143, 70, 151, 8, 238, 96, 250, 74, 76, 113, 167, 114, 170, 129, 166, 218, 132, 199, 70, 51, 36, 213, 93, 137, 38, 178, 226, 242, 177, 29 }, new byte[] { 139, 79, 45, 248, 209, 154, 236, 107, 45, 178, 146, 244, 44, 71, 24, 131, 187, 70, 85, 169, 244, 5, 207, 150, 205, 22, 16, 170, 9, 139, 131, 50, 139, 172, 125, 43, 133, 84, 140, 146, 131, 23, 238, 94, 128, 112, 72, 76, 253, 162, 210, 67, 126, 140, 252, 190, 185, 243, 130, 10, 172, 159, 219, 134, 247, 147, 88, 129, 150, 42, 144, 34, 125, 41, 220, 148, 16, 85, 171, 56, 210, 210, 21, 28, 10, 237, 62, 107, 26, 222, 220, 205, 73, 114, 183, 181, 241, 47, 247, 28, 151, 140, 140, 73, 55, 175, 113, 164, 123, 253, 221, 48, 216, 197, 142, 242, 197, 34, 61, 231, 98, 70, 20, 232, 52, 235, 58, 1 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepetitionNumber",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "SetNumber",
                table: "UsersMovements");

            migrationBuilder.CreateTable(
                name: "UsersMovementSetAndRepetitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementId = table.Column<int>(type: "int", nullable: false),
                    RepetitionNumber = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { new byte[] { 144, 56, 197, 31, 109, 41, 148, 173, 203, 126, 197, 186, 167, 80, 117, 155, 7, 168, 178, 241, 118, 49, 216, 7, 38, 250, 91, 36, 223, 131, 155, 142, 75, 23, 71, 7, 174, 52, 241, 139, 195, 56, 119, 231, 208, 212, 233, 185, 181, 146, 110, 156, 185, 67, 108, 132, 50, 216, 247, 96, 118, 160, 149, 136 }, new byte[] { 49, 174, 113, 146, 163, 170, 3, 200, 86, 165, 124, 165, 180, 103, 6, 121, 104, 47, 177, 73, 39, 68, 24, 201, 232, 198, 215, 154, 2, 51, 180, 255, 93, 13, 246, 105, 49, 234, 134, 28, 89, 9, 62, 171, 144, 22, 177, 154, 208, 247, 102, 80, 31, 103, 127, 123, 226, 124, 98, 229, 56, 167, 124, 27, 229, 230, 181, 60, 196, 20, 37, 79, 227, 45, 78, 51, 86, 90, 50, 25, 18, 198, 13, 94, 241, 50, 139, 11, 119, 15, 170, 187, 206, 37, 139, 19, 247, 203, 195, 255, 141, 70, 223, 115, 58, 231, 5, 200, 153, 14, 112, 66, 60, 63, 25, 212, 0, 98, 145, 80, 94, 169, 189, 177, 11, 212, 222, 104 } });
        }
    }
}
