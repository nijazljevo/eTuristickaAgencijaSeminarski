/*using eTuristickaAgencija.Mobile.ViewModels;
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
    public partial class ProbniPage : ContentPage
    {
        ProbniViewModel model = new ProbniViewModel();
        public ProbniPage()
        {
            InitializeComponent();
            BindingContext = model = new ProbniViewModel()
            {

            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitialLoad();
        }
       

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await model.LoadDestinacije();
        }

        private async  void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await model.LoadGradoviDrzave();
        }
    }
}*/