using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Models.Request
{
    public class OcjenaInsertRequest
    {
        //public int Id { get; set; }
        public int? KorisnikId{ get; set; }
        public int? DestinacijaId { get; set; }
        public int OcjenaUsluge { get; set; }
        public string Komentar { get; set; }
    }
}
