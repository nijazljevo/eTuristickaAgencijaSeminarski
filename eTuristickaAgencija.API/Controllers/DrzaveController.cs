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
    public class DrzaveController : BaseCRUDController<Drzava, DrzavaSearchRequest, DrzavaInsertRequest, DrzavaInsertRequest>
    {
        public DrzaveController(ICRUDService<Drzava, DrzavaSearchRequest, DrzavaInsertRequest, DrzavaInsertRequest> service) : base(service)
        {
        }


    }
}
