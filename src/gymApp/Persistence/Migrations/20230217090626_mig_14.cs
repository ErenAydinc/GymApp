using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirstName",
                value: "User.Manage");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "OperationClaimAdmin.Manage");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "FirstName",
                value: "UserOperationClaimAdmin.Manage");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 144, 56, 197, 31, 109, 41, 148, 173, 203, 126, 197, 186, 167, 80, 117, 155, 7, 168, 178, 241, 118, 49, 216, 7, 38, 250, 91, 36, 223, 131, 155, 142, 75, 23, 71, 7, 174, 52, 241, 139, 195, 56, 119, 231, 208, 212, 233, 185, 181, 146, 110, 156, 185, 67, 108, 132, 50, 216, 247, 96, 118, 160, 149, 136 }, new byte[] { 49, 174, 113, 146, 163, 170, 3, 200, 86, 165, 124, 165, 180, 103, 6, 121, 104, 47, 177, 73, 39, 68, 24, 201, 232, 198, 215, 154, 2, 51, 180, 255, 93, 13, 246, 105, 49, 234, 134, 28, 89, 9, 62, 171, 144, 22, 177, 154, 208, 247, 102, 80, 31, 103, 127, 123, 226, 124, 98, 229, 56, 167, 124, 27, 229, 230, 181, 60, 196, 20, 37, 79, 227, 45, 78, 51, 86, 90, 50, 25, 18, 198, 13, 94, 241, 50, 139, 11, 119, 15, 170, 187, 206, 37, 139, 19, 247, 203, 195, 255, 141, 70, 223, 115, 58, 231, 5, 200, 153, 14, 112, 66, 60, 63, 25, 212, 0, 98, 145, 80, 94, 169, 189, 177, 11, 212, 222, 104 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirstName",
                value: "User.Admin");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "OperationClaimAdmin.Admin");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "FirstName",
                value: "UserOperationClaimAdmin.Admin");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 196, 189, 250, 50, 198, 100, 69, 205, 36, 96, 241, 98, 224, 103, 64, 60, 206, 9, 154, 33, 80, 182, 209, 213, 18, 138, 185, 248, 213, 83, 138, 59, 126, 0, 156, 102, 98, 206, 232, 96, 170, 59, 153, 37, 81, 83, 201, 87, 67, 168, 121, 54, 232, 26, 224, 143, 211, 110, 55, 46, 44, 104, 228, 243 }, new byte[] { 223, 49, 104, 135, 235, 81, 233, 201, 77, 20, 70, 67, 200, 251, 43, 108, 107, 153, 214, 88, 141, 134, 91, 39, 45, 252, 57, 184, 240, 133, 203, 163, 130, 57, 132, 106, 195, 108, 227, 77, 68, 5, 217, 178, 63, 81, 184, 111, 39, 48, 91, 249, 144, 115, 246, 112, 47, 12, 92, 78, 11, 179, 117, 214, 45, 40, 48, 11, 76, 145, 60, 5, 106, 15, 106, 97, 0, 86, 55, 241, 253, 90, 183, 16, 239, 77, 142, 18, 201, 139, 21, 69, 9, 236, 127, 138, 174, 249, 19, 186, 47, 89, 156, 94, 72, 178, 67, 91, 147, 100, 74, 178, 51, 240, 7, 207, 174, 153, 82, 41, 180, 213, 101, 12, 22, 137, 12, 63 } });
        }
    }
}
