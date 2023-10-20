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
    public class HoteliController : BaseCRUDController<eTuristickaAgencija.Models.Hotel, HotelSearchObject, HotelInsertRequest, HotelUpdateRequest>
    {
        public HoteliController(IHotelService hotelService) : base(hotelService)
        {
        }

        //Dodavanje bez authorizacije
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Hotel Insert([FromBody] HotelInsertRequest hotelInsertRequest)
        {
            return base.Insert(hotelInsertRequest);
        }
    }
}