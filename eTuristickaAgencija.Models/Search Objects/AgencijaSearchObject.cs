﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Models.Search_Objects
{
    public class AgencijaSearchObject : BaseSearchObject
    {
        public int Id { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
       


    }
}
