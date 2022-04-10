/*using eTuristickaAgencija.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Flurl;
using Flurl.Http;
using eProdaja.Mobile;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using System.Linq;
//using Windows.UI.Popups;
using System.Diagnostics;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");//ili destinacije
        private readonly APIService _rsII = new APIService("RSII25092020");

        public LoginViewModel()
        {
            LoginCommand = new Command(async()=> await Login());
            ShowAlertCommand = new Command(get => MakeAlter());
        }
        public ICommand ShowAlertCommand { get; set; }
        
        void MakeAlter()
        {
            Application.Current.MainPage.DisplayAlert("Alert", "Hello", "Cancel", "ok");
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        public async Task Login()
        {
            IsBusy = true;
            APIService.Username = _username;
            APIService.Password = _password;
            KorisniciSearchRequest request = new KorisniciSearchRequest()
            {
                KorisnickoIme = _username

            };
            var korisnici = await _service.Get<List<Korisnik>>(request);
            var korisnik = korisnici.FirstOrDefault();
           
            try
            {

                //await _service.Get<dynamic>(null);
                //Application.Current.MainPage = new MainPage();
                if (korisnik != null && korisnik.UlogaId == 1)
                {
                    


                    
                    Application.Current.MainPage = new MainPage();


                }
                else
                {
                   
                    await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure?", "Yes", "No");
                    //await Application.Current.MainPage.DisplayAlert("Greska", "Netacni podaci!", "OK");
                    


                }


            }
            catch (Exception ex)
            {
                
                await Application.Current.MainPage.DisplayAlert("Greska", ex.Message, "OK","OK");
                

            }
        }
    }

}
*/