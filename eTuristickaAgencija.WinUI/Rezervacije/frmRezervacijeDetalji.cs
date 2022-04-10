using eTuristickaAgencija.Models.Request;
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

namespace eTuristickaAgencija.WinUI.Rezervacije
{
    public partial class frmRezervacijeDetalji : Form
    {
        private readonly APIService _rezervacije = new APIService("Rezervacija");
        private readonly APIService _korisnici = new APIService("Korisnici");
        private readonly APIService _hoteli = new APIService("Hoteli");
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        PrintDocument printDocument = new PrintDocument();
        //// private int? _id = null;
        private Models.Rezervacija _rezervacijaModel;
        public frmRezervacijeDetalji(Models.Rezervacija rezervacije = null)
        {
            InitializeComponent();
            _rezervacijaModel = rezervacije;
        }
        private async Task LoadKorisnici()
        {
            var result = await _korisnici.Get<List<Models.Korisnik>>(null);
            result.Insert(0, new Models.Korisnik() { Ime = "---" });
            cmbKorisnik.DisplayMember = "Ime";
            cmbKorisnik.ValueMember = "Id";
            cmbKorisnik.DataSource = result;
        }
        private async Task LoadHoteli()
        {
            var result = await _hoteli.Get<List<Models.Hotel>>(null);
            result.Insert(0, new Models.Hotel() { Naziv = "---" });
            cmbHotel.DisplayMember = "Naziv";
            cmbHotel.ValueMember = "Id";
            cmbHotel.DataSource = result;
        }
        private async void frmRezervacijeDetalji_Load(object sender, EventArgs e)
        {
            await LoadKorisnici();
            await LoadHoteli();
            if (_rezervacijaModel!=null)
            {
                btnPrint.Visible = true;
                btnObrisi.Visible = true;
                panel1.Visible = true;
                var rezervacija = await _rezervacije.GetById<Models.Rezervacija>(_rezervacijaModel.Id);
                chcbOtkazana.Checked = rezervacija.Otkazana.Value;
                cmbKorisnik.SelectedValue = rezervacija.KorisnikId;
                dtpDatumRezervacije.Value = rezervacija.DatumRezervacije;
                cmbHotel.SelectedValue = rezervacija.HotelId;
                txtCijena.Text = rezervacija.Cijena.ToString();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {

            if (_rezervacijaModel!=null)
            {
                await _rezervacije.Delete<bool>(_rezervacijaModel.Id);
                MessageBox.Show("Uspjesno obrisano");
                this.Close();
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            RezervacijaInsertRequest rezervacija = new RezervacijaInsertRequest()
            {
                DatumRezervacije = dtpDatumRezervacije.Value,
                Cijena = decimal.Parse(txtCijena.Text.ToString()),
                Otkazana = chcbOtkazana.Checked,
                HotelId = int.Parse(cmbHotel.SelectedValue.ToString()),
                KorisnikId = int.Parse(cmbKorisnik.SelectedValue.ToString())
            };
            if (this.ValidateChildren())
            {


                if (_rezervacijaModel != null)
                {
                    await _rezervacije.Update<RezervacijaInsertRequest>(_rezervacijaModel.Id, rezervacija);
                    MessageBox.Show("Uspjesno izmjenjeno!");
                    this.Close();

                }
                else
                {

                    await _rezervacije.Insert<RezervacijaInsertRequest>(rezervacija);
                    MessageBox.Show("Uspjesno dodano!");
                    this.Close();

                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
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
