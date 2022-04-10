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

namespace eTuristickaAgencija.WinUI.Termini
{
    public partial class frmTermini : Form
    {
        private readonly APIService _termini = new APIService("Termini");
        private int? _destinacijaid = null;
        public frmTermini(int? id = null)
        {
            InitializeComponent();
            _destinacijaid = id;
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                var search = new TerminSearchRequest()
                {
                    DestinacijaId = int.Parse(_destinacijaid.ToString()),
                    DatumPolaska = pickerOd.Value,
                    DatumDolaska = pickerDo.Value,
                    Cijena = decimal.Parse(txtCijena.Text.ToString()),
                    Aktivan = chcbAktivan.Checked

                };



                var result = await _termini.Get<List<Models.Termin>>(search);
                dgvTermini.AutoGenerateColumns = false;
                dgvTermini.DataSource = result;
            }
        }

        private void dgvTermini_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvTermini.SelectedRows[0].Cells[0].Value;
            frmTerminiDetalji frm = new frmTerminiDetalji(int.Parse(_destinacijaid.ToString()), int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnNoviTermin_Click(object sender, EventArgs e)
        {
            frmTerminiDetalji frm = new frmTerminiDetalji(int.Parse(_destinacijaid.ToString()), null);
            frm.Show();
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCijena.Text) || int.Parse(txtCijena.Text)<0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCijena, "Unesite vrijednost cijene!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCijena, null);
            }
        }

        private void frmTermini_Load(object sender, EventArgs e)
        {

            txtCijena.Text = "0";
        }

        private void pickerDo_Validating(object sender, CancelEventArgs e)
        {
            if(pickerDo.Value.Date<= pickerOd.Value.Date)
            {
                e.Cancel = true;
                errorProvider1.SetError(pickerDo, "Datum dolaska raniji od datuma polaska!Unesite novi datum!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(pickerDo, null);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
