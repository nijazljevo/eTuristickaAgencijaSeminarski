/*using eProdaja.Mobile;
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
    public class PreporukaViewModel
    {
        private readonly APIService _korisniciservice = new APIService("Korisnici");
        private readonly APIService _preporukeservice = new APIService("Preporuke");

        public PreporukaViewModel()
        {

        }

        public ObservableCollection<Destinacija> PreporuceneDestinacijeList { get; set; } = new ObservableCollection<Destinacija>();
        public async Task LoadPreporuka()
        {
            KorisniciSearchRequest req = new KorisniciSearchRequest()
            {
                KorisnickoIme=APIService.Username

            };
            var korisnici = await _korisniciservice.Get<IEnumerable<Korisnik>>(req);
            int id = korisnici.FirstOrDefault().Id;

           var dest= await _preporukeservice.GetById<List<Destinacija>>(id);
            PreporuceneDestinacijeList.Clear();
            foreach(var x in dest)
            {
                PreporuceneDestinacijeList.Add(x);
            }



       }
    }
}
*/