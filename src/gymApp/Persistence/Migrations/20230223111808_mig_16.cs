using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirstName",
                value: "System Admin");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "Gym Admin");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "FirstName",
                value: "Personal Trainer");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 14, 153, 98, 240, 48, 134, 203, 45, 147, 233, 126, 32, 79, 235, 219, 181, 105, 223, 154, 134, 124, 196, 92, 172, 119, 57, 107, 18, 130, 49, 98, 146, 254, 116, 87, 219, 43, 12, 14, 101, 235, 76, 243, 195, 114, 127, 237, 67, 190, 29, 148, 31, 119, 133, 170, 150, 103, 100, 36, 9, 173, 56, 219, 12 }, new byte[] { 55, 123, 221, 33, 177, 127, 133, 66, 71, 7, 190, 234, 95, 135, 196, 86, 208, 18, 42, 51, 248, 206, 78, 146, 161, 251, 129, 10, 200, 209, 151, 14, 190, 242, 44, 35, 72, 206, 198, 188, 168, 53, 157, 139, 123, 155, 66, 15, 150, 147, 243, 117, 214, 137, 56, 66, 202, 19, 251, 221, 161, 35, 92, 42, 99, 200, 162, 140, 1, 162, 172, 111, 39, 15, 250, 239, 131, 27, 253, 144, 238, 148, 1, 48, 243, 15, 102, 122, 30, 132, 190, 27, 209, 26, 6, 191, 44, 34, 38, 77, 144, 117, 37, 241, 25, 139, 32, 26, 9, 21, 188, 121, 163, 82, 56, 245, 3, 162, 202, 127, 199, 49, 154, 61, 33, 28, 116, 30 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new byte[] { 134, 152, 65, 74, 236, 101, 241, 12, 126, 77, 26, 123, 129, 105, 86, 13, 140, 184, 189, 157, 95, 251, 90, 12, 130, 55, 110, 189, 49, 107, 97, 210, 26, 19, 143, 70, 151, 8, 238, 96, 250, 74, 76, 113, 167, 114, 170, 129, 166, 218, 132, 199, 70, 51, 36, 213, 93, 137, 38, 178, 226, 242, 177, 29 }, new byte[] { 139, 79, 45, 248, 209, 154, 236, 107, 45, 178, 146, 244, 44, 71, 24, 131, 187, 70, 85, 169, 244, 5, 207, 150, 205, 22, 16, 170, 9, 139, 131, 50, 139, 172, 125, 43, 133, 84, 140, 146, 131, 23, 238, 94, 128, 112, 72, 76, 253, 162, 210, 67, 126, 140, 252, 190, 185, 243, 130, 10, 172, 159, 219, 134, 247, 147, 88, 129, 150, 42, 144, 34, 125, 41, 220, 148, 16, 85, 171, 56, 210, 210, 21, 28, 10, 237, 62, 107, 26, 222, 220, 205, 73, 114, 183, 181, 241, 47, 247, 28, 151, 140, 140, 73, 55, 175, 113, 164, 123, 253, 221, 48, 216, 197, 142, 242, 197, 34, 61, 231, 98, 70, 20, 232, 52, 235, 58, 1 } });
        }
    }
}
