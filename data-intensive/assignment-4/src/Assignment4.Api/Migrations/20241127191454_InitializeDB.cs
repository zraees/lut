using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment4.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamiliesSql",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    IsRegistered = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliesSql", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressesSql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressesSql", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressesSql_FamiliesSql_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "FamiliesSql",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenSql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenSql", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildrenSql_FamiliesSql_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "FamiliesSql",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentsSql",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentsSql", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentsSql_FamiliesSql_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "FamiliesSql",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressesSql_FamilyId",
                table: "AddressesSql",
                column: "FamilyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenSql_FamilyId",
                table: "ChildrenSql",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentsSql_FamilyId",
                table: "ParentsSql",
                column: "FamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressesSql");

            migrationBuilder.DropTable(
                name: "ChildrenSql");

            migrationBuilder.DropTable(
                name: "ParentsSql");

            migrationBuilder.DropTable(
                name: "FamiliesSql");
        }
    }
}
