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

namespace eTuristickaAgencija.WinUI.Hoteli
{
    public partial class frmHoteli : Form
    {
        private readonly APIService _hoteli = new APIService("Hoteli");
        private readonly APIService _gradovi = new APIService("Gradovi");
        
        private readonly APIService _kontinenti = new APIService("Kontinenti");
        private readonly APIService _drzave = new APIService("Drzave");
        public frmHoteli()
        {
            InitializeComponent();
        }
        private int? kontinentid = null;
        private int? drzavaid = null;



        async Task LoadKontinenti()
        {
            var result = await _kontinenti.Get<List<Models.Kontinent>>(null);
            result.Insert(0, new Models.Kontinent() {Naziv="---" });
            cmbKontinent.DisplayMember = "Naziv";
            cmbKontinent.ValueMember = "Id";
            cmbKontinent.DataSource = result;
            cmbKontinent.SelectedIndex = 0;
            
        }

        async Task LoadDrzave(int? id)
        {
            //DrzavaSearchRequest request = new DrzavaSearchRequest()
            //{
            //    Naziv = null,
            //    KontinentId = null
            //};

            //if (id.HasValue)
            //{
            //    request.KontinentId = id;
            //}
            //else
            //{
            //    request.KontinentId = 0;
            //}
            DrzavaSearchRequest request = new DrzavaSearchRequest()
            {
                Naziv = null,
                KontinentId = id
            };

            var result = await _drzave.Get<List<Models.Drzava>>(request);
            //result.Insert(0, new Models.Drzava());
            cmbDrzava.DisplayMember = "Naziv";
            cmbDrzava.ValueMember = "Id";
            cmbDrzava.DataSource = result;
            cmbDrzava.SelectedIndex = 0;
            
        }

        async Task LoadGradovi(int? id)
        {
            //GradoviSearchRequest request = new GradoviSearchRequest()
            //{
            //    Naziv = null,
            //    DrzavaId = null
            //};

            //if (id.HasValue)
            //{
            //    request.DrzavaId = id;
            //}
            //else
            //{
            //    request.DrzavaId = 0;
            //}

            GradoviSearchRequest request = new GradoviSearchRequest()
            {
                Naziv = null,
                DrzavaId = id
            };
            var result = await _gradovi.Get<List<Models.Grad>>(request);
            //result.Insert(0, new Models.Grad());
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "Id";
            cmbGrad.DataSource = result;
            cmbGrad.SelectedIndex = 0;
           
            
        }


        private void dgvHoteli_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvHoteli.SelectedRows[0].Cells[0].Value;
            frmHoteliDetalji frm = new frmHoteliDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            
            if (this.ValidateChildren())
            {
                var search = new HotelSearchRequest()
                {
                    Naziv = txtNaziv.Text,
                    GradId = int.Parse(cmbGrad.SelectedValue.ToString())

                };

                var result = await _hoteli.Get<List<Models.Hotel>>(search);
                dgvHoteli.AutoGenerateColumns = false;
                dgvHoteli.DataSource = result;
            }

        }

       

        

        private async void cmbKontinent_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if(cmbKontinent.SelectedValue.ToString()!=null && cmbKontinent.SelectedIndex!=-1 && cmbKontinent.SelectedIndex!=0 )
            {
                cmbDrzava.Enabled = true;
                kontinentid = int.Parse(cmbKontinent.SelectedValue.ToString());
                await LoadDrzave(kontinentid);
            }
            else
            {
                cmbDrzava.Enabled = false;
                cmbGrad.Enabled = false;
            }
        }

        private void cmbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void cmbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDrzava.SelectedValue.ToString() != null && cmbDrzava.SelectedIndex != -1)
            {
                cmbGrad.Enabled = true;
                drzavaid = int.Parse(cmbDrzava.SelectedValue.ToString());
                await LoadGradovi(drzavaid);
            }
            else
            {
                cmbGrad.Enabled = false;

            }
        }

        private void cmbKontinent_Validating(object sender, CancelEventArgs e)
        {
            if(cmbKontinent.SelectedValue.ToString()==null || cmbKontinent.SelectedValue==null || cmbKontinent.SelectedIndex==0 || cmbKontinent.SelectedIndex==-1)
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

        private void cmbDrzava_Validating(object sender, CancelEventArgs e)
        {
            if (cmbDrzava.Enabled == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbDrzava, "Odaberite grad!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbDrzava, null);
            }
            

        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            if(cmbGrad.Enabled==false)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbGrad, "Odaberite grad!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbGrad, null);
            }

            
        }

        

        private async void frmHoteli_Load(object sender, EventArgs e)
        {
            await LoadKontinenti();

            cmbDrzava.Enabled = false;
            cmbGrad.Enabled = false;
        }

        private void btnNovihotel_Click(object sender, EventArgs e)
        {
            frmHoteliDetalji frm = new frmHoteliDetalji();
            frm.Show();
        }
    }
}
