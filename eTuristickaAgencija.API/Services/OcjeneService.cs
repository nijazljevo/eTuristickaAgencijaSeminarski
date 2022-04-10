using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class OcjeneService : BaseCRUDService<Models.Ocjena, OcjenaSearchRequest, Database.Ocjena, OcjenaInsertRequest, OcjenaInsertRequest>
    {
        public OcjeneService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Ocjena> Get(OcjenaSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Ocjena>().AsQueryable();
            if (search.DestinacijaID != 0)
            {
                query = query.Where(x => x.DestinacijaId == search.DestinacijaID);
            }
            var list = query.ToList();
            return _mapper.Map<List<Models.Ocjena>>(list);
        }
    }
}
