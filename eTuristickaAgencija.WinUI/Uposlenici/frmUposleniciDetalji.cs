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
    public partial class frmUposleniciDetalji : Form
    {
        private readonly APIService _uposlenici = new APIService("Uposlenik");
        private readonly APIService _korisnici = new APIService("Korisnici");
        private Models.Uposlenik _uposleniciModel;
        public frmUposleniciDetalji(Models.Uposlenik uposlenik = null)
        {
            InitializeComponent();
            _uposleniciModel = uposlenik;
        }

        private async void frmUposleniciDetalji_Load(object sender, EventArgs e)
        {
            await LoadKorisnici();
            if (_uposleniciModel!=null)
            {
                var uposlenici = await _uposlenici.GetById<Models.Uposlenik>(_uposleniciModel.Id);
                chcbAktivan.Checked = uposlenici.Aktivan.Value;
                cmbKorisnik.SelectedValue = uposlenici.KorisnikId;
                dtpDatumZaposlenja.Value = uposlenici.DatumZaposlenja;
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (_uposleniciModel!=null)
            {
                await _uposlenici.Delete<bool>(_uposleniciModel.Id);
                MessageBox.Show("Uspjesno obrisano");
                this.Close();
            }
        }
        private async Task LoadKorisnici()
        {
            var result = await _korisnici.Get<List<Models.Korisnik>>(null);
            result.Insert(0, new Models.Korisnik() { Ime = "---" });
            cmbKorisnik.DisplayMember = "Ime";
            cmbKorisnik.ValueMember = "Id";
            cmbKorisnik.DataSource = result;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                UposlenikInsertRequest uposlenik = new UposlenikInsertRequest();
                uposlenik.KorisnikId = int.Parse(cmbKorisnik.SelectedValue.ToString());
                uposlenik.DatumZaposlenja = dtpDatumZaposlenja.Value;
                uposlenik.Aktivan = chcbAktivan.Checked;
                if (this.ValidateChildren())
                {
                    if (_uposleniciModel != null)
                    {
                        await _uposlenici.Update<UposlenikInsertRequest>(_uposleniciModel.Id, uposlenik);
                        MessageBox.Show("Uspjesna izmjena");
                        this.Close();
                    }
                    else
                    {
                        await _uposlenici.Insert<UposlenikInsertRequest>(uposlenik);
                        MessageBox.Show("Uspjesno dodavanje");
                        this.Close();
                    }
                }
            }
        }
    }
}
