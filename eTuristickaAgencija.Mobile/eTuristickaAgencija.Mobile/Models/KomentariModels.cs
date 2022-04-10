using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Mobile.Models
{
   public class KomentariModels
    {
        public int Id { get; set; }
        public int? KorisnikId { get; set; }
        public byte[] Slika { get; set; }
        public int? DestinacijaId { get; set; }
        public int OcjenaUsluge { get; set; }
        public string Komentar { get; set; }
        public string KorisnickoIme { get; set; }

        
    }
}
