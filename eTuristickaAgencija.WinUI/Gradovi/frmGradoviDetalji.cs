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

namespace eTuristickaAgencija.WinUI.Gradovi
{
    public partial class frmGradoviDetalji : Form
    {
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _kontinenti = new APIService("Kontinenti");
        private readonly APIService _gradovi = new APIService("Gradovi");
        
        private int? _id = null;
        public frmGradoviDetalji(int ? id=null)
        {
            InitializeComponent();
            _id = id;
        }
         async Task LoadKontinenti()
        {
            var result = await _kontinenti.Get<List<Models.Kontinent>>(null);
            result.Insert(0, new Models.Kontinent() { Naziv="---" });
            cmbKontinenti.DisplayMember = "Naziv";
            cmbKontinenti.ValueMember = "Id";
            cmbKontinenti.DataSource = result;
            cmbKontinenti.SelectedValue = 0;
        }

        private int? kontinentid = null;
        async Task LoadDrzave(int? id)
        {
            DrzavaSearchRequest request = new DrzavaSearchRequest()
            {
                Naziv=null
            };
            
            if (id.HasValue)
            {
                request.KontinentId = id;
            }
            else
            {
                request.KontinentId = 0;
            }
            var result = await _drzave.Get<List<Models.Drzava>>(request);
            result.Insert(0, new Models.Drzava() { Naziv="---" });
            cmbDrzava.DisplayMember = "Naziv";
            cmbDrzava.ValueMember = "Id";
            cmbDrzava.DataSource = result;
            cmbDrzava.SelectedValue = 0;
        }
        private async void frmGradoviDetalji_Load(object sender, EventArgs e)
        {
            await LoadKontinenti();
            await LoadDrzave(null);
            if(_id.HasValue)
            {
                
                var grad = await _gradovi.GetById<Models.Grad>(_id);
                var drzava = await _drzave.GetById<Models.Drzava>(grad.DrzavaId);
                var kontinent = await _kontinenti.GetById<Models.Kontinent>(drzava.KontinentId);
                txtNaziv.Text = grad.Naziv;
                cmbKontinenti.SelectedValue = kontinent.Id;
                await LoadDrzave(kontinent.Id);
                cmbDrzava.SelectedValue = grad.DrzavaId;
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                await _gradovi.Delete<bool>(_id);
                MessageBox.Show("Uspjesno obrisano");
                this.Close();
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
           
            GradoviInsertRequest grad = new GradoviInsertRequest()
            {
                Naziv=txtNaziv.Text,
                DrzavaId=int.Parse(cmbDrzava.SelectedValue.ToString())
            };
            if (this.ValidateChildren())
            {


                if (_id.HasValue)
                {
                    await _gradovi.Update<GradoviInsertRequest>(_id, grad);
                    MessageBox.Show("Uspjesno izmjenjeno!");
                    this.Close();

                }
                else
                {
                    //if (!string.IsNullOrWhiteSpace(grad.Naziv) && grad.DrzavaId > 0)
                    //{
                        await _gradovi.Insert<GradoviInsertRequest>(grad);
                        MessageBox.Show("Uspjesno dodano!");
                        this.Close();
                    //}
                }
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

        private void cmbDrzava_Validating(object sender, CancelEventArgs e)
        {
            if(int.Parse(cmbDrzava.SelectedValue.ToString())==0 || cmbDrzava.SelectedIndex==0 || cmbDrzava.SelectedIndex==-1 || cmbDrzava.SelectedValue==null || cmbDrzava.SelectedItem==null)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbDrzava, "Odaberite vrijednost");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbDrzava, null);
            }
        }

        private async  void cmbKontinenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKontinenti.SelectedIndex == 0 || cmbKontinenti.SelectedIndex == -1)
            {
                cmbDrzava.Enabled = false;
            }
            else
            {
                cmbDrzava.Enabled = true;
            }
            if (cmbKontinenti.SelectedValue.ToString()!=null && cmbKontinenti.SelectedIndex!=0 && cmbKontinenti.SelectedIndex!=-1)
            {
                kontinentid = int.Parse(cmbKontinenti.SelectedValue.ToString());
                await LoadDrzave(kontinentid);
            }
           
        }

        private void cmbKontinenti_Validating(object sender, CancelEventArgs e)
        {
            if(int.Parse(cmbKontinenti.SelectedValue.ToString())==0 || cmbKontinenti.SelectedIndex==0 || cmbKontinenti.SelectedIndex==-1 || cmbKontinenti.SelectedValue==null || cmbKontinenti.SelectedItem==null)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbKontinenti, "Odaberite vrijednost!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbKontinenti, null);

            }
        }

        private void cmbKontinenti_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (int.Parse(cmbKontinenti.SelectedValue.ToString()) == 0 || cmbKontinenti.SelectedValue == null || cmbKontinenti.SelectedItem == null)
            //{
                
            //    errorProvider1.SetError(cmbKontinenti, "Odaberite vrijednost!");
            //}
            //else
            //{
                
            //    errorProvider1.SetError(cmbKontinenti, null);

            //}
        }
    }
}
