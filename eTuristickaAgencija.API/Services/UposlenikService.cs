using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class UposlenikService : BaseCRUDService<Models.Uposlenik, UposlenikSearchRequest, Database.Uposlenik, UposlenikInsertRequest, UposlenikInsertRequest>
    {
        public UposlenikService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Uposlenik> Get(UposlenikSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Uposlenik>().AsQueryable();
            if (search.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }
            if (search.DatumZaposlenja.HasValue)
            {
                query = query.Where(x => x.DatumZaposlenja.Value.Date == search.DatumZaposlenja.Value.Date);
            }


            if (search.Aktivan == true || search.Aktivan == false)
            {
                query = query.Where(x => x.Aktivan == search.Aktivan);
            }

            var list = query.ToList();
            return _mapper.Map<List<Models.Uposlenik>>(list);
        }


        public override Models.Uposlenik Update(int id, UposlenikInsertRequest request)
        {
            var entitet = _turistickacontext.Set<Database.Uposlenik>().Find(id);
            entitet.KorisnikId = request.KorisnikId;
            entitet.Aktivan = request.Aktivan;
            entitet.DatumZaposlenja = request.DatumZaposlenja;
            _turistickacontext.Set<Database.Uposlenik>().Attach(entitet);
            _turistickacontext.Set<Database.Uposlenik>().Update(entitet);
            _mapper.Map(entitet, request);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Uposlenik>(entitet);
        }

        public override bool Delete(int id)
        {
            var entitet = _turistickacontext.Set<Database.Uposlenik>().Find(id);
            if (entitet != null)
            {
                _turistickacontext.Set<Database.Uposlenik>().Remove(entitet);
                _turistickacontext.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
