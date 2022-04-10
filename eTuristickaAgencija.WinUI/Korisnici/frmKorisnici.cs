using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTuristickaAgencija.Models.Request;
using Flurl.Http;
namespace eTuristickaAgencija.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _apiService = new APIService("Korisnici");
        private readonly APIService _ulogeservice = new APIService("Uloge");
        public frmKorisnici()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        async Task LoadUloge()
        {
            var uloge = await _ulogeservice.Get<List<Models.Uloga>>(null);
            uloge.Insert(0, new Models.Uloga() {Naziv="---" });
            cmbUloge.DataSource = uloge;
            cmbUloge.ValueMember = "Id";
            cmbUloge.DisplayMember = "Naziv";
            cmbUloge.SelectedIndex = 0;
        }
        private async void btnGo_Click(object sender, EventArgs e)
        {
            
            var search = new KorisniciSearchRequest()
            {
                Ime=txtPretraga.Text,
                KorisnickoIme=txtPretraga.Text,
                UlogaId=int.Parse(cmbUloge.SelectedValue.ToString())

                

            };
            if (this.ValidateChildren())
            {
                var result = await _apiService.Get<List<Models.Korisnik>>(search);
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.DataSource = result;
            }
            
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKorisnici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;

            frmKorisniciDetalji frm = new frmKorisniciDetalji(int.Parse(id.ToString()));
            frm.Show();
            //frmKorisniciUpdate frm = new frmKorisniciUpdate(int.Parse(id.ToString()));
            //frm.Show();

        }

        private void frmKorisnici_DoubleClick(object sender, EventArgs e)
        {

        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            await LoadUloge();
        }

        private void cmbUloge_Validating(object sender, CancelEventArgs e)
        {
            if(cmbUloge.SelectedValue==null || int.Parse(cmbUloge.SelectedValue.ToString())==0 || cmbUloge.SelectedIndex==0 || cmbUloge.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbUloge, "Odaberite ulogu!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbUloge, null);
            }
        }

        private void btnNoviKorisnik_Click(object sender, EventArgs e)
        {
            frmKorisniciDetalji frm = new frmKorisniciDetalji();
            frm.Show();
        }
    }
}
