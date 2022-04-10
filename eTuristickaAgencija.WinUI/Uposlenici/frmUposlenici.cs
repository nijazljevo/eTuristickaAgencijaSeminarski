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

namespace eTuristickaAgencija.WinUI.Uposlenici
{
    public partial class frmUposlenici : Form
    {
        private readonly APIService _uposlenici = new APIService("Uposlenik");
        private readonly APIService _korisnici = new APIService("Korisnici");
      
        public frmUposlenici()
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
        private async void frmUposlenici_Load(object sender, EventArgs e)
        {
            await LoadKorisnici();
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            UposlenikSearchRequest search = new UposlenikSearchRequest
            {
                DatumZaposlenja = dtpDatumZaposlenja.Value,
                Aktivan = chcbAktivan.Checked,
                KorisnikId = int.Parse(cmbKorisnik.SelectedValue.ToString())
            };
            var result = await _uposlenici.Get<List<Models.Uposlenik>>(search);
            dgvUposlenici.AutoGenerateColumns = false;
            dgvUposlenici.DataSource = result;
        }

        private  void btnNoviUposlenici_Click(object sender, EventArgs e)
        {
            frmUposlenici frm = new frmUposlenici();
            frm.Show();
        }
        
        private void dgvUposlenici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = dgvUposlenici.SelectedRows[0].DataBoundItem;
            frmUposleniciDetalji frm = new frmUposleniciDetalji(item as Models.Uposlenik);
            frm.Show();
        }
    }
}
