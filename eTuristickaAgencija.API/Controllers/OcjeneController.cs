using eTuristickaAgencija.API.Services;
using eTuristickaAgencija.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Controllers
{
    [ApiController]
    public class OcjeneController : BaseCRUDController<Models.Ocjena, OcjenaSearchRequest, OcjenaInsertRequest, OcjenaInsertRequest>
    {
        public OcjeneController(ICRUDService<Models.Ocjena, OcjenaSearchRequest, OcjenaInsertRequest, OcjenaInsertRequest> service) : base(service)
        {
        }
    }
}
