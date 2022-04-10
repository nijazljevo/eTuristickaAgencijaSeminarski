using eTuristickaAgencija.Models;
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
    public partial class frmDrzaveDetalji : Form
    {
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _kontinenti = new APIService("Kontinenti");

        private int? _id = null;
        public frmDrzaveDetalji(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                await _drzave.Delete<bool>(_id);
                MessageBox.Show("Uspjesno obrisano");
                this.Close();
            }
        }
        private async Task LoadKontinenti()
        {
            var result = await _kontinenti.Get<List<Models.Kontinent>>(null);
            result.Insert(0, new Models.Kontinent() { Naziv = "---" });
            cmbKontinent.DisplayMember = "Naziv";
            cmbKontinent.ValueMember = "Id";
            cmbKontinent.DataSource = result;
        }


        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            

            if (this.ValidateChildren())
            {
                DrzavaInsertRequest drzava = new DrzavaInsertRequest();
                drzava.KontinentId = int.Parse(cmbKontinent.SelectedValue.ToString());
                drzava.Naziv = txtNaziv.Text;
                if (_id.HasValue)
                {
                    await _drzave.Update<DrzavaInsertRequest>(_id, drzava);
                    MessageBox.Show("Uspjesna izmjena");
                    this.Close();
                }
                else
                {
                    //if (!string.IsNullOrWhiteSpace(drzava.Naziv) && drzava.KontinentId > 0)
                    //{
                        await _drzave.Insert<DrzavaInsertRequest>(drzava);
                        MessageBox.Show("Uspjesno dodavanje");
                        this.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Unesite sva polja");
                    //}
                }
            }

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

        private void cmbKontinent_Validating(object sender, CancelEventArgs e)
        {
            if(int.Parse(cmbKontinent.SelectedValue.ToString())<0 || cmbKontinent.SelectedIndex==-1 || cmbKontinent.SelectedIndex==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbKontinent, "Odaberite vrijednost");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbKontinent, null);
            }

        }

        private async void frmDrzaveDetalji_Load(object sender, EventArgs e)
        {
            await LoadKontinenti();
            if(_id.HasValue)
            {
                var drzava = await _drzave.GetById<Models.Drzava>(_id);
                txtNaziv.Text = drzava.Naziv;

                cmbKontinent.SelectedValue = drzava.KontinentId;

            }
        }
    }
}
