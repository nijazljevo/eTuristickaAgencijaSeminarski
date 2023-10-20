﻿using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.Models.Search_Objects;
using eTuristickaAgencija.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTuriatickaAgencija.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class ClanoviController : BaseCRUDController<eTuristickaAgencija.Models.Clan, ClanSearchObject, ClanInsertRequest, ClanUpdateRequest>
    {
        public ClanoviController(IClanService clanServis) : base(clanServis)
        {
        }

        //Dodavanje bez authorizacije
        [AllowAnonymous]
        public override eTuristickaAgencija.Models.Clan Insert([FromBody] ClanInsertRequest clanInsertRequest)
        {
            return base.Insert(clanInsertRequest);
        }
    }
}
