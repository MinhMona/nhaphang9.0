using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.DbContexts.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("557d2039-7c74-4eca-9991-6f722e6d8fff"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9b611c01-78d6-4e7a-b606-82da5d0a6970"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Active", "Created", "CreatedBy", "Deleted", "Name", "Permission", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("0905f6ad-e399-4d6b-a4c7-09925d786696"), true, null, "", false, "Admin", "", null, "" },
                    { new Guid("a76ba3b4-6dac-4e52-af80-b4fe5e18ec6d"), true, null, "", false, "EndUser", "", null, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0905f6ad-e399-4d6b-a4c7-09925d786696"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a76ba3b4-6dac-4e52-af80-b4fe5e18ec6d"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Active", "Created", "CreatedBy", "Deleted", "Name", "Permission", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("557d2039-7c74-4eca-9991-6f722e6d8fff"), true, null, "", false, "Admin", "", null, "" },
                    { new Guid("9b611c01-78d6-4e7a-b606-82da5d0a6970"), true, null, "", false, "EndUser", "", null, "" }
                });
        }
    }
}
