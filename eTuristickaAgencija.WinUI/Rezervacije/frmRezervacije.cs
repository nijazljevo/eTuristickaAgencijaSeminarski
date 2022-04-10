using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTuristickaAgencija.WinUI.Rezervacije
{
    public partial class frmRezervacije : Form
    {
        private readonly APIService _rezervacije = new APIService("Rezervacija");
        private readonly APIService _korisnici = new APIService("Korisnici");
        private readonly APIService _hoteli = new APIService("Hoteli");
        public frmRezervacije()
        {
            InitializeComponent();
        }
        private async Task LoadKorisnici()
        {
            var result = await _korisnici.Get<List<Models.Korisnik>>(null);
            result.Insert(0, new Models.Korisnik() { Ime = "---" });
            cmbKorisnik.DisplayMember = "Ime";
            cmbKorisnik.ValueMember = "Id";
            cmbKorisnik.DataSource = result;
        }
        private async Task LoadHoteli()
        {
            var result = await _hoteli.Get<List<Models.Hotel>>(null);
            result.Insert(0, new Models.Hotel() { Naziv = "---" });
            cmbHotel.DisplayMember = "Naziv";
            cmbHotel.ValueMember = "Id";
            cmbHotel.DataSource = result;
        }
        private async void frmRezervacije_Load(object sender, EventArgs e)
        {
            await LoadHoteli();
            await LoadKorisnici();
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            RezervacijaSearchRequest search = new RezervacijaSearchRequest()
            {
                Cijena = decimal.Parse(txtCijena.Text.ToString()),
                KorisnikId = int.Parse(cmbKorisnik.SelectedValue.ToString()),
                HotelId = int.Parse(cmbHotel.SelectedValue.ToString()),
                DatumRezervacije=dtpDatumRezervacije.Value,
                Otkazana=chcbOtkazana.Checked
            };

            
                var result = await _rezervacije.Get<List<Models.Rezervacija>>(search);
                dgvRezervacije.AutoGenerateColumns = false;
                dgvRezervacije.DataSource = result;
            
        }

        private void btnNoveRezervacije_Click(object sender, EventArgs e)
        {
            frmRezervacijeDetalji frm = new frmRezervacijeDetalji();
            frm.Show();
        }

        private void txtCijena_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chcbOtkazana_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Od_Click(object sender, EventArgs e)
        {

        }

        private void dtpDatumRezervacije_ValueChanged(object sender, EventArgs e)
        {

        }

        private async  void dgvRezervacije_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = dgvRezervacije.SelectedRows[0].DataBoundItem;
            frmRezervacijeDetalji frm = new frmRezervacijeDetalji(item as Models.Rezervacija);
            frm.Show();
        }
    }
}
