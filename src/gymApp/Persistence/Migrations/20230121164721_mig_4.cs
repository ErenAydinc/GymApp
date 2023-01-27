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
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "operationclaims",
                columns: new[] { "Id", "FirstName" },
                values: new object[,]
                {
                    { 26, "Movement.Admin" },
                    { 27, "Movement.Create" },
                    { 28, "Movement.Update" },
                    { 29, "Movement.Delete" },
                    { 30, "Movement.Read" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 24, 93, 136, 153, 150, 236, 101, 88, 83, 182, 95, 204, 63, 240, 195, 203, 222, 236, 181, 57, 59, 155, 224, 107, 63, 208, 53, 18, 66, 153, 1, 75, 236, 241, 212, 181, 26, 253, 123, 120, 219, 243, 254, 217, 43, 247, 156, 146, 58, 17, 186, 250, 143, 217, 202, 176, 62, 132, 103, 40, 55, 211, 3 }, new byte[] { 66, 142, 107, 234, 1, 97, 47, 25, 161, 77, 217, 162, 134, 64, 3, 157, 90, 229, 82, 11, 5, 197, 150, 231, 156, 245, 79, 127, 29, 164, 113, 95, 109, 207, 69, 91, 207, 35, 106, 120, 47, 222, 28, 137, 40, 210, 72, 143, 65, 236, 142, 35, 111, 159, 139, 36, 231, 149, 52, 61, 31, 129, 7, 165, 71, 166, 91, 6, 62, 2, 1, 189, 231, 92, 174, 66, 146, 147, 240, 20, 134, 173, 40, 58, 30, 237, 124, 84, 49, 0, 62, 155, 140, 224, 22, 69, 157, 45, 237, 77, 177, 222, 241, 20, 38, 51, 98, 33, 162, 167, 142, 169, 194, 205, 250, 164, 87, 237, 199, 165, 155, 45, 238, 231, 92, 14, 243, 5 } });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 26, 26, 4 },
                    { 27, 27, 4 },
                    { 28, 28, 4 },
                    { 29, 29, 4 },
                    { 30, 30, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 97, 171, 89, 71, 204, 43, 25, 18, 99, 96, 216, 133, 160, 153, 64, 170, 139, 146, 203, 106, 218, 9, 172, 112, 99, 153, 76, 220, 127, 7, 223, 86, 109, 236, 109, 171, 43, 116, 124, 2, 151, 231, 12, 205, 236, 255, 9, 223, 98, 157, 134, 160, 104, 188, 199, 158, 200, 153, 209, 148, 138, 179, 69, 10 }, new byte[] { 210, 184, 75, 8, 48, 167, 174, 201, 189, 111, 36, 40, 142, 221, 134, 131, 138, 38, 137, 22, 169, 171, 74, 217, 97, 241, 251, 146, 107, 55, 174, 67, 16, 76, 26, 2, 63, 241, 45, 8, 124, 82, 228, 161, 101, 167, 103, 250, 183, 22, 244, 11, 93, 217, 137, 222, 27, 12, 187, 79, 220, 30, 34, 223, 70, 80, 36, 124, 112, 140, 156, 50, 69, 84, 177, 236, 73, 247, 229, 212, 96, 163, 36, 82, 84, 158, 131, 151, 165, 158, 179, 224, 95, 238, 190, 136, 24, 9, 117, 71, 58, 177, 140, 71, 237, 214, 198, 78, 222, 237, 87, 177, 53, 221, 73, 148, 79, 214, 196, 99, 204, 140, 199, 228, 197, 115, 48, 216 } });
        }
    }
}
