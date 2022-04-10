using eTuristickaAgencija.API.Services;
using eTuristickaAgencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Controllers
{
    public class UlogeController : BaseController<Models.Uloga, object>
    {
        public UlogeController(IService<Uloga, object> service) : base(service)
        {
        }
    }
}
