using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.DbContexts.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Active", "Created", "CreatedBy", "Deleted", "Name", "Permission", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("21724668-a428-4de3-b471-d72e287fc0cf"), true, null, "", false, "Admin", "", null, "" },
                    { new Guid("55f24790-2f9f-4cf0-a16a-f3ef071a5d30"), true, null, "", false, "EndUser", "", null, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("21724668-a428-4de3-b471-d72e287fc0cf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("55f24790-2f9f-4cf0-a16a-f3ef071a5d30"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Accounts");
        }
    }
}
