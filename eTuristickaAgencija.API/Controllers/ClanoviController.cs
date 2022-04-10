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
    public class ClanoviController : BaseCRUDController<Models.Clan, ClanSearchRequest, ClanInsertRequest, ClanInsertRequest>
    {
        public ClanoviController(ICRUDService<Clan, ClanSearchRequest, ClanInsertRequest, ClanInsertRequest> service) : base(service)
        {

        }
    }
}
