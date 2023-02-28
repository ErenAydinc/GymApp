using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "operationclaims",
                columns: new[] { "Id", "FirstName" },
                values: new object[,]
                {
                    { 51, "UsersMovement.Admin" },
                    { 52, "UsersMovement.Create" },
                    { 53, "UsersMovement.Update" },
                    { 54, "UsersMovement.Delete" },
                    { 55, "UsersMovement.Read" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 182, 244, 212, 137, 43, 78, 36, 155, 40, 154, 211, 12, 78, 164, 201, 8, 120, 226, 57, 143, 230, 240, 81, 21, 32, 78, 226, 186, 47, 112, 174, 49, 242, 8, 137, 31, 194, 84, 137, 211, 231, 22, 195, 63, 130, 223, 129, 155, 66, 204, 9, 190, 108, 23, 75, 218, 170, 33, 140, 88, 232, 146, 103, 47 }, new byte[] { 74, 184, 63, 162, 162, 231, 122, 84, 89, 102, 215, 246, 26, 134, 35, 20, 74, 32, 99, 73, 65, 185, 126, 107, 32, 229, 74, 242, 106, 255, 119, 62, 68, 74, 200, 183, 144, 209, 51, 244, 175, 70, 128, 253, 24, 2, 165, 122, 20, 232, 25, 197, 62, 229, 169, 155, 205, 65, 241, 231, 182, 84, 28, 250, 1, 152, 223, 155, 136, 17, 246, 243, 229, 223, 18, 33, 162, 195, 148, 115, 96, 1, 212, 75, 173, 182, 82, 215, 45, 92, 248, 85, 152, 71, 228, 246, 103, 23, 142, 143, 86, 247, 125, 178, 246, 119, 165, 70, 91, 17, 221, 101, 140, 167, 69, 159, 158, 13, 81, 147, 206, 119, 179, 127, 102, 45, 211, 209 } });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 51, 51, 1 },
                    { 52, 52, 1 },
                    { 53, 53, 1 },
                    { 54, 54, 1 },
                    { 55, 55, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 31, 79, 111, 110, 81, 206, 242, 252, 202, 248, 5, 4, 182, 253, 123, 45, 8, 227, 239, 88, 185, 128, 36, 188, 48, 55, 131, 169, 66, 60, 217, 235, 116, 174, 95, 139, 42, 214, 52, 25, 113, 28, 150, 225, 31, 90, 131, 221, 160, 83, 247, 142, 84, 195, 78, 238, 156, 100, 126, 207, 252, 76, 212, 58 }, new byte[] { 105, 75, 81, 238, 79, 161, 143, 92, 34, 46, 122, 212, 87, 12, 143, 170, 250, 113, 235, 229, 9, 162, 152, 248, 159, 101, 63, 192, 163, 196, 46, 42, 82, 202, 212, 77, 49, 220, 117, 174, 165, 80, 83, 1, 59, 119, 13, 1, 242, 82, 169, 27, 229, 97, 126, 111, 199, 105, 195, 97, 161, 248, 96, 100, 26, 219, 205, 201, 159, 193, 136, 242, 89, 215, 26, 13, 9, 18, 23, 117, 207, 209, 186, 99, 250, 41, 197, 174, 24, 20, 234, 27, 247, 171, 3, 245, 54, 75, 26, 39, 100, 108, 168, 236, 146, 61, 184, 69, 168, 97, 62, 181, 47, 113, 244, 251, 225, 213, 114, 190, 106, 29, 99, 251, 53, 212, 94, 185 } });
        }
    }
}
