using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class DestinacijeService : BaseCRUDService<Models.Destinacija, DestinacijaSearchRequest, Database.Destinacija, DestinacijaInsertRequest, DestinacijaInsertRequest>
    {
        public DestinacijeService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Destinacija> Get(DestinacijaSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Destinacija>().AsQueryable();
            if (search.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }
            if (search.GradId != 0)
            {
                query = query.Where(x => x.GradId == search.GradId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Models.Destinacija>>(list);
        }


        public override Models.Destinacija Update(int id, DestinacijaInsertRequest request)
        {
            var entitet = _turistickacontext.Set<Database.Destinacija>().Find(id);
            entitet.Slika = request.Slika;
            entitet.Naziv = request.Naziv;
            entitet.GradId = request.GradId;
            _turistickacontext.Set<Database.Destinacija>().Attach(entitet);
            _turistickacontext.Set<Database.Destinacija>().Update(entitet);
            _mapper.Map(entitet, request);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Destinacija>(entitet);
        }

        public override bool Delete(int id)
        {
            var entitet = _turistickacontext.Set<Database.Destinacija>().Find(id);
            if (entitet != null)
            {
                _turistickacontext.Set<Database.Destinacija>().Remove(entitet);
                _turistickacontext.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
