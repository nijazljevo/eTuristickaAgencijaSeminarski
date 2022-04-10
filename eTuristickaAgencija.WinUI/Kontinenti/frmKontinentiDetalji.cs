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
    public partial class frmKontinentiDetalji : Form
    {
        private readonly APIService _kontinenti = new APIService("Kontinenti");
        private int? _id = null;
        public frmKontinentiDetalji(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }
        KontinentInsertRequest kontinent = new KontinentInsertRequest();
        private async  void btnSacuvaj_Click(object sender, EventArgs e)
        {
            kontinent.Naziv = txtNaziv.Text;
            if (this.ValidateChildren())
            {


                if (_id.HasValue)
                {
                    await _kontinenti.Update<KontinentInsertRequest>(_id, kontinent);
                    MessageBox.Show("Operacija uspjesna");
                    this.Close();
                }
                else
                {
                    //if (!string.IsNullOrWhiteSpace(kontinent.Naziv))
                    //{
                        await _kontinenti.Insert<KontinentInsertRequest>(kontinent);
                        MessageBox.Show("Dodavanje uspjesno");
                        this.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Unesite sva polja!");
                    //}
                }
            }

        }

        private async void frmKontinentiDetalji_Load(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                var kontinent = await _kontinenti.GetById<Models.Kontinent>(_id);
                txtNaziv.Text = kontinent.Naziv;
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, "Unesite naziv");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                await _kontinenti.Delete<bool>(_id);
                MessageBox.Show("Uspjesno obrisano");
                this.Close();
            }
        }
    }
}
