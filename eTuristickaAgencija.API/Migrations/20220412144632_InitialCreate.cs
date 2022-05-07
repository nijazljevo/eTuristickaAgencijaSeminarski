using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTuristickaAgencija.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontinent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontinent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    KontinentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kontinent_Drzava",
                        column: x => x.KontinentID,
                        principalTable: "Kontinent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    KorisnikoIme = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(nullable: false),
                    LozinkaSalt = table.Column<string>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    UlogaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Uloga",
                        column: x => x.UlogaID,
                        principalTable: "Uloga",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    DrzavaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: true),
                    DatumRegistracije = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clan_korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktivan = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Uposlenik_korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Destinacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slika = table.Column<byte[]>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    GradID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grad_Destinacija",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slika = table.Column<byte[]>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    GradID = table.Column<int>(nullable: true),
                    BrojZvjezdica = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grad1",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OcjenaUsluge = table.Column<int>(nullable: false),
                    Komentar = table.Column<string>(type: "text", nullable: true),
                    DestinacijaID = table.Column<int>(nullable: true),
                    KorisnikID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.ID);
                    table.ForeignKey(
                        name: "fk_Destinacija",
                        column: x => x.DestinacijaID,
                        principalTable: "Destinacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cijena = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    HotelID = table.Column<int>(nullable: true),
                    Otkazana = table.Column<bool>(nullable: true),
                    DatumRezervacije = table.Column<DateTime>(type: "datetime", nullable: false),
                    KorisnikID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Hotel",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinacijaID = table.Column<int>(nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Popust = table.Column<float>(nullable: true),
                    HotelID = table.Column<int>(nullable: true),
                    CijenaPopust = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    AktivanTermin = table.Column<bool>(nullable: true),
                    DatumPolaska = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatumDolaska = table.Column<DateTime>(type: "datetime", nullable: false),
                    GradID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Termin_Destinacija",
                        column: x => x.DestinacijaID,
                        principalTable: "Destinacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termin_Grad",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Angazman_Hotel",
                        column: x => x.HotelID,
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminID = table.Column<int>(nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ponistena = table.Column<bool>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.ID);
                    table.ForeignKey(
                        name: "fk_Korisnik_Karta",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karta_Termin",
                        column: x => x.TerminID,
                        principalTable: "Termin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clan_KorisnikID",
                table: "Clan",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Destinacija_GradID",
                table: "Destinacija",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Drzava_KontinentID",
                table: "Drzava",
                column: "KontinentID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_GradID",
                table: "Hotel",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KorisnikID",
                table: "Karta",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_TerminID",
                table: "Karta",
                column: "TerminID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UlogaID",
                table: "Korisnik",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_DestinacijaID",
                table: "Ocjena",
                column: "DestinacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_KorisnikID",
                table: "Ocjena",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_HotelID",
                table: "Rezervacija",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikID",
                table: "Rezervacija",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_DestinacijaID",
                table: "Termin",
                column: "DestinacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_GradID",
                table: "Termin",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_HotelID",
                table: "Termin",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_KorisnikID",
                table: "Uposlenik",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Destinacija");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Kontinent");
        }
    }
}
