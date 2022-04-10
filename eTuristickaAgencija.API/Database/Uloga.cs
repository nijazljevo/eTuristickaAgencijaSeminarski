using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
