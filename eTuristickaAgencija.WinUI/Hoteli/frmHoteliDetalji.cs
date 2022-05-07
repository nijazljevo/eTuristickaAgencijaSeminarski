using eTuristickaAgencija.Models.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Windows.Forms;

namespace eTuristickaAgencija.WinUI.Hoteli
{
    public partial class frmHoteliDetalji : Form
    {
        private readonly APIService _kontinenti = new APIService("Kontinenti");
        private readonly APIService _drzave = new APIService("Drzave");
        private readonly APIService _gradovi = new APIService("Gradovi");
        private readonly APIService _hotel = new APIService("Hoteli");
        private int? _id = null;
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        PrintDocument printDocument = new PrintDocument();
        public frmHoteliDetalji(int? id = null)
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

        private async void frmHoteliDetalji_Load(object sender, EventArgs e)
        {

           

            if (_id.HasValue)
            {
                btnObrisi.Visible = true;
                btnPrint.Visible = true;
                panel1.Visible = true;
                var hotel = await _hotel.GetById<Models.Hotel>(_id);
                txtNaziv.Text = hotel.Naziv;

                var grad =await _gradovi.GetById<Models.Grad>(hotel.GradId);
                txtZvjezdice.Text = hotel.BrojZvjezdica.ToString();

                pbSlika.Image = ByteToImage(hotel.Slika);
                pbSlika.Image = Resize(pbSlika.Image, 250, 250);
                hot.Slika = hotel.Slika;
                await LoadDrzave();
                cmbDrzava.SelectedValue = grad.DrzavaId;

                await LoadGradovi(grad.DrzavaId);
                cmbGrad.SelectedValue = grad.Id;

                



               
                


            }
            else
            {
                await LoadDrzave();
                await LoadGradovi(null);
                txtZvjezdice.Text = "0";
                btnObrisi.Visible = false;
            }




        }

        async Task LoadDrzave()
        {
            DrzavaSearchRequest request = new DrzavaSearchRequest()
            {
                Naziv=null,
                KontinentId=0
            };
            var result = await _drzave.Get<List<Models.Drzava>>(request);
            result.Insert(0, new Models.Drzava() {Naziv="---" });
            cmbDrzava.DisplayMember = "Naziv";
            cmbDrzava.ValueMember = "Id";
            cmbDrzava.DataSource = result;
            cmbDrzava.SelectedValue = 0;
        }
        private async Task LoadGradovi(int? id)
        {
            GradoviSearchRequest request = new GradoviSearchRequest()
            {
                Naziv = null,
                DrzavaId = 0
            };
            if (id.HasValue)
            {
                request.DrzavaId = id;
            }

            var result = await _gradovi.Get<List<Models.Grad>>(request);
            result.Insert(0, new Models.Grad() {Naziv="---" });
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "Id";
            cmbGrad.DataSource = result;
            cmbGrad.SelectedValue = 0;
        }
        HotelInsertRequest hot = new HotelInsertRequest();

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filename = openFileDialog2.FileName;
                var fileslika = File.ReadAllBytes(filename);
                hot.Slika = fileslika;
                txtSlika.Text = filename;

                Image image = Image.FromFile(filename);
                image = Resize(image, 250, 250);
                pbSlika.Image = image;

            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            //this.ValidateChildren();

            var id = cmbGrad.SelectedValue;
            if (int.TryParse(id.ToString(), out int GradId))
            {
                hot.GradId = GradId;
            }
            if (string.IsNullOrEmpty(txtZvjezdice.Text))
            {
                hot.BrojZvjezdica = 0;
            }
            else
            {

                hot.BrojZvjezdica = int.Parse(txtZvjezdice.Text.ToString());
            }
            hot.Naziv = txtNaziv.Text;

           

            if(this.ValidateChildren())
            {

                if (_id.HasValue)
                {
                    hot.Id = _id.Value;
                    await _hotel.Update<HotelInsertRequest>(_id, hot);
                    MessageBox.Show("Izmjena uspjesna!");
                    this.Close();
                }
                else
                {

                    //if (hot.Naziv != null && hot.GradId != 0 && hot.Slika != null && hot.GradId != 0 && hot.BrojZvjezdica > 0 && hot.BrojZvjezdica < 6)
                    //{


                    await _hotel.Insert<HotelInsertRequest>(hot);
                    MessageBox.Show("Dodavanje uspjesno!");
                    this.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Unesite sve podatke!");
                    //}
                }
            }
            
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text) || string.IsNullOrEmpty(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNaziv, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        //private void cmbGrad_Validating(object sender, CancelEventArgs e)
        //{
        //    if (cmbGrad.SelectedValue == null || cmbGrad.SelectedIndex == 0 ||  int.Parse(cmbGrad.SelectedValue.ToString()) == 0)
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(cmbGrad, "Odaberite vrijednost!");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(cmbGrad, null);
        //    }
        //}

        private void txtZvjezdice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtZvjezdice.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtZvjezdice, "Obavezno polje!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtZvjezdice, null);
            }

            if (int.Parse(txtZvjezdice.Text.ToString())<1 || int.Parse(txtZvjezdice.Text.ToString())>5)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtZvjezdice, "Unesite vrijednosti izmedju 1 i 5!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtZvjezdice, null);
            }

        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if(_id.HasValue)
            {
                await _hotel.Delete<bool>(_id);
                MessageBox.Show("Uspjesno obrisano!");
                this.Close();
            }
        }

        private void pbSlika_Validating(object sender, CancelEventArgs e)
        {
            //if(hot.Slika==null)
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtSlika, "Odaberite sliku");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtSlika, null);
            //}
        }

        private void txtSlika_Validating(object sender, CancelEventArgs e)
        {
          /*  if (!_id.HasValue)
            {
                if (string.IsNullOrWhiteSpace(txtSlika.Text) || string.IsNullOrEmpty(txtSlika.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtSlika, "Odaberite sliku!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtSlika, null);
                }
            }*/
        }

        

        private async void cmbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            drzavaid = int.Parse(cmbDrzava.SelectedValue.ToString());
            await LoadGradovi(drzavaid);
        }

       

       

        private Image Resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);
            return (Image)bmp;
        }

        private void cmbDrzava_Validating(object sender, CancelEventArgs e)
        {
            if (cmbDrzava.SelectedValue == null || cmbDrzava.SelectedIndex == 0 || cmbDrzava.SelectedIndex==-1 || int.Parse(cmbDrzava.SelectedValue.ToString()) == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbDrzava, "Odaberite vrijednost!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbDrzava, null);
            }
        }

        private void cmbGrad_Validating_1(object sender, CancelEventArgs e)
        {
            if (cmbGrad.SelectedValue == null || cmbGrad.SelectedIndex == 0 || cmbGrad.SelectedIndex==-1 || int.Parse(cmbGrad.SelectedValue.ToString()) == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbGrad, "Odaberite vrijednost!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbGrad, null);
            }
        }

        private async void cmbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDrzava.SelectedValue.ToString()!=null && cmbDrzava.SelectedIndex!=0 && cmbDrzava.SelectedIndex!=-1)
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
    }
}
