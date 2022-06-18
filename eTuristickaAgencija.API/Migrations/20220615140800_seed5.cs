using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTuristickaAgencija.API.Migrations
{
    public partial class seed5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Ocjena",
                columns: new[] { "ID", "DestinacijaID", "Komentar", "KorisnikID", "OcjenaUsluge" },
                values: new object[] { 1, 1, "Odlicno", 2, 5 });

            migrationBuilder.InsertData(
                table: "Rezervacija",
                columns: new[] { "ID", "Cijena", "DatumRezervacije", "HotelID", "KorisnikID", "Otkazana" },
                values: new object[] { 1, 300m, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false });

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Cijena", "DatumDolaska", "DatumPolaska" },
                values: new object[] { 900m, new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Termin",
                columns: new[] { "ID", "AktivanTermin", "Cijena", "CijenaPopust", "DatumDolaska", "DatumPolaska", "DestinacijaID", "GradID", "HotelID", "Popust" },
                values: new object[,]
                {
                    { 2, true, 700m, 0m, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 0f },
                    { 3, true, 1100m, 0m, new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 1, 0f },
                    { 4, true, 1300m, 0m, new DateTime(2021, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 1, 0f },
                    { 5, true, 1300m, 0m, new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, 0f },
                    { 6, true, 1200m, 0m, new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, 0f },
                    { 7, true, 1500m, 0m, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2, 0f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ocjena",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "JBVZcFpXNfhASPDUSdtfZczTbs8=", "gwVQXRhJtUJxQ1FtJiD+hQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "IPvJ8wqC+4oFDb0bbMK+I9QnYco=", "QiYdsCO5arGPxPpXPi2l4A==" });

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Cijena", "DatumDolaska", "DatumPolaska" },
                values: new object[] { 1100m, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
