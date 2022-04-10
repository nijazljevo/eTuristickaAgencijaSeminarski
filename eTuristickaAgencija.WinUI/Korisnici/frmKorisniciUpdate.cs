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

namespace eTuristickaAgencija.WinUI.Korisnici
{
    public partial class frmKorisniciUpdate : Form
    {
        private readonly APIService _service = new APIService("Korisnici");
        private int? _id = null;
        public frmKorisniciUpdate(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmKorisniciUpdate_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var korisnik = await _service.GetById<Models.Korisnik>(_id);
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtEmail.Text = korisnik.Email;
                txtKorisnickoIme.Text = korisnik.KorisnikoIme;

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            KorisniciInsertRequest korisnik = new KorisniciInsertRequest()
            {
                Id=int.Parse(_id.ToString()),
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Email = txtEmail.Text,
                KorisnikoIme = txtKorisnickoIme.Text
                
            };
            
                await _service.Update<Models.Korisnik>(korisnik.Id, korisnik);
                MessageBox.Show("Uspjesan update!");
                this.Close();
            
        }
    }
}
