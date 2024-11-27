using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment4.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressesSql_FamiliesSql_FamilyId",
                table: "AddressesSql");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildrenSql_FamiliesSql_FamilyId",
                table: "ChildrenSql");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentsSql_FamiliesSql_FamilyId",
                table: "ParentsSql");

            migrationBuilder.DropIndex(
                name: "IX_ParentsSql_FamilyId",
                table: "ParentsSql");

            migrationBuilder.DropIndex(
                name: "IX_ChildrenSql_FamilyId",
                table: "ChildrenSql");

            migrationBuilder.DropIndex(
                name: "IX_AddressesSql_FamilyId",
                table: "AddressesSql");

            migrationBuilder.AddColumn<string>(
                name: "FamilySqlId",
                table: "ParentsSql",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "FamiliesSql",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FamilySqlId",
                table: "ChildrenSql",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentsSql_FamilySqlId",
                table: "ParentsSql",
                column: "FamilySqlId");

            migrationBuilder.CreateIndex(
                name: "IX_FamiliesSql_AddressId",
                table: "FamiliesSql",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenSql_FamilySqlId",
                table: "ChildrenSql",
                column: "FamilySqlId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildrenSql_FamiliesSql_FamilySqlId",
                table: "ChildrenSql",
                column: "FamilySqlId",
                principalTable: "FamiliesSql",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamiliesSql_AddressesSql_AddressId",
                table: "FamiliesSql",
                column: "AddressId",
                principalTable: "AddressesSql",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsSql_FamiliesSql_FamilySqlId",
                table: "ParentsSql",
                column: "FamilySqlId",
                principalTable: "FamiliesSql",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildrenSql_FamiliesSql_FamilySqlId",
                table: "ChildrenSql");

            migrationBuilder.DropForeignKey(
                name: "FK_FamiliesSql_AddressesSql_AddressId",
                table: "FamiliesSql");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentsSql_FamiliesSql_FamilySqlId",
                table: "ParentsSql");

            migrationBuilder.DropIndex(
                name: "IX_ParentsSql_FamilySqlId",
                table: "ParentsSql");

            migrationBuilder.DropIndex(
                name: "IX_FamiliesSql_AddressId",
                table: "FamiliesSql");

            migrationBuilder.DropIndex(
                name: "IX_ChildrenSql_FamilySqlId",
                table: "ChildrenSql");

            migrationBuilder.DropColumn(
                name: "FamilySqlId",
                table: "ParentsSql");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "FamiliesSql");

            migrationBuilder.DropColumn(
                name: "FamilySqlId",
                table: "ChildrenSql");

            migrationBuilder.CreateIndex(
                name: "IX_ParentsSql_FamilyId",
                table: "ParentsSql",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenSql_FamilyId",
                table: "ChildrenSql",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressesSql_FamilyId",
                table: "AddressesSql",
                column: "FamilyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressesSql_FamiliesSql_FamilyId",
                table: "AddressesSql",
                column: "FamilyId",
                principalTable: "FamiliesSql",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildrenSql_FamiliesSql_FamilyId",
                table: "ChildrenSql",
                column: "FamilyId",
                principalTable: "FamiliesSql",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsSql_FamiliesSql_FamilyId",
                table: "ParentsSql",
                column: "FamilyId",
                principalTable: "FamiliesSql",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
