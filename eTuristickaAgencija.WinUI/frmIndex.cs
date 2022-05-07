using eTuristickaAgencija.WinUI.Agencija;
using eTuristickaAgencija.WinUI.Destinacije;
using eTuristickaAgencija.WinUI.Drzave;
using eTuristickaAgencija.WinUI.Gradovi;
using eTuristickaAgencija.WinUI.Hoteli;
using eTuristickaAgencija.WinUI.Kontinenti;
using eTuristickaAgencija.WinUI.Korisnici;
using eTuristickaAgencija.WinUI.Rezervacije;
using eTuristickaAgencija.WinUI.Uposlenici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTuristickaAgencija.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisniciDetalji frm = new frmKorisniciDetalji();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmDestinacije frm = new frmDestinacije();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaDestinacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDestinacijeDetalji frm = new frmDestinacijeDetalji();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmHoteli frm = new frmHoteli();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoteliDetalji frm = new frmHoteliDetalji();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void kontinentiPretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKontinenti frm = new frmKontinenti();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKontinentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKontinentiDetalji frm = new frmKontinentiDetalji();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void drzavePretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrzave frm = new frmDrzave();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaDrzavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrzaveDetalji frm = new frmDrzaveDetalji();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void gradoviPretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradovi frm = new frmGradovi();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradoviDetalji frm = new frmGradoviDetalji();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void hoteli2PretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmHoteli2 frm = new frmHoteli2();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnDestinacije_Click(object sender, EventArgs e)
        {
            frmDestinacije frm = new frmDestinacije();
            frm.Show();
        }

        private void btnHoteli_Click(object sender, EventArgs e)
        {
            frmHoteli frm = new frmHoteli();
            frm.Show();
        }

        private void pretragaUposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUposlenici frm = new frmUposlenici();
            frm.Show();
        }

        private void noviUposleniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUposleniciDetalji frm = new frmUposleniciDetalji();
            frm.Show();
        }

        private void pretragaRezervacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRezervacije frm = new frmRezervacije();
            frm.Show();
        }

        private void novaRezervacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRezervacijeDetalji frm = new frmRezervacijeDetalji();
            frm.Show();
        }

        private void pretragaAgencijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgencija frm = new frmAgencija();
            frm.Show();
        }
    }
}
