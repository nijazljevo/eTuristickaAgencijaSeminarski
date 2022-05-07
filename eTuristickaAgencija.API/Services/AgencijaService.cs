using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class AgencijaService : BaseCRUDService<Models.Agencija, AgencijaSearchRequest, Database.Agencija, AgencijaInsertRequest, AgencijaInsertRequest>
    {
        public AgencijaService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Agencija> Get(AgencijaSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Agencija>().AsQueryable();

            query = query.Where(x => x.Id == search.Id);

            var list = query.ToList();
            return _mapper.Map<List<Models.Agencija>>(list);
        }

        public override Models.Agencija Update(int id, AgencijaInsertRequest request)
        {
            var entitet = _turistickacontext.Set<Database.Agencija>().Find(id);
            entitet.Email = request.Email;
            entitet.Adresa = request.Adresa;
            entitet.Telefon = request.Telefon;
            _turistickacontext.Set<Database.Agencija>().Attach(entitet);
            _turistickacontext.Set<Database.Agencija>().Update(entitet);
            _mapper.Map(entitet, request);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Agencija>(entitet);
        }

      
    }
}
