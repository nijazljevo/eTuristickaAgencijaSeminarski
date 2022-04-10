/*using eProdaja.Mobile;
using eTuristickaAgencija.Mobile.Models;
using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Windows.Services.Maps;
using Xamarin.Forms;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class ProbniViewModel:BaseViewModel
    {

        private readonly APIService _destinacije = new APIService("Destinacije");
        private readonly APIService _gradovi = new APIService("Gradovi");
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _termini = new APIService("Termini");
        private readonly APIService _karte = new APIService("Karte");
        public ProbniViewModel()
        {
            //Initial = new Command(async () => await InitialLoad());

        }


        
        public ICommand Initial { get; set; }
        Grad _selectedGrad = null;
        public Grad SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
                //if (value != null)
                //{
                //    LoadGradoviDrzave();
                //}

            }

        }
        Drzava _selectedDrzava = null;
        public Drzava SelectedDrzava
        {
            get { return _selectedDrzava; }
            set
            {
                SetProperty(ref _selectedDrzava, value);
                //if (value != null)
                //{
                //    Initial.Execute(null);
                //}

            }

        }
        Destinacija _selectedDestinacija = null;
        public Destinacija SelectedDestinacija
        {
            get { return _selectedDestinacija; }
            set
            {
                SetProperty(ref _selectedDestinacija, value);


            }

        }

        public ObservableCollection<Drzava> ListaDrzava { get; set; } = new ObservableCollection<Drzava>();
        public ObservableCollection<Grad> GradoviList { get; set; } = new ObservableCollection<Grad>();
        //public ObservableCollection<Destinacija> ListaDestinacija { get; set; } = new ObservableCollection<Destinacija>();

        public ObservableCollection<ProbniModels> ListaDestinacija { get; set; } = new ObservableCollection<ProbniModels>();

        public async Task InitialLoad()
        {
            if (ListaDrzava.Count == 0)
            {
                DrzavaSearchRequest request = new DrzavaSearchRequest()
                {
                    Naziv = null,
                    KontinentId = 0
                };
                var lista = await _drzave.Get<IEnumerable<Drzava>>(request);
                ListaDrzava.Clear();
                foreach (var x in lista)
                {
                    ListaDrzava.Add(x);
                }
            }
            if(GradoviList.Count==0)
            {
                GradoviSearchRequest gradsearch = new GradoviSearchRequest()
                {
                    Naziv = null,
                    DrzavaId=0
                };

                var lista = await _gradovi.Get<IEnumerable<Grad>>(gradsearch);
                GradoviList.Clear();
                foreach (var x in lista)
                {
                    GradoviList.Add(x);
                }
            }

        }
        public async Task LoadGradoviDrzave()
        {
           

            if(SelectedDrzava!=null)
            {
                GradoviSearchRequest gradsearch = new GradoviSearchRequest()
                {
                    Naziv=null,
                    DrzavaId=SelectedDrzava.Id
                };

                var lista = await _gradovi.Get<IEnumerable<Grad>>(gradsearch);
                GradoviList.Clear();
                foreach(var x in lista)
                {
                    GradoviList.Add(x);
                }
            }

            //if(SelectedGrad!=null)
            //{
            //    DestinacijaSearchRequest destinacijasearch = new DestinacijaSearchRequest()
            //    {
            //        Naziv=SelectedGrad.Naziv,
            //        GradId=SelectedGrad.Id

            //    };
            //    var lista = await _destinacije.Get<IEnumerable<Destinacija>>(destinacijasearch);
            //    ListaDestinacija.Clear();

            //    foreach(var x in lista)
            //    {
            //        ListaDestinacija.Add(x);
            //    }
            //}


        }

        public async Task LoadDestinacije()
        {
            if (SelectedGrad != null)
            {
                DestinacijaSearchRequest destinacijasearch = new DestinacijaSearchRequest()
                {
                    Naziv = SelectedGrad.Naziv,
                    GradId = SelectedGrad.Id

                };
                var lista = await _destinacije.Get<IEnumerable<Destinacija>>(destinacijasearch);
                ListaDestinacija.Clear();

                foreach (var x in lista)
                {
                    ProbniModels pm = new ProbniModels()
                    {
                        Id=x.Id,
                        GradId=x.GradId,
                        Naziv=x.Naziv,
                        Slika=x.Slika,
                        CijenaProdatihKarataDestinacije=0
                    };

                    TerminSearchRequest searchTermini = new TerminSearchRequest()
                    {
                        DestinacijaId=x.Id,
                        Aktivan=true
                        //Aktivan=true
                    };
                    var listterminidestinacije = await _termini.Get<IEnumerable<Termin>>(searchTermini);

                    foreach(var termin in listterminidestinacije)
                    {
                        KartaSearchRequest kartasearch = new KartaSearchRequest()
                        {
                            TerminID=termin.Id,
                            Ponistena=false
                        };
                        var listakarata = await _karte.Get<List<Karta>>(kartasearch);

                        var brojkarata = int.Parse(listakarata.Count.ToString());
                        var termincijena = Decimal.ToInt32(termin.Cijena);
                        var umnozak = int.Parse(brojkarata.ToString()) * int.Parse(termincijena.ToString());
                        pm.CijenaProdatihKarataDestinacije += umnozak;
                        listakarata.Clear();

                    }

                    ListaDestinacija.Add(pm);
                }
            }
        }

    }
}
*/