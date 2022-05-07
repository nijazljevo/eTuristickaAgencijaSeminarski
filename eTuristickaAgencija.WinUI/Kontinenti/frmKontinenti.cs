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

namespace eTuristickaAgencija.WinUI.Kontinenti
{
    public partial class frmKontinenti : Form
    {
        private readonly APIService _kontinenti = new APIService("Kontinenti");
        public frmKontinenti()
        {
            InitializeComponent();
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            KontinentSearchRequest search = new KontinentSearchRequest()
            {
                Naziv=txtNaziv.Text

            };

            if (this.ValidateChildren())
            {
                var result = await _kontinenti.Get<List<Models.Kontinent>>(search);
                dgvKontinenti.AutoGenerateColumns = false;
                dgvKontinenti.DataSource = result;
            }
        }

        private void dgvKontinenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKontinenti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKontinenti.SelectedRows[0].Cells[0].Value;
            frmKontinentiDetalji frm = new frmKontinentiDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, "Unesite naziv!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void frmKontinenti_Load(object sender, EventArgs e)
        {

        }
    }
}
