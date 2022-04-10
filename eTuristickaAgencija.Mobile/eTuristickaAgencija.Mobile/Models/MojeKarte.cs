using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Mobile.Models
{
    public class MojeKarte
    {
        public int KartaId { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumDolaska { get; set; }
        public string NazivHotela { get; set; }
        public int BrojZvjezdica { get; set; }
        public string NazivPutovanja { get; set; }

        public decimal Cijena { get; set; }

    }
}
