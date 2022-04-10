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
    public class GradoviController : BaseCRUDController<Models.Grad, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest>
    {
        public GradoviController(ICRUDService<Grad, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest> service) : base(service)
        {

        }
    }
}
