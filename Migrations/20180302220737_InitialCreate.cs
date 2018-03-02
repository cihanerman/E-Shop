﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Migrations {
    public partial class InitialCreate : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey (
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex (
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropColumn (
                name: "OrderId",
                table: "Products");

            migrationBuilder.CreateTable (
                name: "OrderProduct",
                columns : table => new {
                    OrderProductId = table.Column<int> (nullable: false)
                        .Annotation ("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                        OrderId = table.Column<int> (nullable: false),
                        Piece = table.Column<int> (nullable: false),
                        ProductId = table.Column<int> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_OrderProduct", x => x.OrderProductId);
                    table.ForeignKey (
                        name: "FK_OrderProduct_Orders_OrderId",
                        column : x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete : ReferentialAction.Cascade);
                    table.ForeignKey (
                        name: "FK_OrderProduct_Products_ProductId",
                        column : x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex (
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex (
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "OrderProduct");

            migrationBuilder.AddColumn<int> (
                name: "OrderId",
                table: "Products",
                nullable : true);

            migrationBuilder.CreateIndex (
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey (
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete : ReferentialAction.Restrict);
        }
    }
}