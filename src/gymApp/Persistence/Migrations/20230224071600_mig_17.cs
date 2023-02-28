using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFriday",
                table: "UsersMovements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMonday",
                table: "UsersMovements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSaturday",
                table: "UsersMovements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSunday",
                table: "UsersMovements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsThursday",
                table: "UsersMovements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTuesday",
                table: "UsersMovements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWednesday",
                table: "UsersMovements",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "UsersMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 43, 135, 156, 205, 160, 36, 87, 105, 194, 27, 102, 26, 61, 99, 108, 139, 34, 123, 46, 163, 169, 83, 74, 6, 182, 12, 29, 77, 199, 169, 136, 215, 240, 160, 93, 157, 240, 120, 58, 161, 152, 230, 132, 74, 199, 238, 30, 74, 207, 108, 179, 11, 157, 50, 112, 168, 120, 120, 34, 188, 125, 35, 156, 173 }, new byte[] { 8, 101, 235, 23, 106, 199, 152, 19, 182, 83, 61, 152, 191, 99, 203, 224, 163, 169, 26, 138, 210, 163, 201, 102, 212, 49, 253, 182, 220, 85, 0, 206, 169, 72, 152, 150, 222, 154, 255, 158, 4, 219, 5, 199, 202, 186, 230, 108, 75, 189, 227, 174, 201, 140, 55, 160, 183, 84, 238, 192, 97, 142, 122, 106, 156, 1, 149, 145, 237, 225, 121, 247, 108, 81, 128, 71, 226, 151, 64, 36, 136, 51, 175, 26, 88, 129, 168, 32, 181, 115, 229, 110, 67, 71, 122, 27, 189, 22, 128, 7, 209, 156, 109, 9, 207, 51, 104, 160, 163, 227, 135, 22, 186, 33, 152, 58, 202, 62, 150, 243, 171, 62, 242, 158, 123, 69, 53, 71 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFriday",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "IsMonday",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "IsSaturday",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "IsSunday",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "IsThursday",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "IsTuesday",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "IsWednesday",
                table: "UsersMovements");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "UsersMovements");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 14, 153, 98, 240, 48, 134, 203, 45, 147, 233, 126, 32, 79, 235, 219, 181, 105, 223, 154, 134, 124, 196, 92, 172, 119, 57, 107, 18, 130, 49, 98, 146, 254, 116, 87, 219, 43, 12, 14, 101, 235, 76, 243, 195, 114, 127, 237, 67, 190, 29, 148, 31, 119, 133, 170, 150, 103, 100, 36, 9, 173, 56, 219, 12 }, new byte[] { 55, 123, 221, 33, 177, 127, 133, 66, 71, 7, 190, 234, 95, 135, 196, 86, 208, 18, 42, 51, 248, 206, 78, 146, 161, 251, 129, 10, 200, 209, 151, 14, 190, 242, 44, 35, 72, 206, 198, 188, 168, 53, 157, 139, 123, 155, 66, 15, 150, 147, 243, 117, 214, 137, 56, 66, 202, 19, 251, 221, 161, 35, 92, 42, 99, 200, 162, 140, 1, 162, 172, 111, 39, 15, 250, 239, 131, 27, 253, 144, 238, 148, 1, 48, 243, 15, 102, 122, 30, 132, 190, 27, 209, 26, 6, 191, 44, 34, 38, 77, 144, 117, 37, 241, 25, 139, 32, 26, 9, 21, 188, 121, 163, 82, 56, 245, 3, 162, 202, 127, 199, 49, 154, 61, 33, 28, 116, 30 } });
        }
    }
}
