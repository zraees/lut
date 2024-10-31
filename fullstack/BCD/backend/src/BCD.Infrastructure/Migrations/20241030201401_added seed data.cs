using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BCD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserType",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "UserType");

            migrationBuilder.RenameTable(
                name: "UserType",
                newName: "UserTypes");

            migrationBuilder.AddColumn<string>(
                name: "UserTypeName",
                table: "UserTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "UserTypeId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Food", null, null },
                    { 2, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Coffee", null, null },
                    { 3, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Nightlife", null, null },
                    { 4, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Fun", null, null },
                    { 5, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "", "Shopping", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "UserTypeName" },
                values: new object[] { 1, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "CreatedBy", "Email", "PasswordHash", "UpdatedAt", "UpdatedBy", "UserTypeId", "Username" },
                values: new object[] { 1, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "developerxone@hotmail.com", "admin123", null, null, 1, "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserTypeName",
                table: "UserTypes");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                newName: "UserType");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "UserType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserType",
                table: "UserType",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
