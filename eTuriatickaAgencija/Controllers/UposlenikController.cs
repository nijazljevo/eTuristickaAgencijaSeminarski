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
    public class UposlenikController : BaseCRUDController<eTuristickaAgencija.Models.Uposlenik, UposlenikSearchObject, UposlenikInsertRequest, UposlenikUpdateRequest>
    {
        public UposlenikController(IUposlenikService uposlenikService) : base(uposlenikService)
        {
        }

        //Dodavanje bez authorizacije
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Uposlenik Insert([FromBody] UposlenikInsertRequest uposlenikInsertRequest)
        {
            return base.Insert(uposlenikInsertRequest);
        }
    }
}
