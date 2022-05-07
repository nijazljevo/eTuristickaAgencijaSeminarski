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
using System.Windows.Input;
//using Windows.UI.Xaml;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class DodajOcjeneViewModel:BaseViewModel
    {
        private readonly APIService _ocjeneservice = new APIService("Ocjene");
        private readonly APIService _korisniciservice = new APIService("Korisnici");
        public int? DestinacijaID = null;
        public DodajOcjeneViewModel()
        {
            //DKomentar = new Command(async () => await DodajKomentar());
            
        }
        string _obavijest = string.Empty;
        public string Obavijest
        {
            get { return _obavijest; }
            set { SetProperty(ref _obavijest, value); }
        }


        string _komentar = string.Empty;
        public string Komentar
        {
            get { return _komentar; }
            set { SetProperty(ref _komentar, value); }
        }

        int _ocjena = 0;
        public int Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }

        public ObservableCollection<int> Ocjene { get; set; } = new ObservableCollection<int>();
        public void LoadOcjene()
        {
           Ocjene.Clear();
            for(int i=1;i<=5;i++)
            {
               
                Ocjene.Add(i);
            }

            

        }

        public ICommand DKomentar { get; set; }
        public async Task DodajKomentar()
        {
            
            KorisniciSearchRequest ksr = new KorisniciSearchRequest()
            {
                KorisnickoIme = APIService.Username
            };
            var k = await _korisniciservice.Get<List<Korisnik>>(ksr);

            OcjenaInsertRequest ocj = new OcjenaInsertRequest()
            {
                KorisnikId=k.FirstOrDefault().Id,
                DestinacijaId=DestinacijaID,
                Komentar=Komentar,
                OcjenaUsluge=int.Parse(Ocjena.ToString())
            };

            Obavijest = "*Komentar ne smije biti prazan, a ocjena mora biti izmedju 1 i 5*";
            if (ocj.Komentar != null && !string.IsNullOrEmpty(ocj.Komentar) && ocj.OcjenaUsluge >= 1 && ocj.OcjenaUsluge <= 5)
            {
                await _ocjeneservice.Insert<Ocjena>(ocj);
                Obavijest = string.Empty;
            }
            else
            {
                
                //await App.Current.MainPage.DisplayAlert("Greska", "Unesite komentar i ocjenu izmedju 1 i 5!", "OK");


            }
            
        }


    }
}
