using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "operationclaims",
                columns: new[] { "Id", "FirstName" },
                values: new object[,]
                {
                    { 66, "User.Admin" },
                    { 67, "User.Create" },
                    { 68, "User.Update" },
                    { 69, "User.Delete" },
                    { 70, "User.Read" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 241, 152, 11, 152, 32, 251, 119, 136, 145, 173, 1, 246, 224, 67, 75, 220, 97, 76, 166, 250, 90, 251, 113, 36, 199, 235, 131, 186, 97, 252, 163, 79, 217, 210, 20, 55, 104, 198, 17, 182, 64, 72, 218, 23, 206, 239, 112, 137, 24, 6, 36, 185, 167, 70, 119, 177, 110, 92, 142, 120, 188, 203, 68, 60 }, new byte[] { 184, 13, 69, 101, 156, 252, 76, 31, 163, 57, 94, 15, 86, 64, 156, 13, 150, 162, 31, 217, 155, 144, 50, 229, 86, 97, 3, 193, 239, 58, 203, 167, 155, 254, 11, 203, 248, 53, 253, 151, 210, 44, 213, 194, 66, 104, 151, 243, 116, 199, 247, 1, 72, 46, 154, 222, 103, 38, 58, 41, 165, 73, 31, 242, 24, 79, 173, 15, 59, 132, 165, 239, 220, 236, 95, 119, 82, 160, 50, 138, 157, 221, 77, 251, 85, 235, 111, 139, 218, 79, 87, 246, 66, 44, 19, 44, 69, 86, 207, 18, 78, 209, 60, 136, 71, 36, 138, 191, 166, 87, 3, 188, 15, 97, 22, 227, 34, 122, 58, 237, 84, 133, 99, 43, 239, 167, 237, 7 } });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 66, 66, 1 },
                    { 67, 67, 1 },
                    { 68, 68, 1 },
                    { 69, 69, 1 },
                    { 70, 70, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 242, 152, 21, 24, 29, 27, 188, 139, 172, 124, 63, 175, 222, 62, 37, 40, 44, 237, 66, 142, 178, 216, 44, 72, 61, 170, 131, 198, 167, 16, 64, 88, 46, 82, 101, 58, 30, 118, 56, 67, 63, 180, 112, 99, 47, 116, 152, 210, 85, 101, 88, 177, 46, 201, 78, 177, 157, 189, 115, 215, 137, 142, 58 }, new byte[] { 177, 143, 192, 125, 156, 142, 147, 225, 189, 15, 126, 173, 180, 161, 87, 130, 204, 226, 19, 203, 224, 255, 40, 151, 60, 28, 25, 7, 210, 190, 227, 175, 115, 179, 118, 221, 186, 202, 248, 207, 116, 125, 210, 160, 69, 88, 68, 9, 127, 100, 113, 223, 158, 113, 174, 68, 150, 254, 112, 83, 176, 232, 55, 94, 130, 86, 81, 166, 136, 91, 154, 146, 235, 173, 38, 144, 184, 123, 72, 54, 182, 157, 79, 97, 20, 71, 179, 17, 40, 64, 99, 166, 194, 252, 158, 171, 110, 90, 23, 203, 110, 253, 244, 236, 168, 77, 122, 255, 163, 116, 98, 245, 65, 205, 72, 217, 28, 190, 12, 177, 75, 236, 31, 134, 191, 88, 212, 74 } });
        }
    }
}
