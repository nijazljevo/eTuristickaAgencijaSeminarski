using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Destinacija = new HashSet<Destinacija>();
            Hotel = new HashSet<Hotel>();
            Termin = new HashSet<Termin>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Destinacija> Destinacija { get; set; }
        public virtual ICollection<Hotel> Hotel { get; set; }
        public virtual ICollection<Termin> Termin { get; set; }
    }
}
