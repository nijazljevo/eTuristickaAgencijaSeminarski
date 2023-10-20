using eTuristickaAgencija.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTuriatickaAgencija.Controllers
{
    [Authorize]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseCRUDController<T, TSearch>
        where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected new readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual T Insert([FromBody] TInsert insert)
        {
            var results = ((ICRUDService<T, TSearch, TInsert, TUpdate>)this.Service).Insert(insert);
            return results;
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public virtual T Update(int id, [FromBody] TUpdate update)
        {
            var results = ((ICRUDService<T, TSearch, TInsert, TUpdate>)this.Service).Update(id, update);
            return results;
        }
    }
}
