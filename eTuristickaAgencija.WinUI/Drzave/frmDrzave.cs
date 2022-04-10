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

namespace eTuristickaAgencija.WinUI.Drzave
{
    public partial class frmDrzave : Form
    {
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _kontinenti = new APIService("Kontinenti");

        public frmDrzave()
        {
            InitializeComponent();
        }

        private async Task LoadKontinenti()
        {
            var result = await _kontinenti.Get<List<Models.Kontinent>>(null);
            result.Insert(0, new Models.Kontinent() { Naziv="---" });
            cmbKontinent.DisplayMember = "Naziv";
            cmbKontinent.ValueMember = "Id";
            cmbKontinent.DataSource = result;
        }

        private async void frmDrzave_Load(object sender, EventArgs e)
        {
            await LoadKontinenti();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            DrzavaSearchRequest search = new DrzavaSearchRequest()
            {
                Naziv=txtNaziv.Text,
                KontinentId=int.Parse(cmbKontinent.SelectedValue.ToString())
            };

            if (this.ValidateChildren())
            {
                var result = await _drzave.Get<List<Models.Drzava>>(search);
                dgvDrzave.AutoGenerateColumns = false;
                dgvDrzave.DataSource = result;
            }
        }

        private void dgvDrzave_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvDrzave.SelectedRows[0].Cells[0].Value;
            frmDrzaveDetalji frm = new frmDrzaveDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void cmbKontinent_Validating(object sender, CancelEventArgs e)
        {
            if(cmbKontinent.SelectedIndex==0 || int.Parse(cmbKontinent.SelectedValue.ToString())==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbKontinent, "Odaberite kontinent!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbKontinent, null);
            }
        }
    }
}
