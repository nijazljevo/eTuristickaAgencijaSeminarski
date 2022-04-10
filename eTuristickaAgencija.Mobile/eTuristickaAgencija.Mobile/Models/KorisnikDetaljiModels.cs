using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Mobile.Models
{
    public class KorisnikDetaljiModels
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnikoIme { get; set; }
        public byte[] Slika { get; set; }
        public string Email { get; set; }

    }
}
