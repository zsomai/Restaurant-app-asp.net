﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tema2.Migrations
{
    /// <inheritdoc />
    public partial class migrate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_OrderId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "MealOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealOrders_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MealOrders_MealId",
                table: "MealOrders",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOrders_OrderId",
                table: "MealOrders",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_OrderId",
                table: "Meals",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
