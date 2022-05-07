using System;
using System.Collections.Generic;

namespace eTuristickaAgencija.API.Database
{
    public partial class Agencija
    {
        public int Id { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
