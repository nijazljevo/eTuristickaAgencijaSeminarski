using AutoMapper;
using eTuristickaAgencija.Service.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.Service
{
    public class PreporukeService : IPreporukaService
    {
        private readonly TuristickaAgencijaContext _context;
        private readonly IMapper _mapper;

        private int PreporucenBroj = 2;

        public PreporukeService(TuristickaAgencijaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Models.Destinacija> GetPreporuka(int id)
        {
            //ideja je bila da se kreira cbf filter koji ce korisniku preporucivati najcesce rezervisane destinacije u odnosu na historiju pretrazivanja
            //posto svaka destinacija ima vise termina korisnik ce dobiti na pregled destinacije koje zadoolje kriteri
            //a klikom na destinaciju otvoriti ce mu se prozor koji prikazuje aktivne termine



            List<Models.Destinacija> listapreporucenihdestinacija = new List<Models.Destinacija>();
            List<Models.Destinacija> rezultat = new List<Models.Destinacija>();
            Database.Korisnik korisnik = _context.Korisniks.Find(id);
            if (korisnik != null)
            {
                var korisnikoveKarte = _context.Karta.Where(l => l.KorisnikId == korisnik.Id).ToList();

                Dictionary<int, int> Angazman = new Dictionary<int, int>();

                //var listaOdredista = new List<int>();
                //var listaTermina = new List<int>();
                //var listaVremenaPolaska = new List<DateTime>();
                //var listaKorisnikovihDestinacija = new List<int>();

                var sveDestinacije = _context.Destinacijas.ToList();

                //dictionary sadrz parove ida destinacije i broja rezervacija iste
                Dictionary<int, int> destinacijaibrojac = new Dictionary<int, int>();
                foreach (var i in sveDestinacije)
                {
                    var brojac1 = 0;
                    foreach (var item in korisnikoveKarte)
                    {
                        var termin = _context.Termins.Include(x => x.Destinacija).Where(l => l.Id == item.TerminId).FirstOrDefault();

                        var terminmodel = _mapper.Map<Models.Termin>(termin);

                        var destinacija = _context.Destinacijas.Where(x => x.Id == termin.Destinacija.Id).FirstOrDefault();
                        //listaKorisnikovihDestinacija.Add(destinacija.Id);
                        if (i.Id == destinacija.Id)
                            brojac1++;

                        //listaOdredista.Add(int.Parse(destinacija.GradId.ToString()));
                        //listaVremenaPolaska.Add(karta.DatumPolaska);


                    }
                    //za svaku kartu se pronasao termin a za taj termin birana destinacija
                    //ako u dictionariju ne postoji id destinacije ona se dodaje zajedno sa brojacem kao par
                    if (!destinacijaibrojac.ContainsKey(i.Id))
                    {
                        destinacijaibrojac.Add(i.Id, brojac1);

                    }



                }


                foreach (var k in destinacijaibrojac.ToList())
                {
                    //ako je rezervisana vise od dva puta , destinacija se salje u listu preporucenih destinacija
                    //koje su personalizirane sa svakog korisnika
                    if (k.Value >= PreporucenBroj)
                    {

                        var destinacija = _context.Destinacijas.Where(x => x.Id == k.Key).FirstOrDefault();
                        var d = _mapper.Map<Models.Destinacija>(destinacija);
                        rezultat.Add(d);

                    }
                }


                return rezultat;






            }

            return rezultat;
        }
    }
}
