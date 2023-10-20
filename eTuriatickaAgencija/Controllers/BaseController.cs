using eTuristickaAgencija.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTuriatickaAgencija.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseCRUDController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IService<T, TSearch> Service { get; set; }

        public BaseCRUDController(IService<T, TSearch> service)
        {
            Service = service;
        }

        //Add GetById 
        [HttpGet]
        public IEnumerable<T> Get([FromQuery] TSearch search = null)
        {
            return Service.Get(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return Service.GetById(id);
        }
    }
}
