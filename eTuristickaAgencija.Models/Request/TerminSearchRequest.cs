using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Models.Request
{
    public class TerminSearchRequest
    {
        public int DestinacijaId { get; set; }
        public DateTime? DatumPolaska { get; set; }
        public DateTime? DatumDolaska { get; set; }
        public decimal Cijena { get; set; }

        public bool Aktivan { get; set; }
    }
}
