using eTuristickaAgencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public interface IPreporukaService
    {

        public List<Destinacija> GetPreporuka(int id);
    }
}
