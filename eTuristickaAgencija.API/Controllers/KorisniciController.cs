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
    [Route("api/[controller]")]
    
    public class KorisniciController : ControllerBase
    {

        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }
        //[Authorize(Roles ="Uposlenik")]
        [HttpGet]
        public ActionResult<List<Models.Korisnik>> Get([FromQuery] KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Korisnik> GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public ActionResult<Models.Korisnik> Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public ActionResult<Models.Korisnik> Update(int id, [FromBody] KorisniciInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
