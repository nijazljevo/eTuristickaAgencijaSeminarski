using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTuristickaAgencija.Models.Request
{
    public class HotelInsertRequest
    {
        public int Id { get; set; }
        //public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
        [Required]
        public int GradId { get; set; }
        [Range(1,5,ErrorMessage ="Brojevi od 1 do 5")]
        public int BrojZvjezdica { get; set; }
    }
}
