using AutoMapper;
using Microsoft.AspNetCore.Http;
using eTuristickaAgencija.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreporukeController : ControllerBase
    {
        private readonly IPreporukaService _preporukaService;
        //private readonly IMapper _mapper;

        public PreporukeController(IPreporukaService service)
        {
            _preporukaService = service;

        }

        [HttpGet("{id}")]
        public List<Models.Destinacija> Get(int id)
        {
            return _preporukaService.GetPreporuka(id);

        }

    }
}
