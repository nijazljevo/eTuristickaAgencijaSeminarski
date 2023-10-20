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
    public class DrzaveController : BaseCRUDController<eTuristickaAgencija.Models.Drzava, DrzavaSearchObject, DrzavaInsertRequest, DrzavaUpdateRequest>
    {
        public DrzaveController(IDrzavaService drzavaService) : base(drzavaService)
        {
        }

        //Dodavanje bez authorizacije
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Drzava Insert([FromBody] DrzavaInsertRequest drzavaInsertRequest)
        {
            return base.Insert(drzavaInsertRequest);
        }
    }
}
