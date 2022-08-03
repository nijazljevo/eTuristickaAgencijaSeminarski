using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eTuristickaAgencija.API.Services
{
    public class RezervacijaService : BaseCRUDService<Models.Rezervacija, RezervacijaSearchRequest, Database.Rezervacija, RezervacijaInsertRequest, RezervacijaInsertRequest>
    {
        public RezervacijaService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Rezervacija> Get(RezervacijaSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Rezervacija>().AsQueryable();
            if (search.Id != 0)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.HotelId != 0)
            {
                query = query.Where(x => x.HotelId == search.HotelId);
            }
            if (search.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }
            if (search.DatumRezervacije.HasValue)
            {
                query = query.Where(x => x.DatumRezervacije.Date == search.DatumRezervacije.Value.Date);
            }

            if (search.Cijena != 0)
            {
                query = query.Where(x => x.Cijena <= search.Cijena);
            }
            if (search.Otkazana == true || search.Otkazana == false)
            {
                query = query.Where(x => x.Otkazana == search.Otkazana);
            }


            var list = query.ToList();
            return _mapper.Map<List<Models.Rezervacija>>(list);
        }

        public override Models.Rezervacija Update(int id, RezervacijaInsertRequest insert)
        {
            var entitet = _turistickacontext.Set<Database.Rezervacija>().Find(id);
            entitet.HotelId = insert.HotelId;
            entitet.Otkazana = insert.Otkazana;
            entitet.Cijena = insert.Cijena;
            entitet.DatumRezervacije = insert.DatumRezervacije;
            entitet.KorisnikId = insert.KorisnikId;
            _turistickacontext.Set<Database.Rezervacija>().Attach(entitet);
            _turistickacontext.Set<Database.Rezervacija>().Update(entitet);
            _mapper.Map(entitet, insert);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Rezervacija>(entitet);
        }
    }
}
