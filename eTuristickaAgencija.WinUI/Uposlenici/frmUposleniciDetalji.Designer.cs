
namespace eTuristickaAgencija.WinUI.Uposlenici
{
    partial class frmUposleniciDetalji
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKorisnik = new System.Windows.Forms.ComboBox();
            this.chcbAktivan = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.Od = new System.Windows.Forms.Label();
            this.dtpDatumZaposlenja = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(52, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Korisnik";
            // 
            // cmbKorisnik
            // 
            this.cmbKorisnik.FormattingEnabled = true;
            this.cmbKorisnik.Location = new System.Drawing.Point(55, 102);
            this.cmbKorisnik.Name = "cmbKorisnik";
            this.cmbKorisnik.Size = new System.Drawing.Size(231, 21);
            this.cmbKorisnik.TabIndex = 30;
            // 
            // chcbAktivan
            // 
            this.chcbAktivan.AutoSize = true;
            this.chcbAktivan.Location = new System.Drawing.Point(116, 135);
            this.chcbAktivan.Name = "chcbAktivan";
            this.chcbAktivan.Size = new System.Drawing.Size(15, 14);
            this.chcbAktivan.TabIndex = 29;
            this.chcbAktivan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(55, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Aktivan";
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnObrisi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnObrisi.Location = new System.Drawing.Point(195, 167);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(119, 37);
            this.btnObrisi.TabIndex = 27;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSacuvaj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSacuvaj.Location = new System.Drawing.Point(42, 167);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(89, 37);
            this.btnSacuvaj.TabIndex = 26;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // Od
            // 
            this.Od.AutoSize = true;
            this.Od.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Od.Location = new System.Drawing.Point(52, 30);
            this.Od.Name = "Od";
            this.Od.Size = new System.Drawing.Size(91, 13);
            this.Od.TabIndex = 25;
            this.Od.Text = "Datum zaposlenja";
            // 
            // dtpDatumZaposlenja
            // 
            this.dtpDatumZaposlenja.Location = new System.Drawing.Point(55, 51);
            this.dtpDatumZaposlenja.Name = "dtpDatumZaposlenja";
            this.dtpDatumZaposlenja.Size = new System.Drawing.Size(231, 20);
            this.dtpDatumZaposlenja.TabIndex = 24;
            // 
            // frmUposleniciDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKorisnik);
            this.Controls.Add(this.chcbAktivan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.Od);
            this.Controls.Add(this.dtpDatumZaposlenja);
            this.Name = "frmUposleniciDetalji";
            this.Text = "frmUposleniciDetalji";
            this.Load += new System.EventHandler(this.frmUposleniciDetalji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKorisnik;
        private System.Windows.Forms.CheckBox chcbAktivan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label Od;
        private System.Windows.Forms.DateTimePicker dtpDatumZaposlenja;
    }
}