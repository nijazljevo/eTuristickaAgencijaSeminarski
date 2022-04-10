/*using eProdaja.Mobile;
using eTuristickaAgencija.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTuristickaAgencija.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcjenePage : ContentPage
    {
        OcjeneViewModel model = new OcjeneViewModel();
        private readonly APIService _ocjeneservice = new APIService("Ocjene");
        public OcjenePage(int destinacijaid)
        {

            InitializeComponent();
            BindingContext = model = new OcjeneViewModel()
            {
                
                DestinacijaID = int.Parse(destinacijaid.ToString())
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await model.LoadOcjeneDestinacije();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(model.DestinacijaID.ToString());
            Navigation.PushAsync(new DodajOcjenePage(id));
        }
    }
}*/