using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldCareCenter.Api.Migrations
{
    /// <inheritdoc />
    public partial class LahtiData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "InvoiceId", "InvoiceLineItem" },
                values: new object[,]
                {
                    { 1, 1, "Three Item" },
                    { 2, 1, "Mid Item" },
                    { 3, 2, "Top Item" },
                    { 4, 3, "Medicine Item" },
                    { 5, 4, "Item 1" },
                    { 6, 5, "Planning Item" },
                    { 7, 2, "Two 2 Item" },
                    { 8, 3, "13th Item" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "Date", "InvoiceAmount", "PatientID" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 1, 3), 180m, 1 },
                    { 2, new DateOnly(2024, 2, 13), 500m, 2 },
                    { 3, new DateOnly(2024, 6, 2), 240m, 3 },
                    { 4, new DateOnly(2024, 7, 16), 620m, 4 },
                    { 5, new DateOnly(2024, 5, 14), 146m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Email", "Gender", "PatientFileNo", "PatientName" },
                values: new object[,]
                {
                    { 1, "joseph.hall@example.com", "Male", "951-522", "Joseph Hall" },
                    { 2, "thomas.scott@example.com", "Male", "951-497", "Thomas Scott" },
                    { 3, "barbara.green@example.com", "Female", "147-404", "Barbara Green" },
                    { 4, "jennifer.white@example.com", "Female", "741-314", "Jennifer White" },
                    { 5, "jessica.taylor@example.com", "Female", "256-024", "Jessica Taylor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientID",
                keyValue: 5);
        }
    }
}
