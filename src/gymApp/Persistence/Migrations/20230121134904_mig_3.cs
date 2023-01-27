using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 21,
                column: "FirstName",
                value: "UserMemberTypeMapping.Admin");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 22,
                column: "FirstName",
                value: "UserMemberTypeMapping.Create");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 23,
                column: "FirstName",
                value: "UserMemberTypeMapping.Update");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 24,
                column: "FirstName",
                value: "UserMemberTypeMapping.Delete");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 25,
                column: "FirstName",
                value: "UserMemberTypeMapping.Read");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 97, 171, 89, 71, 204, 43, 25, 18, 99, 96, 216, 133, 160, 153, 64, 170, 139, 146, 203, 106, 218, 9, 172, 112, 99, 153, 76, 220, 127, 7, 223, 86, 109, 236, 109, 171, 43, 116, 124, 2, 151, 231, 12, 205, 236, 255, 9, 223, 98, 157, 134, 160, 104, 188, 199, 158, 200, 153, 209, 148, 138, 179, 69, 10 }, new byte[] { 210, 184, 75, 8, 48, 167, 174, 201, 189, 111, 36, 40, 142, 221, 134, 131, 138, 38, 137, 22, 169, 171, 74, 217, 97, 241, 251, 146, 107, 55, 174, 67, 16, 76, 26, 2, 63, 241, 45, 8, 124, 82, 228, 161, 101, 167, 103, 250, 183, 22, 244, 11, 93, 217, 137, 222, 27, 12, 187, 79, 220, 30, 34, 223, 70, 80, 36, 124, 112, 140, 156, 50, 69, 84, 177, 236, 73, 247, 229, 212, 96, 163, 36, 82, 84, 158, 131, 151, 165, 158, 179, 224, 95, 238, 190, 136, 24, 9, 117, 71, 58, 177, 140, 71, 237, 214, 198, 78, 222, 237, 87, 177, 53, 221, 73, 148, 79, 214, 196, 99, 204, 140, 199, 228, 197, 115, 48, 216 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 21,
                column: "FirstName",
                value: "UserGroup.Admin");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 22,
                column: "FirstName",
                value: "UserGroup.Create");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 23,
                column: "FirstName",
                value: "UserGroup.Update");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 24,
                column: "FirstName",
                value: "UserGroup.Delete");

            migrationBuilder.UpdateData(
                table: "operationclaims",
                keyColumn: "Id",
                keyValue: 25,
                column: "FirstName",
                value: "UserGroup.Read");

            migrationBuilder.InsertData(
                table: "operationclaims",
                columns: new[] { "Id", "FirstName" },
                values: new object[,]
                {
                    { 26, "UserGroupOperationClaimMapping.Admin" },
                    { 27, "UserGroupOperationClaimMapping.Create" },
                    { 28, "UserGroupOperationClaimMapping.Update" },
                    { 29, "UserGroupOperationClaimMapping.Delete" },
                    { 30, "UserGroupOperationClaimMapping.Read" },
                    { 31, "UserUserGroupMapping.Admin" },
                    { 32, "UserUserGroupMapping.Create" },
                    { 33, "UserUserGroupMapping.Update" },
                    { 34, "UserUserGroupMapping.Delete" },
                    { 35, "UserUserGroupMapping.Read" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 48, 23, 20, 103, 246, 109, 212, 14, 168, 4, 194, 239, 31, 68, 91, 211, 19, 228, 180, 220, 5, 71, 249, 179, 117, 32, 105, 218, 65, 104, 90, 164, 120, 123, 88, 98, 99, 23, 111, 154, 134, 242, 74, 0, 17, 247, 196, 17, 198, 193, 228, 116, 253, 210, 197, 117, 135, 31, 51, 227, 59, 221, 75, 177 }, new byte[] { 185, 14, 85, 197, 25, 199, 249, 101, 195, 151, 231, 161, 126, 83, 241, 143, 255, 124, 165, 187, 213, 192, 145, 239, 243, 125, 228, 144, 102, 61, 45, 216, 39, 182, 167, 25, 210, 149, 165, 0, 219, 103, 102, 12, 171, 242, 53, 118, 233, 62, 120, 169, 12, 217, 139, 97, 154, 48, 128, 244, 40, 169, 182, 126, 210, 250, 117, 224, 57, 46, 241, 23, 254, 187, 206, 1, 89, 89, 149, 206, 133, 181, 226, 60, 199, 190, 45, 141, 129, 160, 125, 27, 91, 177, 165, 4, 58, 231, 21, 65, 17, 39, 183, 14, 43, 75, 171, 180, 22, 5, 158, 177, 63, 220, 0, 53, 160, 65, 178, 206, 15, 16, 243, 167, 31, 137, 68, 58 } });

            migrationBuilder.InsertData(
                table: "useroperationclaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 26, 26, 4 },
                    { 27, 27, 4 },
                    { 28, 28, 4 },
                    { 29, 29, 4 },
                    { 30, 30, 4 },
                    { 31, 31, 4 },
                    { 32, 32, 4 },
                    { 33, 33, 4 },
                    { 34, 34, 4 },
                    { 35, 35, 4 }
                });
        }
    }
}
