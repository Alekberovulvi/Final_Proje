using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Layihe.Migrations
{
    public partial class UpdatedOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Snacks_SnackId",
                table: "BasketItems");

            migrationBuilder.AlterColumn<int>(
                name: "SnackId",
                table: "BasketItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DesertId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PapadiasId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PastaId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalatId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SousId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Count = table.Column<int>(nullable: false),
                    SnackId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_DesertId",
                table: "BasketItems",
                column: "DesertId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_DrinkId",
                table: "BasketItems",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_PapadiasId",
                table: "BasketItems",
                column: "PapadiasId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_PastaId",
                table: "BasketItems",
                column: "PastaId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_PizzaId",
                table: "BasketItems",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_SalatId",
                table: "BasketItems",
                column: "SalatId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_SousId",
                table: "BasketItems",
                column: "SousId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SnackId",
                table: "OrderItems",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Deserts_DesertId",
                table: "BasketItems",
                column: "DesertId",
                principalTable: "Deserts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Drinks_DrinkId",
                table: "BasketItems",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Papadias_PapadiasId",
                table: "BasketItems",
                column: "PapadiasId",
                principalTable: "Papadias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Pastas_PastaId",
                table: "BasketItems",
                column: "PastaId",
                principalTable: "Pastas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Pizzas_PizzaId",
                table: "BasketItems",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Salats_SalatId",
                table: "BasketItems",
                column: "SalatId",
                principalTable: "Salats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Snacks_SnackId",
                table: "BasketItems",
                column: "SnackId",
                principalTable: "Snacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Sous_SousId",
                table: "BasketItems",
                column: "SousId",
                principalTable: "Sous",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Deserts_DesertId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Drinks_DrinkId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Papadias_PapadiasId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Pastas_PastaId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Pizzas_PizzaId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Salats_SalatId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Snacks_SnackId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Sous_SousId",
                table: "BasketItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_DesertId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_DrinkId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_PapadiasId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_PastaId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_PizzaId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_SalatId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_SousId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "DesertId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "PapadiasId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "PastaId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SalatId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SousId",
                table: "BasketItems");

            migrationBuilder.AlterColumn<int>(
                name: "SnackId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Snacks_SnackId",
                table: "BasketItems",
                column: "SnackId",
                principalTable: "Snacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
