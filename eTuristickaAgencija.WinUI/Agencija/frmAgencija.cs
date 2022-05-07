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

namespace eTuristickaAgencija.WinUI.Agencija
{
    public partial class frmAgencija : Form
    {
        private readonly APIService _agencija = new APIService("Agencija");
        public frmAgencija()
        {
            InitializeComponent();
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            AgencijaSearchRequest search = new AgencijaSearchRequest()
            {
                Adresa = txtAdresa.Text
                
                
            };


            var result = await _agencija.Get<List<Models.Agencija>>(search);
            dgvAgencija.AutoGenerateColumns = false;
            dgvAgencija.DataSource = result;
        }

        private async void dgvAgencija_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = dgvAgencija.SelectedRows[0].DataBoundItem;
            frmAgencijaDetalji frm = new frmAgencijaDetalji(item as Models.Agencija);
            frm.Show();
        }
    }
}
