using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Destinacije,
        MojiPodaci,
        Preporuka,
        Pocetna,
        MojProfil
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
