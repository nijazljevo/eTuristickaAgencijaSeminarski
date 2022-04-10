using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class TerminiService : BaseCRUDService<Models.Termin, TerminSearchRequest, Database.Termin, TerminInsertRequest, TerminInsertRequest>
    {
        public TerminiService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Models.Termin> Get(TerminSearchRequest search)
        {
            var query = _turistickacontext.Set<Database.Termin>().AsQueryable();
            if (search.DestinacijaId != 0)
            {
                query = query.Where(x => x.DestinacijaId == search.DestinacijaId);
            }
           
            if (search.DatumPolaska.HasValue)
            {
                query = query.Where(x => x.DatumPolaska.Date >= search.DatumPolaska.Value.Date);
            }
            if (search.DatumDolaska.HasValue)
            {
                query = query.Where(x => x.DatumDolaska.Date <= search.DatumDolaska.Value.Date);
            }
            if (search.Cijena != 0)
            {
                query = query.Where(x => x.Cijena <= search.Cijena);
            }
            if (search.Aktivan == true || search.Aktivan == false)
            {
                query = query.Where(x => x.AktivanTermin == search.Aktivan);
            }


            var list = query.ToList();
            return _mapper.Map<List<Models.Termin>>(list);
        }

        public override Models.Termin Update(int id, TerminInsertRequest insert)
        {
            var entitet = _turistickacontext.Set<Database.Termin>().Find(id);
            entitet.HotelId = insert.HotelId;
            entitet.AktivanTermin = insert.AktivanTermin;
            entitet.Cijena = insert.Cijena;
            entitet.Popust = insert.Popust;
            entitet.CijenaPopust = insert.CijenaPopust;
            entitet.DatumDolaska = insert.DatumDolaska;
            entitet.DatumPolaska = insert.DatumPolaska;
            entitet.DestinacijaId = insert.DestinacijaId;
            _turistickacontext.Set<Database.Termin>().Attach(entitet);
            _turistickacontext.Set<Database.Termin>().Update(entitet);
            _mapper.Map(entitet, insert);
            _turistickacontext.SaveChanges();
            return _mapper.Map<Models.Termin>(entitet);
        }
    }
}
