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
    public class KontinentiController : BaseCRUDController<Kontinent, KontinentSearchRequest, KontinentInsertRequest, KontinentInsertRequest>
    {
        public KontinentiController(ICRUDService<Kontinent, KontinentSearchRequest, KontinentInsertRequest, KontinentInsertRequest> service) : base(service)
        {
        }
    }
}
