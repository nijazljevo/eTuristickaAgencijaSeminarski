using System;
using System.Collections.Generic;
using System.Text;

namespace eTuristickaAgencija.Mobile.Models
{
    public class ProbniModels
    {
        public int Id { get; set; }
        public byte[] Slika { get; set; }
        public string Naziv { get; set; }
        public int GradId { get; set; }

        public int CijenaProdatihKarataDestinacije { get; set; }
    }
}
