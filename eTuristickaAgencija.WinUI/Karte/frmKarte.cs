using eTuristickaAgencija.Models.Request;
using eTuristickaAgencija.WinUI.Korisnici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTuristickaAgencija.WinUI.Karte
{
    public partial class frmKarte : Form
    {
        private readonly APIService _karte = new APIService("Karte");
        private int? terminid = null;
        public frmKarte(int? _terminid)
        {
            InitializeComponent();
            if(_terminid.HasValue)
            {
                terminid = _terminid;
            }
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                var search = new KartaSearchRequest()
                {
                    TerminID=int.Parse(terminid.ToString()),
                    Ponistena=chckPonistena.Checked
                    
                };

                var result = await _karte.Get<List<Models.Karta>>(search);
                dgvKarte.AutoGenerateColumns = false;
                dgvKarte.DataSource = result;

            }
        }

        private void dgvKarte_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var korisnikid = dgvKarte.SelectedRows[0].Cells[1].Value;
            frmKorisniciDetalji frm = new frmKorisniciDetalji(int.Parse(korisnikid.ToString()));
            frm.Show();
        }
    }
}
