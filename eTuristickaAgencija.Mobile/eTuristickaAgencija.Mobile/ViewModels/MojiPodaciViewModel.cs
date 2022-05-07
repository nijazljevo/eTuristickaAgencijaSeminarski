using eProdaja.Mobile;
using eTuristickaAgencija.Mobile.Models;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class MojiPodaciViewModel
    {
        private readonly APIService _karteservice = new APIService("Karte");
        private readonly APIService _hoteliservice = new APIService("Hoteli");
        private readonly APIService _destinacijeservice = new APIService("Destinacije");
        private readonly APIService _terminiservice = new APIService("Termini");

        private readonly APIService _korisniciservice = new APIService("Korisnici");

        public MojiPodaciViewModel()
        {

        }
        public ObservableCollection<MojeKarte> KarteList { get; set; } = new ObservableCollection<MojeKarte>();
       
        public async Task LoadKarte()
        {
            KorisniciSearchRequest request = new KorisniciSearchRequest()
            {
                KorisnickoIme = APIService.Username
            };
            var korisnik = await _korisniciservice.Get<List<Korisnik>>(request);

            int idkorisnik = korisnik.FirstOrDefault().Id;

            KartaSearchRequest search = new KartaSearchRequest()
            {
                KorisnikID=idkorisnik

            };
            var karte =await  _karteservice.Get<IEnumerable<Karta>>(search);

            KarteList.Clear();

            foreach(var x in karte)
            {
                var termin = await _terminiservice.GetById<Termin>(x.TerminId);
                if (x.Ponistena == false && termin.AktivanTermin==true)
                {


                   
                    var hotel = await _hoteliservice.GetById<Hotel>(termin.HotelId);
                    var destinacija = await _destinacijeservice.GetById<Destinacija>(termin.DestinacijaId);
                    MojeKarte k = new MojeKarte()
                    {
                        KartaId = x.Id,
                        DatumPolaska = termin.DatumPolaska,
                        DatumDolaska = termin.DatumDolaska,
                        BrojZvjezdica = hotel.BrojZvjezdica,
                        NazivHotela = hotel.Naziv,
                        NazivPutovanja = destinacija.Naziv,
                        Cijena = termin.Cijena

                    };
                   
                   
                        KarteList.Add(k);
                    
                    
                }

            }


        }

       
    }
}
