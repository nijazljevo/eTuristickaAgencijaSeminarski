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
    public class KarteController : BaseCRUDController<Models.Karta, KartaSearchRequest, KartaInsertRequest, KartaInsertRequest>
    {
        public KarteController(ICRUDService<Karta, KartaSearchRequest, KartaInsertRequest, KartaInsertRequest> service) : base(service)
        {

        }
    }
}
