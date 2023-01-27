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
                    { 31, "MovementImageUploadMapping.Admin" },
                    { 32, "MovementImageUploadMapping.Create" },
                    { 33, "MovementImageUploadMapping.Update" },
                    { 34, "MovementImageUploadMapping.Delete" },
                    { 35, "MovementImageUploadMapping.Read" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 109, 82, 237, 232, 252, 174, 56, 145, 70, 248, 118, 146, 167, 17, 0, 41, 96, 18, 86, 40, 102, 167, 27, 229, 175, 208, 68, 48, 227, 104, 245, 117, 25, 102, 118, 115, 146, 18, 204, 213, 17, 130, 24, 149, 157, 138, 44, 195, 134, 168, 174, 216, 182, 254, 137, 219, 246, 255, 60, 116, 8, 165, 68, 123 }, new byte[] { 79, 69, 34, 170, 90, 147, 107, 255, 90, 182, 83, 235, 44, 94, 221, 175, 42, 118, 170, 143, 112, 151, 48, 123, 4, 37, 150, 74, 11, 168, 162, 127, 123, 137, 81, 141, 174, 67, 114, 75, 236, 141, 146, 7, 55, 155, 166, 218, 150, 172, 54, 10, 61, 65, 79, 54, 181, 146, 146, 142, 67, 42, 162, 9, 131, 16, 12, 86, 13, 130, 157, 94, 88, 153, 201, 247, 196, 136, 197, 141, 193, 118, 232, 230, 152, 75, 125, 239, 56, 204, 212, 103, 178, 223, 145, 93, 143, 13, 141, 51, 25, 119, 236, 8, 160, 245, 145, 164, 138, 60, 111, 90, 51, 93, 54, 99, 220, 159, 165, 83, 182, 250, 191, 199, 56, 143, 202, 202 } });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 31, 31, 4 },
                    { 32, 32, 4 },
                    { 33, 33, 4 },
                    { 34, 34, 4 },
                    { 35, 35, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 108, 188, 206, 141, 230, 4, 126, 72, 250, 116, 166, 112, 180, 220, 109, 28, 107, 125, 51, 222, 7, 84, 0, 202, 21, 35, 14, 129, 186, 234, 236, 59, 79, 151, 17, 232, 210, 84, 176, 74, 3, 42, 125, 194, 250, 150, 99, 238, 37, 22, 211, 105, 185, 201, 127, 72, 198, 220, 44, 216, 196, 238, 155, 134 }, new byte[] { 244, 213, 250, 251, 168, 254, 95, 223, 187, 103, 134, 7, 37, 158, 169, 148, 178, 201, 234, 202, 154, 22, 27, 161, 226, 130, 206, 87, 27, 230, 147, 27, 57, 94, 162, 194, 97, 211, 237, 57, 5, 43, 62, 165, 83, 118, 117, 126, 249, 214, 65, 142, 129, 36, 166, 168, 107, 199, 240, 153, 6, 212, 163, 250, 198, 136, 247, 222, 81, 224, 26, 25, 247, 17, 95, 224, 120, 71, 244, 70, 248, 194, 2, 105, 125, 83, 178, 77, 247, 140, 73, 146, 58, 36, 41, 126, 174, 207, 54, 9, 148, 120, 47, 225, 225, 39, 110, 0, 61, 42, 167, 179, 23, 22, 124, 151, 241, 250, 10, 53, 250, 15, 162, 12, 165, 127, 2, 22 } });
        }
    }
}
