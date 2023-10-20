﻿using AutoMapper;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.Models.Search_Objects;
using eTuristickaAgencija.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.Service
{
     public class HoteliService
       : BaseCRUDService<Models.Hotel, Hotel, HotelSearchObject, HotelInsertRequest, HotelUpdateRequest>, IHotelService
    {

        public HoteliService(TuristickaAgencijaContext eContext, IMapper mapper) : base(eContext, mapper)
        {
        }

        public override IQueryable<Hotel> AddFilter(IQueryable<Hotel> query, HotelSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (search.Id != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.Id == search.Id);
            }


            if (!string.IsNullOrEmpty(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv == search.Naziv);
            }
            if (search?.GradId != 0)
            {
                filteredQuery = filteredQuery.Where(x => x.GradId == search.GradId);
            }
            

            return filteredQuery;
        }
    }
}
