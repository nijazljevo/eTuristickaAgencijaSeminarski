using AutoMapper;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, Models.Korisnik>();

            CreateMap<Database.Korisnik, KorisniciInsertRequest>().ReverseMap();
            CreateMap<Database.Korisnik, Models.Korisnik>().ReverseMap();


            CreateMap<Models.Grad, Database.Grad>(); //stavi database jer nekad ne proradi bez njega,pazi to i za Startup
            CreateMap<Database.Grad, Models.Grad>();
            CreateMap<Database.Destinacija, Models.Destinacija>();
            CreateMap<Database.Destinacija, DestinacijaInsertRequest>().ReverseMap();
            CreateMap<Models.Uloga, Database.Uloga>();
            CreateMap<Database.Uloga, Models.Uloga>();

            CreateMap<Database.Hotel, Models.Hotel>();
            CreateMap<Database.Hotel, HotelInsertRequest>().ReverseMap();
            CreateMap<Database.Hotel, Models.Hotel>().ReverseMap();
            CreateMap<Models.Hotel, HotelInsertRequest>();
            CreateMap<Models.Hotel, HotelInsertRequest>().ReverseMap();

            CreateMap<Database.Termin, Models.Termin>();
            CreateMap<Database.Termin, TerminInsertRequest>().ReverseMap();
            CreateMap<Database.Termin, Models.Termin>().ReverseMap();

            CreateMap<Database.Karta, Models.Karta>();
            CreateMap<Database.Karta, KartaInsertRequest>().ReverseMap();
            CreateMap<Database.Karta, Models.Karta>().ReverseMap();

            CreateMap<Database.Clan, Models.Clan>();
            CreateMap<Database.Clan, ClanInsertRequest>().ReverseMap();
            CreateMap<Database.Clan, Models.Clan>().ReverseMap();

            CreateMap<Database.Ocjena, Models.Ocjena>();
            CreateMap<Database.Ocjena, OcjenaInsertRequest>().ReverseMap();
            CreateMap<Database.Ocjena, Models.Ocjena>().ReverseMap();

            CreateMap<Database.Grad, Models.Grad>();
            CreateMap<Database.Grad, GradoviInsertRequest>().ReverseMap();
            CreateMap<Database.Grad, Models.Grad>().ReverseMap();

            CreateMap<Database.Drzava, Models.Drzava>();
            CreateMap<Database.Drzava, DrzavaInsertRequest>().ReverseMap();
            CreateMap<Database.Drzava, Models.Drzava>().ReverseMap();

            CreateMap<Database.Kontinent, Models.Kontinent>();
            CreateMap<Database.Kontinent, KontinentInsertRequest>().ReverseMap();
            CreateMap<Database.Kontinent, Models.Kontinent>().ReverseMap();

            CreateMap<Database.Rezervacija, Models.Rezervacija>();
            CreateMap<Database.Rezervacija, RezervacijaInsertRequest>().ReverseMap();
            CreateMap<Database.Rezervacija, Models.Rezervacija>().ReverseMap();

            CreateMap<Database.Uposlenik, Models.Uposlenik>();
            CreateMap<Database.Uposlenik, UposlenikInsertRequest>().ReverseMap();
            CreateMap<Database.Uposlenik, Models.Uposlenik>().ReverseMap();

            CreateMap<Database.Agencija, Models.Agencija>();
            CreateMap<Database.Agencija, AgencijaInsertRequest>().ReverseMap();
            CreateMap<Database.Agencija, Models.Agencija>().ReverseMap();

            

        }

    }
}
