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

namespace eTuristickaAgencija.WinUI.Agencija
{
    public partial class frmAgencijaDetalji : Form
    {
        private readonly APIService _agencija = new APIService("Agencija");
        private Models.Agencija _agencijaModel;
        public frmAgencijaDetalji(Models.Agencija agencija = null)
        {
            InitializeComponent();
            _agencijaModel = agencija;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            AgencijaInsertRequest agencija = new AgencijaInsertRequest()
            {
                Adresa = txtAdresa.Text,
                Email = txtEmail.Text,
                Telefon = txtTelefon.Text
            };
            if (this.ValidateChildren())
            {


                if (_agencijaModel != null)
                {
                    await _agencija.Update<AgencijaInsertRequest>(_agencijaModel.Id, agencija);
                    MessageBox.Show("Uspjesno izmjenjeno!");
                    this.Close();

                }
            }
        }

        private async void frmAgencijaDetalji_Load(object sender, EventArgs e)
        {
            if (_agencijaModel!=null)
            {
                var agencija = await _agencija.GetById<Models.Agencija>(_agencijaModel.Id);
                txtAdresa.Text = agencija.Adresa;
                txtEmail.Text = agencija.Email;
                txtTelefon.Text = agencija.Telefon;
            }
        }
    }
}
