using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Layihe.Migrations
{
    public partial class AddedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Conditions_ConditionId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Deliveries_DeliveryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Doughs_DoughId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Histories_HistoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Ingredients_IngredientsId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Papasaze_PapaAzeId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Papas_PapaId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Doughs");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Papas");

            migrationBuilder.DropTable(
                name: "Papasaze");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ConditionId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeliveryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DoughId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_HistoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IngredientsId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PapaAzeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PapaId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DoughId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PapaAzeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PapaId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Decs = table.Column<string>(nullable: true),
                    CategoriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AboutId",
                table: "Categories",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Abouts_AboutId",
                table: "Categories",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Abouts_AboutId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AboutId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ConditionId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoughId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PapaAzeId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PapaId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basliq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doughs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basliq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doughs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Papas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basliq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Papasaze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papasaze", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ConditionId",
                table: "Categories",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeliveryId",
                table: "Categories",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DoughId",
                table: "Categories",
                column: "DoughId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_HistoryId",
                table: "Categories",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IngredientsId",
                table: "Categories",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PapaAzeId",
                table: "Categories",
                column: "PapaAzeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PapaId",
                table: "Categories",
                column: "PapaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Conditions_ConditionId",
                table: "Categories",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Deliveries_DeliveryId",
                table: "Categories",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Doughs_DoughId",
                table: "Categories",
                column: "DoughId",
                principalTable: "Doughs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Histories_HistoryId",
                table: "Categories",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Ingredients_IngredientsId",
                table: "Categories",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Papasaze_PapaAzeId",
                table: "Categories",
                column: "PapaAzeId",
                principalTable: "Papasaze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Papas_PapaId",
                table: "Categories",
                column: "PapaId",
                principalTable: "Papas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
