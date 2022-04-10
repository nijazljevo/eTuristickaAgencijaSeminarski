using AutoMapper;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    
    public class BaseController<T, TSearch> : ControllerBase
    {

        private readonly IService<T, TSearch> _service;
        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<T>> Get([FromQuery] TSearch search)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<T> GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
