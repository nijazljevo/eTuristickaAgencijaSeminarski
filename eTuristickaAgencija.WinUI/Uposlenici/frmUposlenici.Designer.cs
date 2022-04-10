
namespace eTuristickaAgencija.WinUI.Uposlenici
{
    partial class frmUposlenici
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
            this.chcbAktivan = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNoviUposlenici = new System.Windows.Forms.Button();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.Od = new System.Windows.Forms.Label();
            this.dtpDatumZaposlenja = new System.Windows.Forms.DateTimePicker();
            this.Termini = new System.Windows.Forms.GroupBox();
            this.dgvUposlenici = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumZaposlenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbKorisnik = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Termini.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).BeginInit();
            this.SuspendLayout();
            // 
            // chcbAktivan
            // 
            this.chcbAktivan.AutoSize = true;
            this.chcbAktivan.Location = new System.Drawing.Point(371, 95);
            this.chcbAktivan.Name = "chcbAktivan";
            this.chcbAktivan.Size = new System.Drawing.Size(15, 14);
            this.chcbAktivan.TabIndex = 21;
            this.chcbAktivan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(302, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Aktivan";
            // 
            // btnNoviUposlenici
            // 
            this.btnNoviUposlenici.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNoviUposlenici.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNoviUposlenici.Location = new System.Drawing.Point(630, 84);
            this.btnNoviUposlenici.Name = "btnNoviUposlenici";
            this.btnNoviUposlenici.Size = new System.Drawing.Size(119, 37);
            this.btnNoviUposlenici.TabIndex = 19;
            this.btnNoviUposlenici.Text = "Dodaj uposlenika";
            this.btnNoviUposlenici.UseVisualStyleBackColor = false;
            this.btnNoviUposlenici.Click += new System.EventHandler(this.btnNoviUposlenici_Click);
            // 
            // btnTrazi
            // 
            this.btnTrazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTrazi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTrazi.Location = new System.Drawing.Point(437, 84);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(89, 37);
            this.btnTrazi.TabIndex = 18;
            this.btnTrazi.Text = "Trazi";
            this.btnTrazi.UseVisualStyleBackColor = false;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // Od
            // 
            this.Od.AutoSize = true;
            this.Od.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Od.Location = new System.Drawing.Point(52, 2);
            this.Od.Name = "Od";
            this.Od.Size = new System.Drawing.Size(91, 13);
            this.Od.TabIndex = 14;
            this.Od.Text = "Datum zaposlenja";
            // 
            // dtpDatumZaposlenja
            // 
            this.dtpDatumZaposlenja.Location = new System.Drawing.Point(55, 23);
            this.dtpDatumZaposlenja.Name = "dtpDatumZaposlenja";
            this.dtpDatumZaposlenja.Size = new System.Drawing.Size(231, 20);
            this.dtpDatumZaposlenja.TabIndex = 12;
            // 
            // Termini
            // 
            this.Termini.Controls.Add(this.dgvUposlenici);
            this.Termini.Location = new System.Drawing.Point(35, 121);
            this.Termini.Name = "Termini";
            this.Termini.Size = new System.Drawing.Size(731, 327);
            this.Termini.TabIndex = 11;
            this.Termini.TabStop = false;
            this.Termini.Text = "Uposlenici";
            // 
            // dgvUposlenici
            // 
            this.dgvUposlenici.AllowUserToAddRows = false;
            this.dgvUposlenici.AllowUserToDeleteRows = false;
            this.dgvUposlenici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUposlenici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DatumZaposlenja,
            this.Aktivan});
            this.dgvUposlenici.Location = new System.Drawing.Point(0, 25);
            this.dgvUposlenici.Name = "dgvUposlenici";
            this.dgvUposlenici.ReadOnly = true;
            this.dgvUposlenici.RowHeadersWidth = 51;
            this.dgvUposlenici.RowTemplate.Height = 24;
            this.dgvUposlenici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUposlenici.Size = new System.Drawing.Size(731, 291);
            this.dgvUposlenici.TabIndex = 0;
            this.dgvUposlenici.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvUposlenici_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // DatumZaposlenja
            // 
            this.DatumZaposlenja.DataPropertyName = "DatumZaposlenja";
            this.DatumZaposlenja.HeaderText = "DatumZaposlenja";
            this.DatumZaposlenja.MinimumWidth = 6;
            this.DatumZaposlenja.Name = "DatumZaposlenja";
            this.DatumZaposlenja.ReadOnly = true;
            this.DatumZaposlenja.Width = 125;
            // 
            // Aktivan
            // 
            this.Aktivan.DataPropertyName = "AktivanTermin";
            this.Aktivan.HeaderText = "Aktivan";
            this.Aktivan.MinimumWidth = 6;
            this.Aktivan.Name = "Aktivan";
            this.Aktivan.ReadOnly = true;
            this.Aktivan.Width = 125;
            // 
            // cmbKorisnik
            // 
            this.cmbKorisnik.FormattingEnabled = true;
            this.cmbKorisnik.Location = new System.Drawing.Point(55, 74);
            this.cmbKorisnik.Name = "cmbKorisnik";
            this.cmbKorisnik.Size = new System.Drawing.Size(231, 21);
            this.cmbKorisnik.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(52, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Korisnik";
            // 
            // frmUposlenici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKorisnik);
            this.Controls.Add(this.chcbAktivan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNoviUposlenici);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.Od);
            this.Controls.Add(this.dtpDatumZaposlenja);
            this.Controls.Add(this.Termini);
            this.Name = "frmUposlenici";
            this.Text = "frmUposlenici";
            this.Load += new System.EventHandler(this.frmUposlenici_Load);
            this.Termini.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chcbAktivan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNoviUposlenici;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.Label Od;
        private System.Windows.Forms.DateTimePicker dtpDatumZaposlenja;
        private System.Windows.Forms.GroupBox Termini;
        private System.Windows.Forms.DataGridView dgvUposlenici;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumZaposlenja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aktivan;
        private System.Windows.Forms.ComboBox cmbKorisnik;
        private System.Windows.Forms.Label label1;
    }
}