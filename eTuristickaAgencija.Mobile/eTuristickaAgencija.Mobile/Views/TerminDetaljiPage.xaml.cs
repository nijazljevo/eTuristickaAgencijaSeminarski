using eTuristickaAgencija.Mobile.Models;
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
    public partial class TerminDetaljiPage : ContentPage
    {
        TerminDetaljiViewModel model = new TerminDetaljiViewModel();
        public TerminDetaljiPage(int terminid)
        {
            InitializeComponent();
            BindingContext = model = new TerminDetaljiViewModel()
            {
                terminid=int.Parse(terminid.ToString())
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadTerminDetalji();
        }



    }
}