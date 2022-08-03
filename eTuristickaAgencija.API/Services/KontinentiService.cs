using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class KontinentiService : BaseCRUDService<Models.Kontinent, KontinentSearchRequest, Database.Kontinent, KontinentInsertRequest, KontinentInsertRequest>
    {
        public KontinentiService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Kontinent> Get(KontinentSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Kontinent>().AsQueryable();
            if (search.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            var list = query.ToList();
            return _mapper.Map<List<Models.Kontinent>>(list);
        }


        public override Models.Kontinent Update(int id, KontinentInsertRequest request)
        {
            var entitet = _turistickacontext.Set<Database.Kontinent>().Find(id);
            entitet.Naziv = request.Naziv;
            _turistickacontext.Set<Database.Kontinent>().Attach(entitet);
            _turistickacontext.Set<Database.Kontinent>().Update(entitet);
            _mapper.Map(entitet, request);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Kontinent>(entitet);
        }

        public override bool Delete(int id)
        {
            var entitet = _turistickacontext.Set<Database.Kontinent>().Find(id);
            if (entitet != null)
            {
                _turistickacontext.Set<Database.Kontinent>().Remove(entitet);
                _turistickacontext.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
