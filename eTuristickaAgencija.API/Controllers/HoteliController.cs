using eTuristickaAgencija.API.Services;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Controllers
{
    [ApiController]
    public class HoteliController : BaseCRUDController<Models.Hotel, HotelSearchRequest, HotelInsertRequest, HotelInsertRequest>
    {
        public HoteliController(ICRUDService<Hotel, HotelSearchRequest, HotelInsertRequest, HotelInsertRequest> service) : base(service)
        {

        }
    }
}
