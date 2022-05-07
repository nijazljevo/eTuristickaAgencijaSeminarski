using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using eTuristickaAgencija.Mobile.Models;

namespace eTuristickaAgencija.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
           
            
            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ToolbarItems.Clear();
        }
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Pocetna:
                        MenuPages.Add(id, new NavigationPage(new MainPage()));
                        break;
                    case (int)MenuItemType.Preporuka:
                        MenuPages.Add(id, new NavigationPage(new PreporukaPage()));
                        break;
                    case (int)MenuItemType.Destinacije:
                        MenuPages.Add(id, new NavigationPage(new DestinacijePage()));
                        break;
                    case (int)MenuItemType.MojiPodaci:
                        MenuPages.Add(id, new NavigationPage(new MojiPodaciPage()));
                        break;
                    case (int)MenuItemType.MojProfil:
                        MenuPages.Add(id, new NavigationPage(new KorisnikDetaljiPage()));
                        break;
                    

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

       
    }
}