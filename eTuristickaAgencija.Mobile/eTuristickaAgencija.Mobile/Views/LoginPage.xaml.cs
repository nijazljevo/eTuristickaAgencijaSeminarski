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
    public partial class LoginPage : ContentPage
    {
        LoginViewModel model = new LoginViewModel();
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = model = new LoginViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistracijaPage());

        }

        protected async  override void OnAppearing()
        {
            
            base.OnAppearing();
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await model.Login();


            
        }
    }
}