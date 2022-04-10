using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Termin
    {
        public Termin()
        {
            Karta = new HashSet<Karta>();
        }

        public int Id { get; set; }
        public int? DestinacijaId { get; set; }
        public decimal Cijena { get; set; }
        public float? Popust { get; set; }
        public int? HotelId { get; set; }
        public decimal? CijenaPopust { get; set; }
        public bool? AktivanTermin { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumDolaska { get; set; }
        public int? GradId { get; set; }

        public virtual Destinacija Destinacija { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Karta> Karta { get; set; }
    }
}
