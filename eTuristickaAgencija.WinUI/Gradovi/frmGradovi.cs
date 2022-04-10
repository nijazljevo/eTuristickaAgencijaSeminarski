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
    public partial class frmGradovi : Form
    {
        private readonly APIService _grad = new APIService("Grad");
        private readonly APIService _gradovi = new APIService("Gradovi");
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _kontinenti = new APIService("Kontinenti");

        public frmGradovi()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {

            
                if (this.ValidateChildren())
                {
                    var search = new GradoviSearchRequest()
                    {
                        Naziv = txtNaziv.Text,
                        DrzavaId = int.Parse(cmbDrzava.SelectedValue.ToString())

                    };
                    var result = await _gradovi.Get<List<Models.Grad>>(search);
                    dgvGradovi.AutoGenerateColumns = false;
                    dgvGradovi.DataSource = result;
                }
            
        }

        async Task LoadKontinenti()
        {
            
            var result = await _kontinenti.Get<List<Models.Kontinent>>(null);
            result.Insert(0, new Models.Kontinent() { Naziv="---" });
            
            cmbKontinent.DisplayMember = "Naziv";
            cmbKontinent.ValueMember = "Id";
            cmbKontinent.DataSource = result;
            cmbKontinent.SelectedIndex = 0;
        }
        private int? kontinentid = null;
        async Task LoadDrzave(int? id)
        {
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

        private async void frmGradovi_Load(object sender, EventArgs e)
        {
            await LoadKontinenti();
            cmbDrzava.Enabled = false;
        }

        private void dgvGradovi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvGradovi.SelectedRows[0].Cells[0].Value;
            frmGradoviDetalji frm = new frmGradoviDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private async  void cmbKontinent_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            if (cmbKontinent.SelectedValue.ToString() != null && cmbKontinent.SelectedIndex != -1 && cmbKontinent.SelectedIndex != 0)
            {
                cmbDrzava.Enabled = true;
                kontinentid = int.Parse(cmbKontinent.SelectedValue.ToString());
                await LoadDrzave(kontinentid);
            }
            else
            {
                cmbKontinent.SelectedIndex = 0;
                cmbDrzava.Enabled = false;
                
            }
        }

        private void cmbKontinent_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKontinent.SelectedValue.ToString() == null || cmbKontinent.SelectedValue == null || cmbKontinent.SelectedIndex == 0 || cmbKontinent.SelectedIndex == -1)
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

        private void cmbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void cmbKontinent_DropDown(object sender, EventArgs e)
        {
            if(cmbKontinent.SelectedIndex==-1 || cmbKontinent.SelectedItem==null)
            {
                cmbKontinent.SelectedIndex = 0;
            }
        }
    }
    }
