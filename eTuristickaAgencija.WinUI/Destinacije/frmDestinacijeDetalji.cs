using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.WinUI.Termini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTuristickaAgencija.WinUI.Destinacije
{
    
    public partial class frmDestinacijeDetalji : Form
    {
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _gradovi = new APIService("Gradovi");
        private readonly APIService _destinacija = new APIService("Destinacije");
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        PrintDocument printDocument = new PrintDocument();
        private int? _id = null;
        public frmDestinacijeDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }
        private int? drzavaid = null;

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private async void frmDestinacijeDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                btnObrisi.Visible = true;
                btnTermini.Visible = true;
                btnPrint.Visible = true;
                panel1.Visible = true;
                var destinacija = await _destinacija.GetById<Models.Destinacija>(_id);
                txtNaziv.Text = destinacija.Naziv;
                var grad = await _gradovi.GetById<Models.Grad>(destinacija.GradId);
               
                
                pbSlika.Image = ByteToImage(destinacija.Slika);
                pbSlika.Image = Resize(pbSlika.Image, 250, 250);

                var result = await _gradovi.Get<List<Models.Grad>>(null);

               
                des.Slika = destinacija.Slika;
                await LoadDrzave();
                cmbDrzava.SelectedValue = grad.DrzavaId;
                await LoadGradovi(grad.DrzavaId);
                cmbGrad.SelectedValue = grad.Id;

                //cmbGrad.DisplayMember = "Naziv";
                //cmbGrad.ValueMember = "Id";
                
                //cmbGrad.DataSource = result;
                //cmbGrad.SelectedValue = destinacija.GradId; //radi novog itema u cmblisti
                //                                 //implementirati update 


            }
            else
            {
                btnObrisi.Visible = false;
                btnTermini.Visible = false;
                await LoadDrzave();
                await LoadGradovi(null);
            }
            
        }

        private async Task LoadDrzave()
        {
            DrzavaSearchRequest request = new DrzavaSearchRequest()
            {
                Naziv = null,
                KontinentId = 0
            };
            var result = await _drzave.Get<List<Models.Drzava>>(request);
            result.Insert(0, new Models.Drzava() {Naziv="---" });
            cmbDrzava.DisplayMember = "Naziv";
            cmbDrzava.ValueMember = "Id";
            cmbDrzava.DataSource = result;
        }
        private async Task LoadGradovi(int? id)
        {
            GradoviSearchRequest request = new GradoviSearchRequest()
            {
                Naziv=null
            };
            if(id.HasValue)
            {
                request.DrzavaId = id;
            }
            else
            {
                request.DrzavaId = 0;
            }
            var result = await _gradovi.Get<List<Models.Grad>>(request);
            result.Insert(0, new Models.Grad() { Naziv="---"});
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "Id";
            cmbGrad.DataSource = result;
            cmbGrad.SelectedValue = 0;
        }
        DestinacijaInsertRequest des = new DestinacijaInsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {

            

            var id = cmbGrad.SelectedValue;
            if(int.TryParse(id.ToString(),out int GradId))
            {
                des.GradId = GradId;
            }
            des.Naziv = txtNaziv.Text;
            
            if(this.ValidateChildren())
            {

            
            if (_id.HasValue)
            {
                await _destinacija.Update<DestinacijaInsertRequest>(_id, des);
                MessageBox.Show("Izmjena uspjesna");
                this.Close();
            }
            else
            {
                
                    await _destinacija.Insert<DestinacijaInsertRequest>(des);
                    MessageBox.Show("Dodavanje uspjesno");
                    this.Close();
                
            }
            }


        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if(result== DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var fileslika = File.ReadAllBytes(filename);
                des.Slika = fileslika;
                txtSlika.Text= filename;

                Image image = Image.FromFile(filename);
                image = Resize(image, 250, 250);
                pbSlika.Image = image;

            }
        }
        private Image Resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);
            return (Image)bmp;
        }

        private void btnTermini_Click(object sender, EventArgs e)
        {
             if(_id.HasValue)
            {
                frmTermini frm = new frmTermini(int.Parse(_id.ToString()));
                frm.Show();
            }
        }

        private void btnNoviTermin_Click(object sender, EventArgs e)
        {
            //if (_id.HasValue)
            //{
            //    frmTerminiDetalji frm = new frmTerminiDetalji(int.Parse(_id.ToString()), null);
            //    frm.Show();
            //}

        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                await _destinacija.Delete<bool>(_id);
                MessageBox.Show("Uspjesno obrisano!");
                this.Close();
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, "Unesite vrijednost");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        

        

        private void txtSlika_Validating(object sender, CancelEventArgs e)
        {
            if (!_id.HasValue)
            {
                if (string.IsNullOrEmpty(txtSlika.Text) || string.IsNullOrWhiteSpace(txtSlika.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtSlika, "Unesite naziv fajla ili odaberite fajl!");

                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtSlika, null);
                }

            }

        }

        private async void cmbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            drzavaid = int.Parse(cmbDrzava.SelectedValue.ToString());
            await LoadGradovi(drzavaid);
        }

        private void cmbDrzava_Validating(object sender, CancelEventArgs e)
        {
            if (cmbDrzava.SelectedValue == null || int.Parse(cmbDrzava.SelectedValue.ToString()) == 0 || cmbDrzava.SelectedIndex==0 || cmbDrzava.SelectedIndex==-1)
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

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGrad.SelectedValue == null || int.Parse(cmbGrad.SelectedValue.ToString()) == 0 || cmbGrad.SelectedIndex==0 || cmbGrad.SelectedIndex==-1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbGrad, "Odaberite vrijednost");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbGrad, null);
            }
        }

        private async void cmbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cmbDrzava.SelectedValue.ToString()!=null&& cmbDrzava.SelectedIndex!=0 && cmbDrzava.SelectedIndex!=-1)
            {
                drzavaid = int.Parse(cmbDrzava.SelectedValue.ToString());
                await LoadGradovi(drzavaid);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
        }
        public void Print(Panel panel)
        {
            PrinterSettings printerSettings = new PrinterSettings();
            panel1 = panel;
            GetPrintArea(panel);
            previewDialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(printDocPrintPage);
            previewDialog.ShowDialog();


        }

        private void printDocPrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memorying, (pagearea.Width / 2) - this.panel1.Width / 2, this.panel1.Location.Y);

        }

        Bitmap memorying;
        public void GetPrintArea(Panel panel)
        {
            memorying = new Bitmap(panel.Height, panel.Width);
            panel.DrawToBitmap(memorying, new Rectangle(0, 0, panel.Width, panel.Height));
        }

        //private void txtNaziv_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtNaziv.Text))
        //    {
        //        errorProvider1.SetError(txtNaziv, "Obavezno polje!");
        //    }
        //    else
        //    {
        //        errorProvider1.SetError(txtNaziv, null);
        //    }
        //}
    }
}
