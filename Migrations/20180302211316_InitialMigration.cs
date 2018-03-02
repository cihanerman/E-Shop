using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Migrations {
    public partial class InitialMigration : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable (
                name: "Users",
                columns : table => new {
                    UserId = table.Column<int> (nullable: false)
                        .Annotation ("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                        FirstName = table.Column<string> (nullable: true),
                        LastName = table.Column<string> (nullable: true),
                        Mail = table.Column<string> (nullable: true),
                        PhoneNumber = table.Column<decimal> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable (
                name: "Orders",
                columns : table => new {
                    OrderId = table.Column<int> (nullable: false)
                        .Annotation ("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                        UserId = table.Column<int> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Orders", x => x.OrderId);
                    table.ForeignKey (
                        name: "FK_Orders_Users_UserId",
                        column : x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable (
                name: "Products",
                columns : table => new {
                    ProductId = table.Column<int> (nullable: false)
                        .Annotation ("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                        Description = table.Column<string> (nullable: true),
                        OrderId = table.Column<int> (nullable: true),
                        Price = table.Column<decimal> (nullable: false),
                        ProductName = table.Column<string> (nullable: true),
                        PruductImageUrl = table.Column<string> (nullable: true),
                        Stock = table.Column<int> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Products", x => x.ProductId);
                    table.ForeignKey (
                        name: "FK_Products_Orders_OrderId",
                        column : x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete : ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex (
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex (
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "Products");

            migrationBuilder.DropTable (
                name: "Orders");

            migrationBuilder.DropTable (
                name: "Users");
        }
    }
}