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
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ImageUploads",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovementImageUploadMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovementId = table.Column<int>(type: "int", nullable: false),
                    ImageUploadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementImageUploadMappings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 108, 188, 206, 141, 230, 4, 126, 72, 250, 116, 166, 112, 180, 220, 109, 28, 107, 125, 51, 222, 7, 84, 0, 202, 21, 35, 14, 129, 186, 234, 236, 59, 79, 151, 17, 232, 210, 84, 176, 74, 3, 42, 125, 194, 250, 150, 99, 238, 37, 22, 211, 105, 185, 201, 127, 72, 198, 220, 44, 216, 196, 238, 155, 134 }, new byte[] { 244, 213, 250, 251, 168, 254, 95, 223, 187, 103, 134, 7, 37, 158, 169, 148, 178, 201, 234, 202, 154, 22, 27, 161, 226, 130, 206, 87, 27, 230, 147, 27, 57, 94, 162, 194, 97, 211, 237, 57, 5, 43, 62, 165, 83, 118, 117, 126, 249, 214, 65, 142, 129, 36, 166, 168, 107, 199, 240, 153, 6, 212, 163, 250, 198, 136, 247, 222, 81, 224, 26, 25, 247, 17, 95, 224, 120, 71, 244, 70, 248, 194, 2, 105, 125, 83, 178, 77, 247, 140, 73, 146, 58, 36, 41, 126, 174, 207, 54, 9, 148, 120, 47, 225, 225, 39, 110, 0, 61, 42, 167, 179, 23, 22, 124, 151, 241, 250, 10, 53, 250, 15, 162, 12, 165, 127, 2, 22 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementImageUploadMappings");

            migrationBuilder.UpdateData(
                table: "ImageUploads",
                keyColumn: "ImagePath",
                keyValue: null,
                column: "ImagePath",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ImageUploads",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 139, 222, 232, 43, 128, 168, 137, 8, 64, 137, 28, 133, 193, 16, 134, 254, 15, 143, 230, 118, 198, 224, 146, 243, 242, 12, 19, 144, 11, 133, 44, 12, 233, 172, 231, 60, 205, 253, 190, 207, 201, 116, 99, 157, 34, 64, 2, 39, 26, 210, 123, 30, 129, 241, 107, 18, 144, 161, 48, 35, 172, 110, 126, 20 }, new byte[] { 83, 178, 59, 6, 124, 29, 230, 43, 39, 193, 117, 179, 70, 228, 0, 96, 68, 56, 221, 211, 43, 11, 72, 148, 91, 127, 206, 242, 107, 197, 226, 125, 62, 1, 242, 120, 72, 225, 145, 104, 176, 152, 136, 171, 34, 201, 186, 247, 63, 28, 207, 214, 143, 23, 143, 192, 41, 113, 44, 208, 86, 108, 210, 51, 17, 146, 86, 19, 31, 38, 169, 64, 182, 88, 145, 74, 241, 61, 218, 253, 69, 25, 246, 55, 240, 130, 126, 199, 174, 208, 234, 207, 248, 36, 19, 28, 90, 23, 162, 213, 117, 159, 125, 96, 83, 78, 41, 210, 231, 156, 100, 149, 49, 30, 71, 75, 9, 70, 49, 94, 213, 243, 172, 245, 133, 207, 218, 162 } });
        }
    }
}
