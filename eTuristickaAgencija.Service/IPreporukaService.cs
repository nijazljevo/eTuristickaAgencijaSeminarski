using eTuristickaAgencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.Service
{
    public interface IPreporukaService
    {

        public List<Destinacija> GetPreporuka(int id);
    }
}
