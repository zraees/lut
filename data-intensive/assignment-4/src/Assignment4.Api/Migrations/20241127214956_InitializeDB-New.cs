using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment4.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDBNew : Migration
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
                name: "ChildrenSql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: false),
                    FamilySqlId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenSql", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildrenSql_FamiliesSql_FamilySqlId",
                        column: x => x.FamilySqlId,
                        principalTable: "FamiliesSql",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParentsSql",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    FamilySqlId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentsSql", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentsSql_FamiliesSql_FamilySqlId",
                        column: x => x.FamilySqlId,
                        principalTable: "FamiliesSql",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenSql_FamilySqlId",
                table: "ChildrenSql",
                column: "FamilySqlId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentsSql_FamilySqlId",
                table: "ParentsSql",
                column: "FamilySqlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildrenSql");

            migrationBuilder.DropTable(
                name: "ParentsSql");

            migrationBuilder.DropTable(
                name: "FamiliesSql");
        }
    }
}
