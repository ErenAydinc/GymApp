using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Movements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movements",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 242, 152, 21, 24, 29, 27, 188, 139, 172, 124, 63, 175, 222, 62, 37, 40, 44, 237, 66, 142, 178, 216, 44, 72, 61, 170, 131, 198, 167, 16, 64, 88, 46, 82, 101, 58, 30, 118, 56, 67, 63, 180, 112, 99, 47, 116, 152, 210, 85, 101, 88, 177, 46, 201, 78, 177, 157, 189, 115, 215, 137, 142, 58 }, new byte[] { 177, 143, 192, 125, 156, 142, 147, 225, 189, 15, 126, 173, 180, 161, 87, 130, 204, 226, 19, 203, 224, 255, 40, 151, 60, 28, 25, 7, 210, 190, 227, 175, 115, 179, 118, 221, 186, 202, 248, 207, 116, 125, 210, 160, 69, 88, 68, 9, 127, 100, 113, 223, 158, 113, 174, 68, 150, 254, 112, 83, 176, 232, 55, 94, 130, 86, 81, 166, 136, 91, 154, 146, 235, 173, 38, 144, 184, 123, 72, 54, 182, 157, 79, 97, 20, 71, 179, 17, 40, 64, 99, 166, 194, 252, 158, 171, 110, 90, 23, 203, 110, 253, 244, 236, 168, 77, 122, 255, 163, 116, 98, 245, 65, 205, 72, 217, 28, 190, 12, 177, 75, 236, 31, 134, 191, 88, 212, 74 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movements");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 93, 242, 216, 174, 54, 184, 215, 215, 201, 224, 93, 224, 220, 86, 4, 65, 217, 171, 248, 22, 173, 156, 147, 167, 171, 96, 15, 198, 39, 117, 229, 247, 130, 223, 94, 191, 237, 46, 75, 95, 223, 113, 87, 123, 91, 142, 62, 197, 137, 169, 132, 225, 1, 149, 171, 145, 123, 194, 123, 130, 232, 149, 20, 43 }, new byte[] { 15, 59, 29, 98, 193, 145, 120, 158, 69, 41, 41, 166, 52, 196, 24, 93, 200, 72, 35, 99, 97, 1, 69, 64, 144, 170, 198, 215, 0, 44, 124, 25, 64, 150, 121, 244, 31, 255, 217, 52, 240, 19, 199, 17, 20, 247, 249, 69, 56, 231, 23, 118, 89, 68, 17, 34, 154, 124, 77, 20, 227, 163, 16, 190, 107, 154, 198, 175, 129, 11, 25, 131, 196, 129, 68, 126, 216, 178, 52, 29, 239, 87, 252, 227, 57, 81, 79, 199, 140, 31, 108, 10, 141, 41, 214, 35, 96, 173, 217, 148, 54, 10, 123, 104, 10, 214, 23, 225, 222, 217, 158, 102, 219, 193, 102, 37, 43, 191, 98, 196, 131, 185, 125, 20, 128, 106, 250, 46 } });
        }
    }
}
