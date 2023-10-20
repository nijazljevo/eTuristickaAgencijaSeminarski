using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Search_Objects;
using eTuristickaAgencija.Service;

namespace eTuriatickaAgencija.Controllers
{
    public class UlogeController : BaseCRUDController<Uloga, UlogaSearchObject>
    {

        public UlogeController(IUlogeService ulogeService) : base(ulogeService)
        {
        }
    }
}
