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
    public class TerminiController : BaseCRUDController<Models.Termin, TerminSearchRequest, TerminInsertRequest, TerminInsertRequest>
    {
        public TerminiController(ICRUDService<Termin, TerminSearchRequest, TerminInsertRequest, TerminInsertRequest> service) : base(service)
        {
        }
    }
}
