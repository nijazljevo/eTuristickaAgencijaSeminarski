using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Karta
    {
        public int Id { get; set; }
        public int? TerminId { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public bool Ponistena { get; set; }
        public int? KorisnikId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Termin Termin { get; set; }
    }
}
