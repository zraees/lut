using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldCareCenter.Api.Migrations.TurkuDB
{
    /// <inheritdoc />
    public partial class TurkuData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "InvoiceId", "InvoiceLineItem" },
                values: new object[,]
                {
                    { 1, 1, "First Item" },
                    { 2, 1, "Second Item" },
                    { 3, 2, "Second Item" },
                    { 4, 3, "Medicine Item" },
                    { 5, 4, "Planning Item" },
                    { 6, 5, "Item 1" },
                    { 7, 2, "Two Item" },
                    { 8, 3, "3rd Item" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "Date", "InvoiceAmount", "PatientID" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 8, 23), 980m, 2 },
                    { 2, new DateOnly(2024, 7, 3), 580m, 1 },
                    { 3, new DateOnly(2024, 6, 12), 740m, 2 },
                    { 4, new DateOnly(2024, 5, 6), 120m, 3 },
                    { 5, new DateOnly(2024, 3, 4), 156m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientID", "Email", "Gender", "PatientFileNo", "PatientName" },
                values: new object[,]
                {
                    { 1, "emily.johnson@example.com", "Male", "123-422", "Emily Johnson" },
                    { 2, "michael.brown@example.com", "Male", "333-467", "Michael Brown" },
                    { 3, "sarah.davis@example.com", "Female", "433-454", "Sarah Davis" },
                    { 4, "laura.thomas@example.com", "Female", "553-344", "Laura Thomas" },
                    { 5, "linda.martin@example.com", "Female", "983-124", "Linda Martin" }
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
