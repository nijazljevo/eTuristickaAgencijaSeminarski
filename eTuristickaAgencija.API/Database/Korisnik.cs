using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Clan = new HashSet<Clan>();
            Karta = new HashSet<Karta>();
            Ocjena = new HashSet<Ocjena>();
            Rezervacija = new HashSet<Rezervacija>();
            
            Uposlenik = new HashSet<Uposlenik>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnikoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public byte[] Slika { get; set; }
        public string Email { get; set; }
        public int? UlogaId { get; set; }

        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<Clan> Clan { get; set; }
        public virtual ICollection<Karta> Karta { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        
        public virtual ICollection<Uposlenik> Uposlenik { get; set; }
    }
}
