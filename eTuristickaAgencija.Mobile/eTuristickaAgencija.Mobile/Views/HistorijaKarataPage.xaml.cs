using eProdaja.Mobile;
using eTuristickaAgencija.Mobile.Models;
using eTuristickaAgencija.Mobile.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorijaKarataPage : ContentPage
    {
        //private readonly APIService _karteservice = new APIService("Karte");
        //private readonly APIService _terminiservice = new APIService("Termini");
        HistorijaKarataViewModel model = new HistorijaKarataViewModel();
        public HistorijaKarataPage()
        {
            InitializeComponent();
            BindingContext = model = new HistorijaKarataViewModel()
            {
                
                HistorijaKarteList=new ObservableCollection<MojeKarte>()
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadHistorijaKarte();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.Pretraga();
        }
    }
}