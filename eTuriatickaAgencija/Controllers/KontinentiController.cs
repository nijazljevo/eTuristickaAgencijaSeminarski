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
    public class KontinentiController : BaseCRUDController<eTuristickaAgencija.Models.Kontinent, KontinentSearchObject, KontinentInsertRequest, KontinentUpdateRequest>
    {
        public KontinentiController(IKontinentService kontinentService) : base(kontinentService)
        {
        }

        //Dodavanje bez authorizacije
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Kontinent Insert([FromBody] KontinentInsertRequest kontinentInsertRequest)
        {
            return base.Insert(kontinentInsertRequest);
        }
    }
}
