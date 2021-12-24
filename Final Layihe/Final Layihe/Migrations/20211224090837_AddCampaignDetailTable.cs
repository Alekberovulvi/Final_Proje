using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Layihe.Migrations
{
    public partial class AddCampaignDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brithdays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Head",
                table: "Brithdays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Brithdays",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Classics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Head = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Head = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HandHelds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandHelds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classics");

            migrationBuilder.DropTable(
                name: "Colds");

            migrationBuilder.DropTable(
                name: "HandHelds");

            migrationBuilder.DropTable(
                name: "Parties");

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
    }
}
