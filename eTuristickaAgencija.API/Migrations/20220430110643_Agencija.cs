using Microsoft.EntityFrameworkCore.Migrations;

namespace eTuristickaAgencija.API.Migrations
{
    public partial class Agencija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencija", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencija");
        }
    }
}
