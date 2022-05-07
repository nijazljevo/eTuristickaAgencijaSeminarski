using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.API.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API
{
    public class SetupService
    {

        public void Init(TuristickaAgencijaContext context)
        {
            context.Database.Migrate();
            if (!context.Uloga.Any(x => x.Naziv == "Admin" || x.Naziv=="Turist"))
            {
                context.Uloga.Add(new Uloga() { Naziv = "Admin" });
                context.Uloga.Add(new Uloga() { Naziv = "Turist" });
            }
            if (!context.Kontinent.Any(x => x.Naziv == "Evropa" || x.Naziv == "Azija"))
            {
                context.Kontinent.Add(new Kontinent() { Naziv = "Evropa" });
                context.Kontinent.Add(new Kontinent() { Naziv = "Azija" });
            }
            if (!context.Drzava.Any(x => x.Naziv == "Turska" && x.KontinentId == 27 || x.Naziv=="Malezija" && x.KontinentId==28))
            {
                context.Drzava.Add(new Drzava() { Naziv = "Turska",KontinentId=27 });
                context.Drzava.Add(new Drzava() { Naziv = "Malezija",KontinentId=28 });
            }
              if (!context.Grad.Any(x => x.Naziv == "Istanbul" && x.DrzavaId == 14 || x.Naziv == "Kuala Lumpur" && x.DrzavaId == 15))
              {
                  context.Grad.Add(new Grad() { Naziv = "Istanbul", DrzavaId = 14 });
                  context.Grad.Add(new Grad() { Naziv = "Kuala Lumpur", DrzavaId = 15 });
              }
            if (!context.Hotel.Any())
            {
                context.Hotel.AddRange(new Hotel()
                {
                    Naziv = "Levent",
                    GradId = 14,
                    BrojZvjezdica = 5

                },
                new Hotel()
                {
                    Naziv = "Hotel Malezija",
                    GradId = 15,
                    BrojZvjezdica = 5
                });
            }
                if (!context.Destinacija.Any(x => x.Naziv == "destinacija1" && x.GradId == 14 || x.Naziv == "destinacija2" && x.GradId == 15))
             {
                 context.Destinacija.Add(new Destinacija() { Naziv = "destinacija1", GradId = 14 });
                 context.Destinacija.Add(new Destinacija() { Naziv = "destinacija2", GradId = 15 });
             }
           
            if (!context.Termin.Any())
            {
                context.Termin.AddRange(new Termin()
                {
                    HotelId = 14,
                    GradId = 14,
                    DestinacijaId = 14,
                    AktivanTermin = true,
                    Cijena = 300,
                    CijenaPopust = 0,
                    Popust = 0,
                    DatumPolaska = new DateTime(2021, 09, 15),
                    DatumDolaska = new DateTime(2021, 10, 01)

                },
                new Termin()
                {
                    HotelId = 15,
                    GradId = 15,
                    DestinacijaId = 15,
                    AktivanTermin = true,
                    Cijena = 1200,
                    CijenaPopust = 0,
                    Popust = 0,
                    DatumPolaska = new DateTime(2022, 01, 03),
                    DatumDolaska = new DateTime(2022, 01, 23)
                });
            }
             List<string> Salt = new List<string>();
              for (int i = 0; i < 10; i++)
              {
                  Salt.Add(HashHelper.GenerateSalt());
              }
            if (!context.Korisnik.Any())
            {
                context.Korisnik.AddRange(new Korisnik()
                {
                    Ime="Nijaz",
                    Prezime="Ljevo",
                    KorisnikoIme="admin",
                    Email="nijaz@gmail.com",
                    UlogaId=27,
                    LozinkaSalt=Salt[0],
                    LozinkaHash=HashHelper.GenerateHash(Salt[0], "test"),
                    

                },
                new Korisnik()
                {
                    Ime = "Amna",
                    Prezime = "Spahalic",
                    KorisnikoIme = "mobile",
                    Email = "amna@gmail.com",
                    UlogaId = 28,
                    LozinkaSalt = Salt[1],
                    LozinkaHash = HashHelper.GenerateHash(Salt[1], "test"),
                   
                });
            }

            
            if (!context.Clan.Any())
            {
                context.Clan.AddRange(new Clan()
                {
                    KorisnikId = 15,
                    DatumRegistracije = new DateTime(2021, 07, 10),
                    

                });
            }

            if (!context.Karta.Any())
             {
                 context.Karta.AddRange(new Karta()
                 {
                     KorisnikId = 15,
                     TerminId = 14,
                     DatumKreiranja = new DateTime(2020, 09, 01)

                 });
             }
           
            if (!context.Ocjena.Any())
            {
                context.Ocjena.AddRange(new Ocjena()
                {
                    KorisnikId = 15,
                    Komentar = "Odlicno",
                    DestinacijaId = 14,
                    OcjenaUsluge = 5,
                    

                });
            }
            
            if (!context.Rezervacija.Any())
            {
                context.Rezervacija.AddRange(new Rezervacija()
                {
                    KorisnikId = 15,
                    Otkazana = false,
                    DatumRezervacije = new DateTime(2020, 09, 01),
                    HotelId=15,
                    Cijena=300

                });
            }
            if (!context.Uposlenik.Any())
            {
                context.Uposlenik.AddRange(new Uposlenik()
                {
                    KorisnikId = 14,
                    Aktivan = true,
                    DatumZaposlenja = new DateTime(2020, 09, 01)

                });
            }
            if (!context.Agencija.Any())
            {
                context.Agencija.AddRange(new Agencija()
                {
                    Email = "agencija@gmail.com",
                    Telefon = "061-235-886",
                    Adresa = "Trg Ivana Krndelja 35, 88000 Mostar"

                });
            }
            context.SaveChanges();

        }
    }
}
