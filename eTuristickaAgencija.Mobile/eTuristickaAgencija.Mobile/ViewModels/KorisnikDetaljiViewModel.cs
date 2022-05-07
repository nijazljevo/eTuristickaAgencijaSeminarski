using eProdaja.Mobile;
using eTuristickaAgencija.Mobile.Models;
using eTuristickaAgencija.Mobile.Views;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class KorisnikDetaljiViewModel:BaseViewModel
    {

        private readonly APIService _korisniciservice = new APIService("Korisnici");

        public KorisnikDetaljiViewModel()
        {

        }

        public ObservableCollection<KorisnikDetaljiModels> KorisnikDetalji { get; set; } = new ObservableCollection<KorisnikDetaljiModels>();

        public string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }

        public string _lozinkapotvrda = string.Empty;
        public string LozinkaPotvrda
        {
            get { return _lozinkapotvrda; }
            set { SetProperty(ref _lozinkapotvrda, value); }
        }

        public KorisniciInsertRequest request { get; set; } = new KorisniciInsertRequest();
        public async Task LoadDetalji()
        {
            KorisnikDetalji.Clear();

            KorisniciSearchRequest search = new KorisniciSearchRequest()
            {
                KorisnickoIme = APIService.Username
            };

            var listkorisnik = await _korisniciservice.Get<List<Korisnik>>(search);
            var korisnik = listkorisnik.FirstOrDefault();

            KorisnikDetaljiModels detalji = new KorisnikDetaljiModels()
            {
                Id=korisnik.Id,
                Email=korisnik.Email,
                Ime=korisnik.Ime,
                Prezime=korisnik.Prezime,
                KorisnikoIme=korisnik.KorisnikoIme,
                Slika=korisnik.Slika

            };
            KorisnikDetalji.Add(detalji);

            request.Id = detalji.Id;
            request.Ime = korisnik.Ime;
            request.Prezime = korisnik.Prezime;
            request.Email = korisnik.Email;
            request.KorisnikoIme = korisnik.KorisnikoIme;
            request.Slika = korisnik.Slika;
            request.UlogaId = int.Parse(korisnik.UlogaId.ToString());

        }

        public async Task UpdateLozinka()
        {
            request.Password = this.Lozinka;
            request.PasswordPotvrda = this.LozinkaPotvrda;

            if(request.Password==request.PasswordPotvrda && !string.IsNullOrEmpty(request.Password) && !string.IsNullOrEmpty(request.PasswordPotvrda))
            {

                await _korisniciservice.Update<KorisniciInsertRequest>(request.Id, request);
                
            }
        }

        
    }
}
