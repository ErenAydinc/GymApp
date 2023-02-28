using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "operationclaims",
                columns: new[] { "Id", "FirstName" },
                values: new object[,]
                {
                    { 56, "Category.Admin" },
                    { 57, "Category.Create" },
                    { 58, "Category.Update" },
                    { 59, "Category.Delete" },
                    { 60, "Category.Read" },
                    { 61, "UsersMovementSetAndRepetitionNumber.Admin" },
                    { 62, "UsersMovementSetAndRepetitionNumber.Create" },
                    { 63, "UsersMovementSetAndRepetitionNumber.Update" },
                    { 64, "UsersMovementSetAndRepetitionNumber.Delete" },
                    { 65, "UsersMovementSetAndRepetitionNumber.Read" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 93, 242, 216, 174, 54, 184, 215, 215, 201, 224, 93, 224, 220, 86, 4, 65, 217, 171, 248, 22, 173, 156, 147, 167, 171, 96, 15, 198, 39, 117, 229, 247, 130, 223, 94, 191, 237, 46, 75, 95, 223, 113, 87, 123, 91, 142, 62, 197, 137, 169, 132, 225, 1, 149, 171, 145, 123, 194, 123, 130, 232, 149, 20, 43 }, new byte[] { 15, 59, 29, 98, 193, 145, 120, 158, 69, 41, 41, 166, 52, 196, 24, 93, 200, 72, 35, 99, 97, 1, 69, 64, 144, 170, 198, 215, 0, 44, 124, 25, 64, 150, 121, 244, 31, 255, 217, 52, 240, 19, 199, 17, 20, 247, 249, 69, 56, 231, 23, 118, 89, 68, 17, 34, 154, 124, 77, 20, 227, 163, 16, 190, 107, 154, 198, 175, 129, 11, 25, 131, 196, 129, 68, 126, 216, 178, 52, 29, 239, 87, 252, 227, 57, 81, 79, 199, 140, 31, 108, 10, 141, 41, 214, 35, 96, 173, 217, 148, 54, 10, 123, 104, 10, 214, 23, 225, 222, 217, 158, 102, 219, 193, 102, 37, 43, 191, 98, 196, 131, 185, 125, 20, 128, 106, 250, 46 } });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 56, 56, 1 },
                    { 57, 57, 1 },
                    { 58, 58, 1 },
                    { 59, 59, 1 },
                    { 60, 60, 1 },
                    { 61, 61, 1 },
                    { 62, 62, 1 },
                    { 63, 63, 1 },
                    { 64, 64, 1 },
                    { 65, 65, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 209, 7, 78, 216, 149, 5, 45, 43, 231, 125, 219, 83, 194, 47, 1, 23, 14, 135, 228, 22, 120, 116, 75, 78, 179, 192, 59, 53, 147, 8, 224, 189, 63, 214, 62, 125, 46, 42, 106, 202, 189, 209, 83, 173, 73, 169, 66, 13, 4, 169, 53, 111, 26, 214, 73, 12, 56, 28, 23, 180, 206, 170, 36, 238 }, new byte[] { 211, 30, 51, 239, 121, 13, 18, 114, 204, 226, 123, 142, 81, 129, 241, 138, 206, 42, 50, 72, 95, 207, 132, 205, 73, 172, 249, 58, 169, 47, 73, 178, 1, 177, 196, 117, 134, 8, 25, 176, 216, 100, 60, 248, 53, 127, 46, 248, 99, 6, 255, 211, 19, 49, 138, 243, 27, 91, 29, 114, 239, 97, 151, 217, 232, 105, 78, 163, 63, 106, 167, 214, 242, 21, 157, 14, 59, 33, 173, 229, 49, 133, 181, 155, 1, 118, 192, 65, 234, 77, 189, 32, 138, 1, 147, 58, 182, 197, 9, 247, 69, 12, 127, 238, 196, 160, 156, 162, 10, 228, 212, 11, 49, 154, 72, 246, 21, 154, 205, 96, 214, 190, 52, 85, 181, 181, 164, 201 } });
        }
    }
}
