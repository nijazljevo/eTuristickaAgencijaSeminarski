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
    //[Route("api/[controller]")]
    [ApiController]
    public class DestinacijeController : BaseCRUDController<Models.Destinacija, DestinacijaSearchRequest, DestinacijaInsertRequest, DestinacijaInsertRequest>
    {
        public DestinacijeController(ICRUDService<Destinacija, DestinacijaSearchRequest, DestinacijaInsertRequest, DestinacijaInsertRequest> service) : base(service)
        {

        }
    }
}
