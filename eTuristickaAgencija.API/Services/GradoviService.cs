using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class GradoviService : BaseCRUDService<Models.Grad, GradoviSearchRequest, Database.Grad, GradoviInsertRequest, GradoviInsertRequest>
    {
        public GradoviService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Grad> Get(GradoviSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Grad>().AsQueryable();
            if (search.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }
            if (search.DrzavaId != 0)
            {
                query = query.Where(x => x.DrzavaId == search.DrzavaId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Models.Grad>>(list);
        }

        public override Models.Grad Update(int id, GradoviInsertRequest request)
        {
            var entitet = _turistickacontext.Set<Database.Grad>().Find(id);
            entitet.Naziv = request.Naziv;
            entitet.DrzavaId = request.DrzavaId;
            _turistickacontext.Set<Database.Grad>().Attach(entitet);
            _turistickacontext.Set<Database.Grad>().Update(entitet);
            _mapper.Map(entitet, request);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Grad>(entitet);
        }

        public override bool Delete(int id)
        {
            var entitet = _turistickacontext.Set<Database.Grad>().Find(id);
            if (entitet != null)
            {
                _turistickacontext.Set<Database.Grad>().Remove(entitet);
                _turistickacontext.SaveChanges();
                return true;

            }
            return false;
        }

    }
}
