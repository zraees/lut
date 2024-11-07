using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldCareCenter.Api.Migrations.HelsinkiDB
{
    /// <inheritdoc />
    public partial class HelsinkiData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "InvoiceId", "InvoiceLineItem" },
                values: new object[,]
                {
                    { 1, 4, "First record" },
                    { 2, 2, "Second record" },
                    { 3, 2, "this is medi detail" },
                    { 4, 5, "Medicine receipt" },
                    { 5, 4, "Planning data" },
                    { 6, 2, "available list" },
                    { 7, 3, "doctor details" },
                    { 8, 1, "patient record" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "Date", "InvoiceAmount", "PatientID" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 1, 26), 180m, 1 },
                    { 2, new DateOnly(2024, 2, 15), 80m, 5 },
                    { 3, new DateOnly(2024, 6, 11), 139m, 2 },
                    { 4, new DateOnly(2024, 11, 16), 115m, 4 },
                    { 5, new DateOnly(2023, 12, 4), 941m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Email", "Gender", "PatientFileNo", "PatientName" },
                values: new object[,]
                {
                    { 1, "robert.lee@example.com", "Male", "513-001", "Robert Lee" },
                    { 2, "david.wilson@example.com", "Male", "633-957", "David Wilson" },
                    { 3, "margaret.young@example.com", "Female", "413-104", "Margaret Young" },
                    { 4, "charles.king@example.com", "Male", "952-204", "Charles King" },
                    { 5, "thomas.scott@example.com", "Male", "145-304", "Thomas Scott" }
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
