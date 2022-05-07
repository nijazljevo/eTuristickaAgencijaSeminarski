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
    public partial class RegistracijaPage : ContentPage
    {
        RegistracijaViewModel model = new RegistracijaViewModel();
        public RegistracijaPage()
        {
            InitializeComponent();
            BindingContext = model = new RegistracijaViewModel()
            {

            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.Registracija();
            await Navigation.PushAsync(new LoginPage());

        }
    }
}