using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Layihe.Migrations
{
    public partial class UpdateCampaignDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HandHelds");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Colds");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "Colds");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Colds");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Classics");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "Classics");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Classics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brithdays");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "Brithdays");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Brithdays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HandHelds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Colds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Head",
                table: "Colds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Colds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Classics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Head",
                table: "Classics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Classics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brithdays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Head",
                table: "Brithdays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Brithdays",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
