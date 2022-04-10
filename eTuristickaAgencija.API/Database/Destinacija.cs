using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Destinacija
    {
        public Destinacija()
        {
            Ocjena = new HashSet<Ocjena>();
            Termin = new HashSet<Termin>();
        }

        public int Id { get; set; }
        public byte[] Slika { get; set; }
        public string Naziv { get; set; }
        public int? GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<Termin> Termin { get; set; }
    }
}
