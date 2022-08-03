using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class ClanoviService : BaseCRUDService<Models.Clan, ClanSearchRequest, Database.Clan, ClanInsertRequest, ClanInsertRequest>
    {
        public ClanoviService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Clan> Get(ClanSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Clan>().AsQueryable();
            if (search.ID != 0)
            {
                query = query.Where(x => x.Id == search.ID);
            }
            var list = query.ToList();
            return _mapper.Map<List<Models.Clan>>(list);
        }
        public override Models.Clan Update(int id, ClanInsertRequest insert)
        {
            var entitet = _turistickacontext.Set<Database.Clan>().Find(id);
            entitet.DatumRegistracije = insert.DatumRegistracije;
            entitet.KorisnikId = insert.KorisnikId;
            _turistickacontext.Set<Database.Clan>().Attach(entitet);
            _turistickacontext.Set<Database.Clan>().Update(entitet);
            _mapper.Map(entitet, insert);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Clan>(entitet);
        }
    }
}
