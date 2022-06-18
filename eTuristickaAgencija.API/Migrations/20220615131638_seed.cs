using Microsoft.EntityFrameworkCore.Migrations;

namespace eTuristickaAgencija.API.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agencija",
                columns: new[] { "ID", "Adresa", "Email", "Telefon" },
                values: new object[] { 0, "Trg Ivana Krndelja 35, 88000 Mostar", "agencija@gmail.com", "061-235-886" });

            migrationBuilder.InsertData(
                table: "Kontinent",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Evropa" },
                    { 2, "Azija" }
                });

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Turist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agencija",
                keyColumn: "ID",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Kontinent",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kontinent",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
