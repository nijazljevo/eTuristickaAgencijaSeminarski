/*using eProdaja.Mobile;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class TerminiViewModel:BaseViewModel
    {

        private readonly APIService _terminiservice = new APIService("Termini");
        private readonly APIService _destinacijeservice = new APIService("Destinacije");
        private readonly APIService _korisniciservice = new APIService("Korisnici");
        private readonly APIService _karteservice = new APIService("Karte");


        public int? DestinacijaID = null;

        
        public TerminiViewModel()
        {
        }

        public ObservableCollection<Termin> TerminiList { get; set; } = new ObservableCollection<Termin>();

        public ObservableCollection<Destinacija> OdabranaDestinacija { get; set; } = new ObservableCollection<Destinacija>();
        public ICommand LoadTermini { get; set; }

        public async Task Load()
        {

            //var termini = await _terminiservice.Get<IEnumerable<Termin>>(null);
            OdabranaDestinacija.Clear();

            if (DestinacijaID != null)
            {
                Destinacija d = new Destinacija();
                d = await _destinacijeservice.GetById<Destinacija>(DestinacijaID);
                OdabranaDestinacija.Add(d);

                var search = new TerminSearchRequest()
                {
                    Aktivan=true

                };
                search.DestinacijaId = int.Parse(DestinacijaID.ToString());

                var list = await _terminiservice.Get<IEnumerable<Termin>>(search);
                TerminiList.Clear();

                foreach (var x in list)
                {
                    TerminiList.Add(x);
                }
            }

        }

        

    }
}
*/