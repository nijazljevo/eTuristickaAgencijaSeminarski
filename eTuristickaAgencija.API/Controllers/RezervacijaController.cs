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
    public class RezervacijaController : BaseCRUDController<Models.Rezervacija, RezervacijaSearchRequest, RezervacijaInsertRequest, RezervacijaInsertRequest>
    {
        public RezervacijaController(ICRUDService<Rezervacija, RezervacijaSearchRequest, RezervacijaInsertRequest, RezervacijaInsertRequest> service) : base(service)
        {
        }
    }
}
