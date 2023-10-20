using eTuristickaAgencija.Service;
using Microsoft.AspNetCore.Mvc;

namespace eTuriatickaAgencija.Controllers
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
        public List<eTuristickaAgencija.Models.Destinacija> Get(int id)
        {
            return _preporukaService.GetPreporuka(id);

        }

    }
}
