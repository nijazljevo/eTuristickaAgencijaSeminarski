using AutoMapper;
using eTuristickaAgencija.API.Database;
using eTuristickaAgencija.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.API.Services
{
    public class KorisniciService : IKorisniciService
    {
        protected readonly TuristickaAgencijaContext _context;
        protected readonly IMapper _mapper;
        public KorisniciService(TuristickaAgencijaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public List<Models.Korisnik> Get()
        //{

        //    var list = _context.Korisnik.ToList();

        //    return _mapper.Map<List<Models.Korisnik>>(list);
        //}

        [HttpGet]
        public List<Models.Korisnik> Get(KorisniciSearchRequest request)
        {
            //var query = _context.Korisnik.AsQueryable();
            var query = _context.Korisnik.AsQueryable();

            if (!string.IsNullOrEmpty(request.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnikoIme == request.KorisnickoIme);

            }
            if (!string.IsNullOrEmpty(request.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));

            }
            if (!string.IsNullOrEmpty(request.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));

            }
            if (request.UlogaId != 0)
            {
                query = query.Where(x => x.UlogaId == request.UlogaId);
            }
            var list = query.ToList();
            return _mapper.Map<List<Models.Korisnik>>(list);
        }
        public Models.Korisnik Authentifikacija(string korisnickoime, string password)
        {
            var user = _context.Korisnik.Include("Uloga").FirstOrDefault(x => x.KorisnikoIme == korisnickoime);
            if (user != null)
            {
                var noviHash = GenerateHash(user.LozinkaSalt, password);

                if (noviHash == user.LozinkaHash)
                {
                    return _mapper.Map<Models.Korisnik>(user);
                }
            }
            return null;
        }
        [HttpGet]
        public Models.Korisnik GetById(int id)
        {
            var entitet = _context.Korisnik.Find(id);
            return _mapper.Map<Models.Korisnik>(entitet);
        }

        [HttpPost]
        public Models.Korisnik Insert(KorisniciInsertRequest request)
        {
            var entitet = _mapper.Map<Database.Korisnik>(request);
            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Paswordi se ne slazu!");
            }
            entitet.Slika = request.Slika;
            entitet.LozinkaSalt = GenerateSalt();
            entitet.LozinkaHash = GenerateHash(entitet.LozinkaSalt, request.Password);


            _context.Korisnik.Add(entitet);
            _context.SaveChanges();
            return _mapper.Map<Models.Korisnik>(entitet);
        }

        [HttpPut("{id}")]
        public Models.Korisnik Update(int id, KorisniciInsertRequest request)
        {
            var entitet = _context.Korisnik.Find(id);
            entitet.Ime = request.Ime;
            entitet.KorisnikoIme = request.KorisnikoIme;
            entitet.Prezime = request.Prezime;
            entitet.UlogaId = request.UlogaId;
            entitet.Email = request.Email;
            entitet.Slika = request.Slika;
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new Exception("Passwordi se ne slazu!");
                }
                else
                {


                    entitet.LozinkaSalt = GenerateSalt();
                    entitet.LozinkaHash = GenerateHash(entitet.LozinkaSalt, request.Password);
                }


            }

            _context.Korisnik.Attach(entitet);
            _context.Korisnik.Update(entitet);
            _mapper.Map(entitet, request);
            _context.SaveChanges();
            return _mapper.Map<Models.Korisnik>(entitet);

        }

        public static string GenerateSalt()
        {
            var buff = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);

        }

        public bool Delete(int id)
        {
            var entitet = _context.Korisnik.Find(id);

            if (entitet != null)
            {
                _context.Korisnik.Remove(entitet);
                var listkarte = _context.Karta.Where(x => x.KorisnikId == entitet.Id);
                foreach (var x in listkarte)
                {
                    _context.Karta.Remove(x);
                }
                var listocjena = _context.Ocjena.Where(x => x.KorisnikId == entitet.Id);
                foreach (var x in listocjena)
                {
                    _context.Ocjena.Remove(x);
                }
                var listarezervacija = _context.Rezervacija.Where(x => x.KorisnikId == entitet.Id);
                foreach (var x in listarezervacija)
                {
                    _context.Rezervacija.Remove(x);
                }
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
