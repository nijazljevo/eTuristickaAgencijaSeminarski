using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public interface IKorisniciService
    {
        List<Models.Korisnik> Get(KorisniciSearchRequest request);
        Models.Korisnik GetById(int id);
        Models.Korisnik Insert(KorisniciInsertRequest request);

        bool Delete(int id);
        Models.Korisnik Update(int id, KorisniciInsertRequest request);

        Models.Korisnik Authentifikacija(string korisnickoime, string pass);
    }
}
