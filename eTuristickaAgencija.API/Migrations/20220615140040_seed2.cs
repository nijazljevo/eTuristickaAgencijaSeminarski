using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTuristickaAgencija.API.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clan",
                columns: new[] { "ID", "DatumRegistracije", "KorisnikID" },
                values: new object[] { 1, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "ID", "DrzavaID", "Naziv" },
                values: new object[,]
                {
                    { 1, 1, "Istanbul" },
                    { 2, 2, "Kuala Lumpur" }
                });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "mwODPE4Y9nPo4wf+c8g9lBSXIE0=", "7YfWfVua+/JFO+YRDv+a3g==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "GS4Wx5KC5GxhecAwiNlyxl4Q+aY=", "OGrjiB+I7oYQnXlhFuUqtQ==" });

            migrationBuilder.InsertData(
                table: "Uposlenik",
                columns: new[] { "ID", "Aktivan", "DatumZaposlenja", "KorisnikID" },
                values: new object[] { 1, true, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clan",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uposlenik",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "3i9r4tcCsX/IS7dwf0f7WetkTQY=", "SbMxE3uBgPwl+tLTgxnXYA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "uAnqz8V5kW4aXkt75ecXy8Jbycc=", "um3Lw8jvSzWygubHNSrRMQ==" });
        }
    }
}
