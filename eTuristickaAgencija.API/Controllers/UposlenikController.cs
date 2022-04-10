using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Controllers
{
    [ApiController]
    public class UposlenikController : BaseCRUDController<Models.Uposlenik, UposlenikSearchRequest, UposlenikInsertRequest, UposlenikInsertRequest>
    {
        public UposlenikController(ICRUDService<Uposlenik, UposlenikSearchRequest, UposlenikInsertRequest, UposlenikInsertRequest> service) : base(service)
        {
        }
    }
}
