using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Layihe.Migrations
{
    public partial class UpdatePapa_1Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Basliq",
                table: "Papadias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Papadias",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Papadias",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basliq",
                table: "Papadias");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Papadias");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Papadias");
        }
    }
}
