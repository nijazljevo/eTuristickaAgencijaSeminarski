using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Mobile.Models
{
    public class TerminDetaljiModels
    {
        public int Id { get; set; }
        public int DestinacijaId { get; set; }
        public decimal Cijena { get; set; }
        public float? Popust { get; set; }
        public string HotelNaziv { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumDolaska { get; set; }
        public string GradNaziv { get; set; }
        public byte[] HotelSlika { get; set; }

        public int BrojZvjezdica { get; set; }
    }
}
