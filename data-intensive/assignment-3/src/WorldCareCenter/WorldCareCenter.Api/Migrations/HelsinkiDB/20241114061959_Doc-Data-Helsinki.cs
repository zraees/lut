using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldCareCenter.Api.Migrations.HelsinkiDB
{
    /// <inheritdoc />
    public partial class DocDataHelsinki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Email", "Name", "Specialty" },
                values: new object[,]
                {
                    { 8, "sarah.johnson@example.com", "Sarah Johnson", "Pediatrician" },
                    { 9, "michael.smith@example.com", "Michael Smith", "Cardiologist" },
                    { 10, "emily.davis@example.com", "Emily Davis", "Dermatologist" },
                    { 11, "david.brown@example.com", "David Brown", "Orthopedic Surgeon" },
                    { 12, "jessica.wilson@example.com", "Jessica Wilson", "Neurologist" },
                    { 13, "laura.martinez@example.com", "Laura Martinez", "General Practitioner" },
                    { 14, "daniel.anderson@example.com", "Daniel Anderson", "Endocrinologist" },
                    { 15, "olivia.thomas@example.com", "Olivia Thomas", "Gynecologist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 15);
        }
    }
}
