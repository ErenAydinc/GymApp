using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "operationclaims",
                columns: new[] { "Id", "FirstName" },
                values: new object[,]
                {
                    { 41, "PersonalTrainer.Admin" },
                    { 42, "PersonalTrainer.Create" },
                    { 43, "PersonalTrainer.Update" },
                    { 44, "PersonalTrainer.Delete" },
                    { 45, "PersonalTrainer.Read" },
                    { 46, "PersonalTrainerStudent.Admin" },
                    { 47, "PersonalTrainerStudent.Create" },
                    { 48, "PersonalTrainerStudent.Update" },
                    { 49, "PersonalTrainerStudent.Delete" },
                    { 50, "PersonalTrainerStudent.Read" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 15, 210, 146, 28, 221, 212, 201, 192, 105, 31, 23, 235, 65, 78, 129, 218, 234, 190, 227, 87, 255, 45, 248, 19, 147, 129, 144, 168, 178, 38, 191, 154, 7, 218, 202, 74, 140, 184, 235, 220, 51, 107, 51, 161, 237, 162, 177, 142, 166, 236, 246, 44, 107, 180, 155, 35, 136, 190, 166, 163, 20, 9, 206, 28 }, new byte[] { 132, 203, 230, 123, 114, 71, 247, 41, 11, 74, 188, 230, 200, 207, 30, 12, 128, 58, 250, 131, 25, 6, 156, 1, 112, 89, 159, 153, 127, 101, 75, 248, 197, 242, 221, 237, 245, 56, 59, 133, 47, 239, 161, 11, 225, 185, 242, 253, 96, 140, 244, 172, 210, 180, 94, 48, 245, 182, 107, 187, 44, 96, 64, 230, 17, 81, 19, 196, 45, 138, 173, 89, 210, 253, 205, 47, 178, 123, 182, 227, 46, 16, 241, 51, 40, 173, 82, 241, 107, 6, 102, 11, 42, 99, 172, 89, 242, 4, 111, 204, 75, 69, 161, 171, 178, 245, 230, 116, 113, 114, 110, 87, 196, 92, 43, 120, 169, 238, 253, 156, 0, 57, 245, 71, 197, 139, 146, 11 } });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 41, 41, 1 },
                    { 42, 42, 1 },
                    { 43, 43, 1 },
                    { 44, 44, 1 },
                    { 45, 45, 1 },
                    { 46, 46, 1 },
                    { 47, 47, 1 },
                    { 48, 48, 1 },
                    { 49, 49, 1 },
                    { 50, 50, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "useroperationclaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 224, 160, 231, 63, 61, 180, 181, 54, 109, 78, 107, 152, 132, 167, 33, 227, 61, 251, 146, 220, 115, 83, 196, 33, 166, 214, 5, 105, 125, 164, 246, 160, 225, 250, 8, 48, 254, 232, 26, 122, 87, 206, 64, 205, 117, 92, 211, 250, 2, 236, 43, 184, 113, 114, 115, 2, 141, 241, 149, 54, 244, 242, 125 }, new byte[] { 163, 76, 88, 252, 0, 102, 232, 248, 220, 94, 148, 129, 156, 177, 52, 146, 103, 176, 20, 123, 190, 137, 248, 78, 150, 42, 188, 237, 78, 70, 242, 69, 240, 200, 12, 7, 62, 206, 170, 147, 241, 14, 176, 80, 49, 138, 95, 242, 233, 112, 196, 135, 233, 218, 195, 137, 137, 234, 56, 24, 183, 182, 58, 8, 193, 57, 82, 134, 195, 164, 28, 71, 192, 182, 91, 188, 89, 21, 198, 201, 139, 69, 140, 190, 56, 54, 233, 31, 10, 96, 57, 188, 34, 183, 54, 75, 223, 61, 112, 52, 5, 108, 98, 8, 197, 168, 127, 226, 222, 248, 157, 207, 117, 174, 100, 206, 210, 112, 214, 98, 35, 111, 77, 209, 179, 47, 5, 25 } });
        }
    }
}
