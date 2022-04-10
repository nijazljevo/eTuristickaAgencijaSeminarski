using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.WinUI.Karte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace eTuristickaAgencija.WinUI.Korisnici
{
    
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _service = new APIService("Korisnici");
        private readonly APIService _ulogeservice = new APIService("Uloge");
        private int? _id = null;
        public frmKorisniciDetalji(int? id=null)
        {
            InitializeComponent();
            _id = id;

        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private Image Resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);
            return (Image)bmp;
        }

        private async Task LoadUloge()
        {
            var uloge = await _ulogeservice.Get<List<Models.Uloga>>(null);
            uloge.Insert(0, new Models.Uloga() { Naziv="---" });
            cmbUloge.DataSource = uloge;
            cmbUloge.ValueMember = "Id";
            cmbUloge.DisplayMember = "Naziv";
            

        }
        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {

            await LoadUloge();
            cmbUloge.SelectedValue = 0;
            if(_id.HasValue)
            {
                btnObrisi.Visible = true;
                
                var korisnik = await _service.GetById<Models.Korisnik>(_id);
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtEmail.Text = korisnik.Email;
                txtKorisnickoIme.Text = korisnik.KorisnikoIme;
                cmbUloge.SelectedValue = korisnik.UlogaId;
                txtLozinka.Text = " ";
                txtLozinkapotvrda.Text =" ";

                pbSlika.Image = ByteToImage(korisnik.Slika);
                pbSlika.Image = Resize(pbSlika.Image, 250, 250);
                kor.Slika = korisnik.Slika;
            }
            else
            {
                btnObrisi.Visible = false;
            }
        }
        Regex myregex = new Regex("[A-Za-z]{2,30}[@][A-Za-z]{2,8}[.][A-Za-z]{2,7}");
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            //this.ValidateChildren();
            KorisniciInsertRequest korisnik = new KorisniciInsertRequest()
            {
                Ime=txtIme.Text,
                Prezime=txtPrezime.Text,
                Email=txtEmail.Text,
                KorisnikoIme=txtKorisnickoIme.Text,
                Password=txtLozinka.Text,
                PasswordPotvrda=txtLozinkapotvrda.Text,
                UlogaId=int.Parse(cmbUloge.SelectedValue.ToString())
            };

           korisnik.Slika=kor.Slika;



            //if (korisnik.Ime != null && korisnik.UlogaId != 0 && korisnik.KorisnikoIme != null && korisnik.Email != null && myregex.IsMatch(korisnik.Email)
            //    && korisnik.Prezime != null && !string.IsNullOrWhiteSpace(korisnik.Password) && !string.IsNullOrWhiteSpace(korisnik.PasswordPotvrda) && korisnik.Password == korisnik.PasswordPotvrda)
            //{

            if (this.ValidateChildren())
            {

            
                if (_id.HasValue)
                {
                    await _service.Update<KorisniciInsertRequest>(_id, korisnik);
                    MessageBox.Show("Uspjesna izmjena!");
                    this.Close();
                }
                else
                {



                    await _service.Insert<KorisniciInsertRequest>(korisnik);
                    MessageBox.Show("Uspjesno dodavanje");
                    this.Close();

                }
            }
            //}



        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtIme.Text) || string.IsNullOrEmpty(txtIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtIme, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text) || string.IsNullOrEmpty(txtPrezime.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrezime, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || string.IsNullOrEmpty(txtKorisnickoIme.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtKorisnickoIme, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }

            if (!myregex.IsMatch(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Netacan format! example@exam.domain");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinka.Text) || string.IsNullOrEmpty(txtLozinka.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLozinka, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLozinka, null);
            }

        }

        private void txtLozinkapotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLozinkapotvrda.Text) || string.IsNullOrEmpty(txtLozinkapotvrda.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLozinkapotvrda, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLozinkapotvrda, null);
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                await _service.Delete<Models.Korisnik>(_id);
                MessageBox.Show("Uspjesno obrisano!");
                this.Close();
            }
        }

        private void cmbUloge_Validating(object sender, CancelEventArgs e)
        {
            if(int.Parse(cmbUloge.SelectedValue.ToString())==0 || cmbUloge.SelectedValue==null || cmbUloge.SelectedIndex==0 || cmbUloge.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbUloge, "Odaberite vrijednost");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbUloge, null);
            }
        }
        KorisniciInsertRequest kor = new KorisniciInsertRequest();
        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var fileslika = File.ReadAllBytes(filename);
                kor.Slika = fileslika;
                txtSlika.Text = filename;

                Image image = Image.FromFile(filename);
                image = Resize(image, 250, 250);
                pbSlika.Image = image;

            }
        }
     

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }
        

    }
}
