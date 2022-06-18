using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTuristickaAgencija.API.Migrations
{
    public partial class seed6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Karta",
                columns: new[] { "ID", "DatumKreiranja", "KorisnikID", "Ponistena", "TerminID" },
                values: new object[] { 1, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1 });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "xqZdAbog2zOo7l14Rzy1XZD5WOw=", "QEVlauEqSS6MytuqauLrBg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "JT0ClT1H2jIySd2fUTG6Mdt1Jsg=", "k/lsqPrYmt0L4DNu3Gqxzw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Karta",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "vH+KLG+6BMXJ3cwk9smTHCkelEQ=", "uuR/SDF1bqh5yhQMn8kIKQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "m8+x9gu86lf/B3XnuifEi2/xjw0=", "BP9LNiXLGEvAZ0brWP0quw==" });
        }
    }
}
