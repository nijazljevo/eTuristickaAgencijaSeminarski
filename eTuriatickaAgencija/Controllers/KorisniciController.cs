using eTuristickaAgencija.Service;
using eTuristickaAgencija.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTuristickaAgencija.Models.Search_Objects;
using Microsoft.AspNetCore.Authorization;

namespace eTuriatickaAgencija.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class KorisniciController : BaseCRUDController<eTuristickaAgencija.Models.Korisnik, KorisnikSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        public KorisniciController(IKorisniciService korisniciServis) : base(korisniciServis)
        {
        }

        //Dodavanje bez authorizacije
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Korisnik Insert([FromBody] KorisniciInsertRequest korisnikInsertRequest)
        {
            return base.Insert(korisnikInsertRequest);
        }
    }
}
