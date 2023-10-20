using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.Models.Search_Objects;
using eTuristickaAgencija.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTuriatickaAgencija.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class RezervacijaController : BaseCRUDController<eTuristickaAgencija.Models.Rezervacija, RezervacijaSearchObject, RezervacijaInsertRequest, RezervacijaUpdateRequest>
    {
        public RezervacijaController(IRezervacijaService rezervacijaService) : base(rezervacijaService)
        {
        }

        //Dodavanje bez authorizacije
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Rezervacija Insert([FromBody] RezervacijaInsertRequest rezervacijaInsertRequest)
        {
            return base.Insert(rezervacijaInsertRequest);
        }
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Rezervacija Update(int id,[FromBody] RezervacijaUpdateRequest rezervacijaUpdateRequest)
        {
            return base.Update(id,rezervacijaUpdateRequest);
        }

    }
}
