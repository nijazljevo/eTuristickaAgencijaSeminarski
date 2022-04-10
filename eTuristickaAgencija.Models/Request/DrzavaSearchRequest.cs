using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Models.Request
{
    public class DrzavaSearchRequest
    {
       
        public string Naziv { get; set; }
        public int? KontinentId { get; set; }
    }
}
