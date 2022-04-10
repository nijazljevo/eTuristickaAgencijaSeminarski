using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rezervacija = new HashSet<Rezervacija>();
            Termin = new HashSet<Termin>();
        }

        public int Id { get; set; }
        public byte[] Slika { get; set; }
        public string Naziv { get; set; }
        public int? GradId { get; set; }
        public int? BrojZvjezdica { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Termin> Termin { get; set; }
    }
}
