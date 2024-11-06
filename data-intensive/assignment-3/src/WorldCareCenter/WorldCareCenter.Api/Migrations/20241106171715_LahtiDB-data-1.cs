using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldCareCenter.Api.Migrations
{
    /// <inheritdoc />
    public partial class LahtiDBdata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 1,
                column: "Specialty",
                value: "Neurologist");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Email", "Name", "Specialty" },
                values: new object[,]
                {
                    { 2, "smith.bruce@email.com", "Smith Bruce", "Psychiatrist" },
                    { 3, "peter.dam@email.com", "Peter Dam", "General Physician" },
                    { 4, "willaim.john@email.com", "William John", "Pediatrician" },
                    { 5, "amar.micheal@email.com", "Amar Micheal", "Dermatologist" },
                    { 6, "tom.hood@email.com", "Tom Hood", "Gynecologist" },
                    { 7, "joni.bob@email.com", "Joni Bob", "Ophthalmologist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 1,
                column: "Specialty",
                value: "Heart");
        }
    }
}
