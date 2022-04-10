using eTuristickaAgencija.API.Database;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace eTuristickaAgencija.API.Services
{
    public class BaseCRUDService<T, TSearch, TDatabase, TInsert, TUpdate> : BaseService<T, TSearch, TDatabase>, ICRUDService<T, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(TuristickaAgencijaContext context, IMapper mapper) : base(context, mapper)
        {
        }



        public virtual T Insert(TInsert request)
        {
            var entitet = _mapper.Map<TDatabase>(request);



            _turistickacontext.Set<TDatabase>().Add(entitet);
            _turistickacontext.SaveChanges();

            return _mapper.Map<T>(entitet);
        }
        public virtual T Update(int id, TUpdate request)
        {
            var entitet = _turistickacontext.Set<TDatabase>().Find(id);

            _turistickacontext.Set<TDatabase>().Attach(entitet);
            _turistickacontext.Set<TDatabase>().Update(entitet);
            _mapper.Map(request, entitet);
            _turistickacontext.SaveChanges();
            return _mapper.Map<T>(entitet);
        }
        [HttpDelete]
        public virtual bool Delete(int id)
        {
            var entitet = _turistickacontext.Set<TDatabase>().Find(id);
            if (entitet != null)
            {
                _turistickacontext.Set<TDatabase>().Remove(entitet);
                _turistickacontext.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
