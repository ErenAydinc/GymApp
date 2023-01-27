using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageUploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUploads", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 139, 222, 232, 43, 128, 168, 137, 8, 64, 137, 28, 133, 193, 16, 134, 254, 15, 143, 230, 118, 198, 224, 146, 243, 242, 12, 19, 144, 11, 133, 44, 12, 233, 172, 231, 60, 205, 253, 190, 207, 201, 116, 99, 157, 34, 64, 2, 39, 26, 210, 123, 30, 129, 241, 107, 18, 144, 161, 48, 35, 172, 110, 126, 20 }, new byte[] { 83, 178, 59, 6, 124, 29, 230, 43, 39, 193, 117, 179, 70, 228, 0, 96, 68, 56, 221, 211, 43, 11, 72, 148, 91, 127, 206, 242, 107, 197, 226, 125, 62, 1, 242, 120, 72, 225, 145, 104, 176, 152, 136, 171, 34, 201, 186, 247, 63, 28, 207, 214, 143, 23, 143, 192, 41, 113, 44, 208, 86, 108, 210, 51, 17, 146, 86, 19, 31, 38, 169, 64, 182, 88, 145, 74, 241, 61, 218, 253, 69, 25, 246, 55, 240, 130, 126, 199, 174, 208, 234, 207, 248, 36, 19, 28, 90, 23, 162, 213, 117, 159, 125, 96, 83, 78, 41, 210, 231, 156, 100, 149, 49, 30, 71, 75, 9, 70, 49, 94, 213, 243, 172, 245, 133, 207, 218, 162 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUploads");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 24, 93, 136, 153, 150, 236, 101, 88, 83, 182, 95, 204, 63, 240, 195, 203, 222, 236, 181, 57, 59, 155, 224, 107, 63, 208, 53, 18, 66, 153, 1, 75, 236, 241, 212, 181, 26, 253, 123, 120, 219, 243, 254, 217, 43, 247, 156, 146, 58, 17, 186, 250, 143, 217, 202, 176, 62, 132, 103, 40, 55, 211, 3 }, new byte[] { 66, 142, 107, 234, 1, 97, 47, 25, 161, 77, 217, 162, 134, 64, 3, 157, 90, 229, 82, 11, 5, 197, 150, 231, 156, 245, 79, 127, 29, 164, 113, 95, 109, 207, 69, 91, 207, 35, 106, 120, 47, 222, 28, 137, 40, 210, 72, 143, 65, 236, 142, 35, 111, 159, 139, 36, 231, 149, 52, 61, 31, 129, 7, 165, 71, 166, 91, 6, 62, 2, 1, 189, 231, 92, 174, 66, 146, 147, 240, 20, 134, 173, 40, 58, 30, 237, 124, 84, 49, 0, 62, 155, 140, 224, 22, 69, 157, 45, 237, 77, 177, 222, 241, 20, 38, 51, 98, 33, 162, 167, 142, 169, 194, 205, 250, 164, 87, 237, 199, 165, 155, 45, 238, 231, 92, 14, 243, 5 } });
        }
    }
}
