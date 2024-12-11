using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MongoDB.Bson;

#nullable disable

namespace GlobalShopping.Migrations.AsiaShopping
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(100)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseStock",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProductID = table.Column<string>(type: "varchar(100)", nullable: false),
                    AvailableQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseStock", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WarehouseStock_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(100)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "varchar(100)", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_UserAccount_UserID",
                        column: x => x.UserID,
                        principalTable: "UserAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(100)", nullable: false),
                    OrderID = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProductID = table.Column<string>(type: "varchar(100)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderLine_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLine_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderID",
                table: "OrderLine",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_ProductID",
                table: "OrderLine",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseStock_ProductID",
                table: "WarehouseStock",
                column: "ProductID");

            var pid1 = ObjectId.GenerateNewId().ToString();
            var pid2 = ObjectId.GenerateNewId().ToString();
            var pid3 = ObjectId.GenerateNewId().ToString();
            var pid4 = ObjectId.GenerateNewId().ToString();

            var userid1 = ObjectId.GenerateNewId().ToString();
            var userid2 = ObjectId.GenerateNewId().ToString();
            var userid3 = ObjectId.GenerateNewId().ToString();
            var userid4 = ObjectId.GenerateNewId().ToString();

            var orderid1 = ObjectId.GenerateNewId().ToString();
            var orderid2 = ObjectId.GenerateNewId().ToString();
            var orderid3 = ObjectId.GenerateNewId().ToString();
            var orderid4 = ObjectId.GenerateNewId().ToString();

            migrationBuilder.InsertData(table: "UserAccount", columns: new[] { "ID", "DateOfBirth", "FirstName", "LastName", "Active" },
                values: new object[,]
                {
    {  userid1, DateTime.Now.AddYears(-15), "John", "Doe", true },
      {  userid2, DateTime.Now.AddYears(-25).AddDays(-15), "Jim",  "Carter", true },
       {  userid3,  DateTime.Now.AddYears(-30).AddDays(-24), "John",  "Wick", false },
        { userid4, DateTime.Now.AddYears(-45).AddDays(56), "James", "Briden", false }
                });

            migrationBuilder.InsertData(table: "Product", columns: new[] { "ID", "ManufactureDate", "Price", "Name", "Category", "Active" },
                values: new object[,]
                {
   { pid1, DateTime.Now.AddDays(-100), 1,  "Pen", "Stationary", true },
    {  pid2,  DateTime.Now.AddDays(-150),  7,  "Book", "Stationary", true },
      { pid3,  DateTime.Now.AddDays(-200),  50,  "Shoes", "Accessories", true },
       { pid4,  DateTime.Now.AddDays(-155),  15,  "Socks", "Accessories", true }
                });

            migrationBuilder.InsertData(table: "Order", columns: new[] { "ID", "OrderDate", "UserID", "DeliveryAddress" },
                values: new object[,]
                {
    { orderid1,  DateTime.Now.AddDays(-1),  userid1,  "Yliopistonkatu 34, 53850 Lappeenranta" },
       { orderid2,  DateTime.Now.AddDays(-5),  userid2,  "Ruskolahdenkatu 15, 53850 Lappeenranta" },
        { orderid3,  DateTime.Now.AddDays(-10), userid3, "Matkakeskus 11, 53850 Lappeenranta" },
         {  orderid4, DateTime.Now.AddDays(-15), userid4,  "LasrtKatu 32, 53850 Lappeenranta" }
                });

            migrationBuilder.InsertData(table: "OrderLine", columns: new[] { "ID", "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
{ ObjectId.GenerateNewId().ToString(), orderid1, pid1, 5 },
{ ObjectId.GenerateNewId().ToString(), orderid1, pid2, 7 },
{ ObjectId.GenerateNewId().ToString(), orderid2, pid2, 15 },
{ ObjectId.GenerateNewId().ToString(), orderid2, pid3, 12 },
{ ObjectId.GenerateNewId().ToString(), orderid3, pid3, 25 },
{ ObjectId.GenerateNewId().ToString(), orderid3, pid4, 30 },
{ ObjectId.GenerateNewId().ToString(), orderid4, pid4, 35 },
{ ObjectId.GenerateNewId().ToString(), orderid4, pid1, 10 }
                });
            migrationBuilder.InsertData(table: "WarehouseStock", columns: new[] { "ID", "ProductID", "AvailableQty" },
                values: new object[,]
                {
   { ObjectId.GenerateNewId().ToString(), pid1, 100 },
    {ObjectId.GenerateNewId().ToString(),  pid2,  100 },
      {ObjectId.GenerateNewId().ToString(), pid3, 100 },
       {ObjectId.GenerateNewId().ToString(), pid4, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "WarehouseStock");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
