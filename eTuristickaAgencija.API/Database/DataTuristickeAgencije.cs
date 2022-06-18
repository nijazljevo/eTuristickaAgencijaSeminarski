using Amazon.Auth.AccessControlPolicy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Database
{
    public partial class TuristickaAgencijaContext
    {
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            API.Database.Clan clan = new API.Database.Clan()
            {
                Id=1,
                KorisnikId = 2,
                DatumRegistracije = new DateTime(2021, 07, 10),

            };
            modelBuilder.Entity<Clan>().HasData(clan);
            API.Database.Agencija agencija = new API.Database.Agencija()
            {
                Id=1,
                Email = "agencija@gmail.com",
                Telefon = "061-235-886",
                Adresa = "Trg Ivana Krndelja 35, 88000 Mostar"

            };
            modelBuilder.Entity<Agencija>().HasData(agencija);
            API.Database.Kontinent kontinent = new API.Database.Kontinent()
            {
                Id = 1,
                Naziv = "Evropa"

            };
            modelBuilder.Entity<Kontinent>().HasData(kontinent);

            API.Database.Kontinent kontinent2 = new API.Database.Kontinent()
            {
                Id = 2,
                Naziv = "Azija"

            };
            modelBuilder.Entity<Kontinent>().HasData(kontinent2);
            API.Database.Uloga uloga = new API.Database.Uloga()
            {
                Id = 1,
                Naziv = "Admin"

            };
            modelBuilder.Entity<Uloga>().HasData(uloga);

            API.Database.Uloga uloga2 = new API.Database.Uloga()
            {
                Id = 2,
                Naziv = "Turist"

            };
            modelBuilder.Entity<Uloga>().HasData(uloga2);
           API.Database.Ocjena ocjena = new API.Database.Ocjena()
            {
                Id=1,
                KorisnikId = 2,
                Komentar = "Odlicno",
                DestinacijaId = 1,
                OcjenaUsluge = 5,

            };

            modelBuilder.Entity<Ocjena>().HasData(ocjena);
            API.Database.Rezervacija rezervacija = new API.Database.Rezervacija()
            {
                Id=1,
                KorisnikId = 2,
                Otkazana = false,
                DatumRezervacije = new DateTime(2020, 09, 01),
                HotelId = 1,
                Cijena = 300

            };

            modelBuilder.Entity<Rezervacija>().HasData(rezervacija);
            API.Database.Uposlenik uposlenik = new API.Database.Uposlenik()
            {
                Id=1,
                KorisnikId = 1,
                Aktivan = true,
                DatumZaposlenja = new DateTime(2020, 09, 01)

            };

            modelBuilder.Entity<Uposlenik>().HasData(uposlenik);
           
            API.Database.Karta karta = new API.Database.Karta()
            {
                Id=1,
                KorisnikId = 2,
                TerminId = 1,
                DatumKreiranja = new DateTime(2020, 09, 01)

            };

            modelBuilder.Entity<Karta>().HasData(karta);
            API.Database.Drzava drzava = new API.Database.Drzava()
            {
                Id = 1,
                Naziv = "Turska",
                KontinentId = 1

            };

            modelBuilder.Entity<Drzava>().HasData(drzava);

            API.Database.Drzava drzava2 = new API.Database.Drzava()
            {
                Id = 2,
                Naziv = "Malezija",
                KontinentId = 2

            };

            modelBuilder.Entity<Drzava>().HasData(drzava2);

           API.Database.Grad grad = new API.Database.Grad()
            {
                Id = 1,
                DrzavaId = 1,
                Naziv = "Istanbul"

            };

            modelBuilder.Entity<Grad>().HasData(grad);

            API.Database.Grad grad2 = new API.Database.Grad()
            {
                Id = 2,
                DrzavaId = 2,
                Naziv = "Kuala Lumpur"

            };

            modelBuilder.Entity<Grad>().HasData(grad2);


            API.Database.Hotel hotel = new API.Database.Hotel()
            {
                Id = 1,
                Naziv = "Levent",
                BrojZvjezdica = 5,
                GradId = 2,
                Slika = File.ReadAllBytes("img/265297041.jpg"),


            };
            modelBuilder.Entity<Hotel>().HasData(hotel);

            API.Database.Hotel hotel2 = new API.Database.Hotel()
            {
                Id = 2,
                Naziv = "Hotel Malezija",
                BrojZvjezdica = 4,
                GradId = 1,
                Slika = File.ReadAllBytes("img/6c31f0af8779f447907db3bb5c893055.jpg")


            };
            modelBuilder.Entity<Hotel>().HasData(hotel2);

            

            API.Database.Destinacija destinacija = new API.Database.Destinacija()
            {
                Id = 1,
                Naziv = "Putovanje u Maleziju",
                GradId = 2,
                Slika= File.ReadAllBytes("img/6c31f0af8779f447907db3bb5c893055.jpg")

            };
            modelBuilder.Entity<Destinacija>().HasData(destinacija);

            API.Database.Destinacija destinacija2 = new API.Database.Destinacija()
            {
                Id = 2,
                Naziv = "Putovanje u Istanbul",
                GradId = 1,
                Slika = File.ReadAllBytes("img/265297041.jpg"),


            };
            modelBuilder.Entity<Destinacija>().HasData(destinacija2);
            API.Database.Destinacija destinacija3 = new API.Database.Destinacija()
            {
                Id = 3,
                Naziv = "Putovanje u Istanbul2",
                GradId = 1,
                Slika = File.ReadAllBytes("img/265297041.jpg"),

            };
            modelBuilder.Entity<Destinacija>().HasData(destinacija3);
            API.Database.Destinacija destinacija4 = new API.Database.Destinacija()
            {
                Id = 4,
                Naziv = "Putovanje u Maleziju2",
                GradId = 2,
                Slika = File.ReadAllBytes("img/6c31f0af8779f447907db3bb5c893055.jpg")

            };
            modelBuilder.Entity<Destinacija>().HasData(destinacija4);

            API.Database.Termin termin = new API.Database.Termin()
            {
                Id = 1,
                DestinacijaId = 1,
                AktivanTermin = true,
                Cijena = 900,
                CijenaPopust = 0,
                Popust = 0,
                HotelId = 1,
                GradId = 2,
                DatumPolaska = new DateTime(2021, 08, 15),
                DatumDolaska = new DateTime(2021, 08, 20)

            };
            modelBuilder.Entity<Termin>().HasData(termin);
            
            API.Database.Termin termin2 = new API.Database.Termin()
            {
                Id = 2,
                DestinacijaId = 1,
                AktivanTermin = true,
                Cijena = 700,
                CijenaPopust = 0,
                Popust = 0,
                HotelId = 1,
                GradId = 2,
                DatumPolaska = new DateTime(2021, 09, 03),
                DatumDolaska = new DateTime(2021, 09, 10)

            };
            modelBuilder.Entity<Termin>().HasData(termin2);

            API.Database.Termin termin3 = new API.Database.Termin()
            {
                Id = 3,
                DestinacijaId = 2,
                AktivanTermin = true,
                Cijena = 1100,
                CijenaPopust = 0,
                Popust = 0,
                HotelId = 1,
                GradId = 2,
                DatumPolaska = new DateTime(2022, 01, 19),
                DatumDolaska = new DateTime(2022, 01, 27)

            };
            modelBuilder.Entity<Termin>().HasData(termin3);

            API.Database.Termin termin4 = new API.Database.Termin()
            {
                Id = 4,
                DestinacijaId = 2,
                AktivanTermin = true,
                Cijena = 1300,
                CijenaPopust = 0,
                Popust = 0,
                HotelId = 1,
                GradId = 2,
                DatumPolaska = new DateTime(2021, 07, 25),
                DatumDolaska = new DateTime(2021, 08, 02)

            };
            modelBuilder.Entity<Termin>().HasData(termin4);

            API.Database.Termin termin5 = new API.Database.Termin()
            {
                Id = 5,
                DestinacijaId = 3,
                AktivanTermin = true,
                Cijena = 1300,
                CijenaPopust = 0,
                Popust = 0,
                HotelId = 2,
                GradId = 1,
                DatumPolaska = new DateTime(2022, 03, 15),
                DatumDolaska = new DateTime(2022, 04, 22)

            };
            modelBuilder.Entity<Termin>().HasData(termin5);
            API.Database.Termin termin6 = new API.Database.Termin()
            {
                Id = 6,
                DestinacijaId = 3,
                AktivanTermin = true,
                Cijena = 1200,
                CijenaPopust = 0,
                Popust = 0,
                HotelId = 2,
                GradId = 1,
                DatumPolaska = new DateTime(2021, 06, 21),
                DatumDolaska = new DateTime(2021, 07, 25)

            };
            modelBuilder.Entity<Termin>().HasData(termin6);

            API.Database.Termin termin7 = new API.Database.Termin()
            {
                Id = 7,
                DestinacijaId = 4,
                AktivanTermin = true,
                Cijena = 1500,
                CijenaPopust = 0,
                Popust = 0,
                HotelId = 2,
                GradId = 1,
                DatumPolaska = new DateTime(2021, 07, 15),
                DatumDolaska = new DateTime(2021, 08, 15)

            };
            modelBuilder.Entity<Termin>().HasData(termin7);
          

            API.Database.Korisnik korisnik = new API.Database.Korisnik()
            {
                Id = 1,
                Ime = "Nijaz",
                Prezime = "Ljevo",
                KorisnikoIme = "admin",
                Email = "nijaz@gmail.com",
                UlogaId = 1,
                Slika = File.ReadAllBytes("img/user-icon-vector-5770409.jpg"),


            };
            korisnik.LozinkaSalt = GenerateSalt();
            korisnik.LozinkaHash = GenerateHash(korisnik.LozinkaSalt, "test");
            modelBuilder.Entity<Korisnik>().HasData(korisnik);

            API.Database.Korisnik korisnik2 = new API.Database.Korisnik()
            {
                Id = 2,
                Ime = "Amna",
                Prezime = "Spahalic",
                KorisnikoIme = "mobile",
                Email = "amna@gmail.com",
                UlogaId = 2,
                Slika = File.ReadAllBytes("img/user-icon-vector-5770409.jpg"),


            };
            korisnik2.LozinkaSalt = GenerateSalt();
            korisnik2.LozinkaHash = GenerateHash(korisnik2.LozinkaSalt, "test");
            modelBuilder.Entity<Korisnik>().HasData(korisnik2);
        }
    }
}
