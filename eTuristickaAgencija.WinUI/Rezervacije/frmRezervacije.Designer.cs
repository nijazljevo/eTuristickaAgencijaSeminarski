
namespace eTuristickaAgencija.WinUI.Rezervacije
{
    partial class frmRezervacije
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
            this.chcbOtkazana = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNoveRezervacije = new System.Windows.Forms.Button();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.Od = new System.Windows.Forms.Label();
            this.dtpDatumRezervacije = new System.Windows.Forms.DateTimePicker();
            this.Rezervacije = new System.Windows.Forms.GroupBox();
            this.dgvRezervacije = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumRezervacije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Otkazana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbHotel = new System.Windows.Forms.ComboBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Rezervacije.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(52, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Korisnik";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbKorisnik
            // 
            this.cmbKorisnik.FormattingEnabled = true;
            this.cmbKorisnik.Location = new System.Drawing.Point(55, 74);
            this.cmbKorisnik.Name = "cmbKorisnik";
            this.cmbKorisnik.Size = new System.Drawing.Size(231, 21);
            this.cmbKorisnik.TabIndex = 31;
            this.cmbKorisnik.SelectedIndexChanged += new System.EventHandler(this.cmbKorisnik_SelectedIndexChanged);
            // 
            // chcbOtkazana
            // 
            this.chcbOtkazana.AutoSize = true;
            this.chcbOtkazana.Location = new System.Drawing.Point(371, 95);
            this.chcbOtkazana.Name = "chcbOtkazana";
            this.chcbOtkazana.Size = new System.Drawing.Size(15, 14);
            this.chcbOtkazana.TabIndex = 30;
            this.chcbOtkazana.UseVisualStyleBackColor = true;
            this.chcbOtkazana.CheckedChanged += new System.EventHandler(this.chcbOtkazana_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(302, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Otkazana";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnNoveRezervacije
            // 
            this.btnNoveRezervacije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNoveRezervacije.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNoveRezervacije.Location = new System.Drawing.Point(630, 84);
            this.btnNoveRezervacije.Name = "btnNoveRezervacije";
            this.btnNoveRezervacije.Size = new System.Drawing.Size(119, 37);
            this.btnNoveRezervacije.TabIndex = 28;
            this.btnNoveRezervacije.Text = "Dodaj rezervaciju";
            this.btnNoveRezervacije.UseVisualStyleBackColor = false;
            this.btnNoveRezervacije.Click += new System.EventHandler(this.btnNoveRezervacije_Click);
            // 
            // btnTrazi
            // 
            this.btnTrazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTrazi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTrazi.Location = new System.Drawing.Point(437, 84);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(89, 37);
            this.btnTrazi.TabIndex = 27;
            this.btnTrazi.Text = "Trazi";
            this.btnTrazi.UseVisualStyleBackColor = false;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // Od
            // 
            this.Od.AutoSize = true;
            this.Od.BackColor = System.Drawing.SystemColors.Control;
            this.Od.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Od.Location = new System.Drawing.Point(52, 2);
            this.Od.Name = "Od";
            this.Od.Size = new System.Drawing.Size(92, 13);
            this.Od.TabIndex = 26;
            this.Od.Text = "Datum rezervacije";
            this.Od.Click += new System.EventHandler(this.Od_Click);
            // 
            // dtpDatumRezervacije
            // 
            this.dtpDatumRezervacije.Location = new System.Drawing.Point(55, 23);
            this.dtpDatumRezervacije.Name = "dtpDatumRezervacije";
            this.dtpDatumRezervacije.Size = new System.Drawing.Size(231, 20);
            this.dtpDatumRezervacije.TabIndex = 25;
            this.dtpDatumRezervacije.ValueChanged += new System.EventHandler(this.dtpDatumRezervacije_ValueChanged);
            // 
            // Rezervacije
            // 
            this.Rezervacije.Controls.Add(this.dgvRezervacije);
            this.Rezervacije.Location = new System.Drawing.Point(35, 186);
            this.Rezervacije.Name = "Rezervacije";
            this.Rezervacije.Size = new System.Drawing.Size(731, 262);
            this.Rezervacije.TabIndex = 24;
            this.Rezervacije.TabStop = false;
            this.Rezervacije.Text = "Rezervacije";
            // 
            // dgvRezervacije
            // 
            this.dgvRezervacije.AllowUserToAddRows = false;
            this.dgvRezervacije.AllowUserToDeleteRows = false;
            this.dgvRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervacije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Cijena,
            this.DatumRezervacije,
            this.Otkazana});
            this.dgvRezervacije.Location = new System.Drawing.Point(0, 25);
            this.dgvRezervacije.Name = "dgvRezervacije";
            this.dgvRezervacije.ReadOnly = true;
            this.dgvRezervacije.RowHeadersWidth = 51;
            this.dgvRezervacije.RowTemplate.Height = 24;
            this.dgvRezervacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervacije.Size = new System.Drawing.Size(731, 291);
            this.dgvRezervacije.TabIndex = 0;
            this.dgvRezervacije.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRezervacije_MouseDoubleClick);
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
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // DatumRezervacije
            // 
            this.DatumRezervacije.DataPropertyName = "DatumRezervacije";
            this.DatumRezervacije.HeaderText = "DatumRezervacije";
            this.DatumRezervacije.MinimumWidth = 6;
            this.DatumRezervacije.Name = "DatumRezervacije";
            this.DatumRezervacije.ReadOnly = true;
            this.DatumRezervacije.Width = 125;
            // 
            // Otkazana
            // 
            this.Otkazana.DataPropertyName = "Otkazana";
            this.Otkazana.HeaderText = "Otkazana";
            this.Otkazana.MinimumWidth = 6;
            this.Otkazana.Name = "Otkazana";
            this.Otkazana.ReadOnly = true;
            this.Otkazana.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(52, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Hotel";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbHotel
            // 
            this.cmbHotel.FormattingEnabled = true;
            this.cmbHotel.Location = new System.Drawing.Point(55, 123);
            this.cmbHotel.Name = "cmbHotel";
            this.cmbHotel.Size = new System.Drawing.Size(231, 21);
            this.cmbHotel.TabIndex = 33;
            this.cmbHotel.SelectedIndexChanged += new System.EventHandler(this.cmbHotel_SelectedIndexChanged);
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(353, 43);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(137, 20);
            this.txtCijena.TabIndex = 35;
            this.txtCijena.TextChanged += new System.EventHandler(this.txtCijena_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(350, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Cijena";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbHotel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKorisnik);
            this.Controls.Add(this.chcbOtkazana);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNoveRezervacije);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.Od);
            this.Controls.Add(this.dtpDatumRezervacije);
            this.Controls.Add(this.Rezervacije);
            this.Name = "frmRezervacije";
            this.Text = "frmRezervacije";
            this.Load += new System.EventHandler(this.frmRezervacije_Load);
            this.Rezervacije.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKorisnik;
        private System.Windows.Forms.CheckBox chcbOtkazana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNoveRezervacije;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.Label Od;
        private System.Windows.Forms.DateTimePicker dtpDatumRezervacije;
        private System.Windows.Forms.GroupBox Rezervacije;
        private System.Windows.Forms.DataGridView dgvRezervacije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHotel;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumRezervacije;
        private System.Windows.Forms.DataGridViewTextBoxColumn Otkazana;
    }
}