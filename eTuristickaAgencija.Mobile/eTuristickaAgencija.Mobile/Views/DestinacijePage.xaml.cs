using eTuristickaAgencija.Mobile.ViewModels;
using eTuristickaAgencija.Models;
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
    public partial class DestinacijePage : ContentPage
    {
        private DestinacijeViewModel model = null;
        public DestinacijePage()
        {
            InitializeComponent();
            BindingContext = model = new DestinacijeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var l = e.SelectedItem as Destinacija;
                int id = Convert.ToInt32(l.Id.ToString());
                Navigation.PushAsync(new TerminiPage(id));

            }

        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await model.LoadGradoviDestinacije();
        }
    }
}