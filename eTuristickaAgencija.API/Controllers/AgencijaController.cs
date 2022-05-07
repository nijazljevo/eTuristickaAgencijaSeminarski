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
    public class AgencijaController : BaseCRUDController<Models.Agencija, AgencijaSearchRequest, AgencijaInsertRequest, AgencijaInsertRequest>
    {
        public AgencijaController(ICRUDService<Agencija, AgencijaSearchRequest, AgencijaInsertRequest, AgencijaInsertRequest> service) : base(service)
        {

        }
    }
}
