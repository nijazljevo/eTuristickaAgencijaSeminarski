using eTuristickaAgencija.Models;
using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.WinUI.Karte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTuristickaAgencija.WinUI.Termini
{
    public partial class frmTerminiDetalji : Form
    {
        private readonly APIService _hoteli = new APIService("Hoteli");
        private readonly APIService _termini = new APIService("Termini");
        private readonly APIService _destinacije = new APIService("Destinacije");
        private readonly APIService _karte = new APIService("Karte");

        private int? _id = null;
        private int? _destinacijaid = null;
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        PrintDocument printDocument = new PrintDocument();



        public frmTerminiDetalji(int? destinacijaid = null, int? id = null)
        {
            InitializeComponent();
            _id = id;
            _destinacijaid = destinacijaid;
        }

        private async Task LoadHoteli()
        {
            var destinacija = await _destinacije.GetById<Models.Destinacija>(_destinacijaid);
            var search = new HotelSearchRequest()
            {
                GradId = destinacija.GradId

            };
            var result = await _hoteli.Get<List<Models.Hotel>>(search);

            result.Insert(0, new Models.Hotel() { Naziv = "---" });
            cmbHotel.DisplayMember = "Naziv";
            cmbHotel.ValueMember = "Id";
            cmbHotel.DataSource = result;

        }

    
        private async void frmTerminiDetalji_Load(object sender, EventArgs e)
        {
            await LoadHoteli();
            if (!_id.HasValue)
            {
                txtCijena.Text = "0";
                txtPopust.Text = "0";
                txtAkcijskaCijena.Text = "0";
                pickerOd.MinDate = System.DateTime.Now;
                pickerDo.MinDate = System.DateTime.Now;
                btnObrisi.Visible = false;
                btnPrint.Visible = false;
                btnKarte.Visible = false;
                panel1.Visible = false;
            }


            if (_id.HasValue)
            {
                btnObrisi.Visible = true;
                btnPrint.Visible = true;
                btnKarte.Visible = true;
                panel1.Visible = true;

               

                var termin = await _termini.GetById<Models.Termin>(_id);
                pickerOd.Value = termin.DatumPolaska;
                pickerDo.Value = termin.DatumDolaska;
                chcboxAktivan.Checked = termin.AktivanTermin;
                txtPopust.Text = termin.Popust.ToString();
                txtCijena.Text = termin.Cijena.ToString();
                txtAkcijskaCijena.Text = termin.CijenaPopust.ToString();


                //var t = await _termini.GetById<Models.Termin>(_id);
                var search = new HotelSearchRequest
                {
                    GradId = termin.GradId
                };
                var result = await _hoteli.Get<List<Models.Hotel>>(search);


                cmbHotel.DisplayMember = "Naziv";
                cmbHotel.ValueMember = "Id";

                cmbHotel.DataSource = result;
                cmbHotel.SelectedValue = termin.HotelId; //radi novog itema u cmblisti
                                                         //implementirati update 


            }


        }


        TerminInsertRequest tir = new TerminInsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();

            var id = cmbHotel.SelectedValue;
            if (int.TryParse(id.ToString(), out int HotelId))
            {
                tir.HotelId = HotelId;
            }
            tir.AktivanTermin = chcboxAktivan.Checked;
            tir.Cijena = decimal.Parse(txtCijena.Text.ToString());
            if (txtPopust.Text == null)
            {
                tir.Popust = 0;
            }
            else
            {
                tir.Popust = float.Parse(txtPopust.Text.ToString());
            }

            tir.DatumDolaska = pickerDo.Value;
            tir.DatumPolaska = pickerOd.Value;
            tir.DestinacijaId = int.Parse(_destinacijaid.ToString());
            var destinacija = await _destinacije.GetById<Models.Destinacija>(_destinacijaid);
            tir.GradId = destinacija.GradId;

            if (_id.HasValue)
            {
                if (tir.HotelId > 0 && tir.Cijena > 0)
                {
                    await _termini.Update<Models.Termin>(_id, tir);
                    MessageBox.Show("Izmjena uspjesna!");
                    this.Close();
                }
            }
            else
            {
                if (tir.HotelId > 0 && tir.Cijena > 0)
                {
                    await _termini.Insert<Models.Termin>(tir);
                    MessageBox.Show("Dodavanje uspjesno!");
                    this.Close();
                }

            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

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

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text) || float.Parse(txtCijena.Text.ToString()) == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCijena, "Unesite vrijednost!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCijena, null);
            }
        }

        private void txtPopust_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPopust.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPopust, "Unesite vrijednost!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPopust, null);
            }

            if (float.Parse(txtPopust.Text.ToString()) < 0 || float.Parse(txtPopust.Text.ToString()) > 100)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPopust, "Unesite vrijednost izmedju 0 i 100!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPopust, null);
            }


        }

        private void cmbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbHotel_Validating(object sender, CancelEventArgs e)
        {
            /*if (int.Parse(cmbHotel.SelectedValue.ToString()) == 0 || cmbHotel.SelectedIndex == -1 || cmbHotel.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbHotel, "Odaberite hotel!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbHotel, null);
            }*/
        }

        private void txtCijena_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txtPopust_MouseLeave(object sender, EventArgs e)
        {

            var minus = decimal.Parse(txtCijena.Text.ToString()) * (decimal.Parse(txtPopust.Text.ToString()) / 100);
            if (minus == 0)
            {
                txtAkcijskaCijena.Text = "0";
                tir.CijenaPopust = 0;
            }
            else
            {


                var akcijska = decimal.Parse(txtCijena.Text.ToString()) - minus;
                txtAkcijskaCijena.Text = akcijska.ToString();
                tir.CijenaPopust = decimal.Parse(txtAkcijskaCijena.Text.ToString());
            }
        }





        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                await _termini.Delete<bool>(_id);
                MessageBox.Show("Uspjesno obrisano!");
                this.Close();
            }
        }

        private void pickerDo_Validating(object sender, CancelEventArgs e)
        {
            if (pickerDo.Value.Date <= pickerOd.Value.Date)
            {
                e.Cancel = true;
                errorProvider1.SetError(pickerDo, "Datum dolaska raniji od datuma polaska!Unesite novi datum!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(pickerDo, null);
            }
        }

        private void btnKarte_Click(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                frmKarte frm = new frmKarte(_id);
                frm.Show();
            }
        }
    }
}
