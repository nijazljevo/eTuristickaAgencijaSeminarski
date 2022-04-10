using eTuristickaAgencija.Mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTuristickaAgencija.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

           

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Pocetna, Title="Pocetna" },
                new HomeMenuItem {Id = MenuItemType.Preporuka, Title="Preporucujemo" },
                new HomeMenuItem {Id = MenuItemType.Destinacije, Title="Destinacije" },
                new HomeMenuItem {Id = MenuItemType.MojiPodaci, Title="Moji podaci" },
                new HomeMenuItem {Id = MenuItemType.MojProfil, Title="Moj profil" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}