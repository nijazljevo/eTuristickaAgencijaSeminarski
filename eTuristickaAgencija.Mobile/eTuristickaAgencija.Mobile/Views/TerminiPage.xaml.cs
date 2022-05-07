using eProdaja.Mobile;
using eTuristickaAgencija.Mobile.ViewModels;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Windows.UI.Popups;
//using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Button = Xamarin.Forms.Button;
using Grid = Xamarin.Forms.Grid;

namespace eTuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TerminiPage : ContentPage
    {
        TerminiViewModel model = new TerminiViewModel();
        private readonly APIService _karte = new APIService("Karte");
        private readonly APIService _korisniciservice = new APIService("Korisnici");
        private readonly APIService _terminiservice = new APIService("Termini");


        public TerminiPage(int destinacijaid)
        {
            InitializeComponent();
            BindingContext = model = new TerminiViewModel()
            {
                DestinacijaID = int.Parse(destinacijaid.ToString())
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load();
        }
        KartaInsertRequest karta = null;
        Termin TerminzaPage = null;
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var termin = e.SelectedItem as Termin;
                KorisniciSearchRequest ksr = new KorisniciSearchRequest()
                {
                    KorisnickoIme = APIService.Username
                };
                var k = await _korisniciservice.Get<List<Korisnik>>(ksr);


                karta = new KartaInsertRequest();
                karta.KorisnikId = k.FirstOrDefault().Id;
                karta.Ponistena = false;
                karta.DatumKreiranja = System.DateTime.Now;
                karta.TerminId = termin.Id;

                TerminzaPage = termin;



                


            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //bool postoji = true;
            //KartaSearchRequest kartasearch = null;

            //if (karta != null)
            //{


            //    kartasearch = new KartaSearchRequest();

            //    kartasearch.KorisnikID = int.Parse(karta.KorisnikId.ToString());
            //    kartasearch.TerminID = int.Parse(karta.TerminId.ToString());
            //    kartasearch.Ponistena = false;

               
            //}

            //var provjera = await _karte.Get<List<Karta>>(kartasearch);
            //if(provjera.Count==0)
            //{
            //    postoji = false;
            //}


            //if (karta != null && postoji == false)
            //{
            //    await _karte.Insert<KartaInsertRequest>(karta);
                
            //}
           

           

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(model.DestinacijaID.ToString());
            Navigation.PushAsync(new OcjenePage(id));

        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {


            bool postoji = true;
            KartaSearchRequest kartasearch = null;


            if (karta != null)
            {


                kartasearch = new KartaSearchRequest();

                kartasearch.KorisnikID = int.Parse(karta.KorisnikId.ToString());
                kartasearch.TerminID = int.Parse(karta.TerminId.ToString());
                kartasearch.Ponistena = false;


            }

            var provjera = await _karte.Get<List<Karta>>(kartasearch);
            if (provjera.Count == 0)
            {
                postoji = false;
            }


            if (karta != null && postoji == false)
            {
                await _karte.Insert<KartaInsertRequest>(karta);

            }

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            if(TerminzaPage!=null)
            {
                var id = Convert.ToInt32(TerminzaPage.Id.ToString());
                Navigation.PushAsync(new TerminDetaljiPage(id));
            }
        }
    }
}