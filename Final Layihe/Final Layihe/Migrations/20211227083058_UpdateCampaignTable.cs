using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Layihe.Migrations
{
    public partial class UpdateCampaignTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Campaigns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Campaigns");
        }
    }
}
