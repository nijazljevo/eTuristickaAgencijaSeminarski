/*using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eTuristickaAgencija.Models;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using eProdaja.Mobile;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using eTuristickaAgencija.Models.Request;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using eTuristickaAgencija.Mobile.Views;
using eTuristickaAgencija.Mobile.Models;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class DestinacijeViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Destinacije");
        private readonly APIService _gradoviservice = new APIService("Gradovi");
        private readonly APIService _drzaveservice = new APIService("Drzave");
        public DestinacijeViewModel()
        {
            Initial = new Command(async()=>await Init());
        }

        Grad _selectedGrad = null;
        public Grad SelectedGrad
        {
            get { return _selectedGrad; }
            set { SetProperty(ref _selectedGrad, value);

                if (value != null)
                {
                    Initial.Execute(null);
                }
            }
            
        }
        Destinacija _selectedDestinacija = null;
        public Destinacija SelectedDestinacija
        {
            get { return _selectedDestinacija; }
            set
            {
                SetProperty(ref _selectedDestinacija, value);

                if (value != null)
                {
                    Initial.Execute(null);
                }
            }

        }

        Drzava _selectedDrzava = null;
        public Drzava SelectedDrzava
        {
            get { return _selectedDrzava; }
            set
            {
                SetProperty(ref _selectedDrzava, value);

                if (value != null)
                {
                    Initial.Execute(null);
                }
            }

        }

        public ObservableCollection<Drzava> DrzaveList { get; set; } = new ObservableCollection<Drzava>();
        public ObservableCollection<Destinacija> DestinacijeList { get; set; } = new ObservableCollection<Destinacija>();
       
        public ObservableCollection<Grad> GradoviList { get; set; } = new ObservableCollection<Grad>();
        public ICommand Initial { get; set; }


       
       

        public async Task Init()
        {
            if (DrzaveList.Count == 0)
            {
                
                DrzavaSearchRequest request = new DrzavaSearchRequest()
                {
                    Naziv = null,
                    KontinentId = 0

                };
                var drzavelist = await _drzaveservice.Get<IEnumerable<Drzava>>(request);

                DrzaveList.Clear();

                foreach (var drzava in drzavelist)
                {
                    DrzaveList.Add(drzava);
                }
               
            }


            if (SelectedDrzava != null)
            {
                //if (GradoviList.Count == 0)
                //{
                

                GradoviSearchRequest request = new GradoviSearchRequest()
                {
                    Naziv = null,
                    DrzavaId = SelectedDrzava.Id

                };
                //var gradovilist = await _gradoviservice.Get<IEnumerable<Grad>>(request);
                var gradovilist = new List<Grad>();



                foreach (var grad in gradovilist)
                {
                    GradoviList.Add(grad);
                }


            
        }

            if (SelectedGrad != null)
            {
                DestinacijaSearchRequest search = new DestinacijaSearchRequest()
                {
                    GradId = SelectedGrad.Id,
                    Naziv = SelectedGrad.Naziv
                };


                var list = await _service.Get<IEnumerable<Destinacija>>(search);

                DestinacijeList.Clear();

                foreach (var destinacija in list)
                {

                    DestinacijeList.Add(destinacija);
                }
            }




        }

        public async Task LoadGradoviDestinacije()
        {
            if(SelectedDrzava!=null)
            {
                GradoviSearchRequest request = new GradoviSearchRequest()
                {
                    Naziv = null,
                    DrzavaId = SelectedDrzava.Id

                };
                var gradovilist = await _gradoviservice.Get<IEnumerable<Grad>>(request);


                GradoviList.Clear();

                foreach (var grad in gradovilist)
                {
                    GradoviList.Add(grad);
                }

            }

            if (SelectedGrad != null)
            {
                DestinacijaSearchRequest search = new DestinacijaSearchRequest()
                {
                    GradId = SelectedGrad.Id,
                    Naziv = SelectedGrad.Naziv
                };


                var list = await _service.Get<IEnumerable<Destinacija>>(search);

                DestinacijeList.Clear();

                foreach (var destinacija in list)
                {
                    DestinacijeList.Add(destinacija);
                }
            }
        }


    }
    
}
*/