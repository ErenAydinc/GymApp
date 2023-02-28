using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MemberEndDate",
                table: "users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MemberStartDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimeZone",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MemberStartDate", "PasswordHash", "PasswordSalt", "TimeZone" },
                values: new object[] { new DateTime(2023, 2, 24, 10, 40, 58, 683, DateTimeKind.Utc).AddTicks(2866), new byte[] { 2, 221, 26, 153, 114, 71, 156, 176, 211, 231, 37, 60, 153, 170, 78, 122, 124, 135, 138, 9, 2, 53, 242, 109, 90, 24, 162, 3, 88, 230, 132, 86, 25, 80, 24, 183, 67, 137, 197, 179, 126, 109, 173, 223, 118, 214, 4, 156, 101, 160, 41, 223, 166, 78, 94, 194, 118, 53, 7, 8, 9, 91, 48, 14 }, new byte[] { 220, 97, 215, 203, 84, 19, 46, 102, 68, 31, 84, 123, 167, 85, 56, 96, 146, 165, 185, 214, 142, 151, 219, 184, 86, 231, 17, 22, 84, 194, 111, 133, 67, 196, 60, 235, 48, 185, 189, 66, 126, 179, 61, 235, 178, 160, 42, 87, 85, 247, 91, 206, 119, 227, 128, 238, 246, 95, 231, 141, 37, 72, 60, 238, 190, 126, 75, 13, 71, 255, 144, 113, 70, 191, 110, 114, 71, 240, 187, 137, 49, 153, 8, 218, 222, 190, 0, 255, 154, 77, 240, 84, 2, 164, 20, 165, 179, 210, 251, 187, 187, 236, 207, 44, 48, 103, 169, 76, 223, 67, 31, 231, 252, 71, 249, 232, 65, 223, 59, 36, 128, 155, 161, 53, 87, 81, 164, 203 }, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberEndDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "MemberStartDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "users");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 43, 135, 156, 205, 160, 36, 87, 105, 194, 27, 102, 26, 61, 99, 108, 139, 34, 123, 46, 163, 169, 83, 74, 6, 182, 12, 29, 77, 199, 169, 136, 215, 240, 160, 93, 157, 240, 120, 58, 161, 152, 230, 132, 74, 199, 238, 30, 74, 207, 108, 179, 11, 157, 50, 112, 168, 120, 120, 34, 188, 125, 35, 156, 173 }, new byte[] { 8, 101, 235, 23, 106, 199, 152, 19, 182, 83, 61, 152, 191, 99, 203, 224, 163, 169, 26, 138, 210, 163, 201, 102, 212, 49, 253, 182, 220, 85, 0, 206, 169, 72, 152, 150, 222, 154, 255, 158, 4, 219, 5, 199, 202, 186, 230, 108, 75, 189, 227, 174, 201, 140, 55, 160, 183, 84, 238, 192, 97, 142, 122, 106, 156, 1, 149, 145, 237, 225, 121, 247, 108, 81, 128, 71, 226, 151, 64, 36, 136, 51, 175, 26, 88, 129, 168, 32, 181, 115, 229, 110, 67, 71, 122, 27, 189, 22, 128, 7, 209, 156, 109, 9, 207, 51, 104, 160, 163, 227, 135, 22, 186, 33, 152, 58, 202, 62, 150, 243, 171, 62, 242, 158, 123, 69, 53, 71 } });
        }
    }
}
