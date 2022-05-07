using eProdaja.Mobile;
using eTuristickaAgencija.Mobile.Models;
using eTuristickaAgencija.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTuristickaAgencija.Mobile.ViewModels
{
    public class TerminDetaljiViewModel:BaseViewModel
    {
        public int? terminid = null;
        private readonly APIService _destinacijeservice = new APIService("Destinacije");
        private readonly APIService _terminiservice = new APIService("Termini");
        private readonly APIService _hoteliservice = new APIService("Hoteli");
        private readonly APIService _gradoviservice = new APIService("Gradovi");
        public TerminDetaljiViewModel()
        {
            
        }

        public ObservableCollection<TerminDetaljiModels> OdabraniTermin { get; set; } = new ObservableCollection<TerminDetaljiModels>();
        public ObservableCollection<Hotel> OdabraniHotel { get; set; } = new ObservableCollection<Hotel>();

        public async Task LoadTerminDetalji()
        {
            OdabraniTermin.Clear();
            OdabraniHotel.Clear();
            if (terminid != null)
            {
                var termin = await _terminiservice.GetById<Termin>(terminid);
                var hotel = await _hoteliservice.GetById<Hotel>(termin.HotelId);
                var grad = await _gradoviservice.GetById<Grad>(termin.GradId);
                OdabraniHotel.Add(hotel);
                TerminDetaljiModels terminodabrani = new TerminDetaljiModels()
                {
                    Id = termin.Id,
                    Cijena = termin.Cijena,
                    DatumDolaska = termin.DatumDolaska,
                    DatumPolaska = termin.DatumPolaska,
                    DestinacijaId = termin.DestinacijaId,
                    Popust = termin.Popust,
                    GradNaziv = grad.Naziv,
                    BrojZvjezdica = hotel.BrojZvjezdica,
                    HotelNaziv = hotel.Naziv
                };
                terminodabrani.HotelSlika = new byte[hotel.Slika.Length + 1];
                hotel.Slika.CopyTo(terminodabrani.HotelSlika, 0);
                
                OdabraniTermin.Add(terminodabrani);
            }
        }


    }
}
