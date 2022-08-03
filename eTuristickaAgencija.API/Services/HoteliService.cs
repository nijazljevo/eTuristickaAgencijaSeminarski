using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class HoteliService : BaseCRUDService<Models.Hotel, HotelSearchRequest, Database.Hotel, HotelInsertRequest, HotelInsertRequest>
    {
        public HoteliService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Hotel> Get(HotelSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Hotel>().AsQueryable();
            if (search.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }


            if (search.GradId != null)
            {
                query = query.Where(x => x.GradId == search.GradId);
            }

            var list = query.ToList();
            return _mapper.Map<List<Models.Hotel>>(list);
        }

        public override Models.Hotel Update(int id, HotelInsertRequest request)
        {
            var entitet = _turistickacontext.Set<Database.Hotel>().Find(id);
            entitet.Naziv = request.Naziv;
            entitet.GradId = request.GradId;
            entitet.BrojZvjezdica = request.BrojZvjezdica;
            entitet.Slika = request.Slika;
            _turistickacontext.Set<Database.Hotel>().Attach(entitet);
            _turistickacontext.Set<Database.Hotel>().Update(entitet);
            _mapper.Map(entitet, request);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Hotel>(entitet);
        }
    }
}
