using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class DrzaveService : BaseCRUDService<Models.Drzava, DrzavaSearchRequest, Database.Drzava, DrzavaInsertRequest, DrzavaInsertRequest>
    {
        public DrzaveService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Drzava> Get(DrzavaSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Drzava>().AsQueryable();
            if (search.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }
            if (search.KontinentId != 0)
            {
                query = query.Where(x => x.KontinentId == search.KontinentId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Models.Drzava>>(list);
        }

        public override Models.Drzava Update(int id, DrzavaInsertRequest request)
        {
            var entitet = _turistickacontext.Set<Database.Drzava>().Find(id);
            entitet.Naziv = request.Naziv;
            entitet.KontinentId = request.KontinentId;
            _turistickacontext.Set<Database.Drzava>().Attach(entitet);
            _turistickacontext.Set<Database.Drzava>().Update(entitet);
            _mapper.Map(entitet, request);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Drzava>(entitet);
        }

        public override bool Delete(int id)
        {
            var entitet = _turistickacontext.Set<Database.Drzava>().Find(id);
            if (entitet != null)
            {
                _turistickacontext.Set<Database.Drzava>().Remove(entitet);
                _turistickacontext.SaveChanges();
                return true;

            }
            return false;
        }


    }
}
