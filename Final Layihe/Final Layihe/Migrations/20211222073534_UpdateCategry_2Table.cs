using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Layihe.Migrations
{
    public partial class UpdateCategry_2Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Abouts_AboutId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AboutId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Abouts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Abouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_CategoryId",
                table: "Abouts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Categories_CategoryId",
                table: "Abouts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Categories_CategoryId",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_CategoryId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Abouts");

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
