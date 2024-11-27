using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment4.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamiliesSql_AddressesSql_AddressId",
                table: "FamiliesSql");

            migrationBuilder.DropTable(
                name: "AddressesSql");

            migrationBuilder.DropIndex(
                name: "IX_FamiliesSql_AddressId",
                table: "FamiliesSql");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "FamiliesSql");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "FamiliesSql",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AddressesSql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyId = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressesSql", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamiliesSql_AddressId",
                table: "FamiliesSql",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamiliesSql_AddressesSql_AddressId",
                table: "FamiliesSql",
                column: "AddressId",
                principalTable: "AddressesSql",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
