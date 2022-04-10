namespace eTuristickaAgencija.WinUI.Termini
{
    partial class frmTerminiDetalji
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
            this.components = new System.ComponentModel.Container();
            this.pickerOd = new System.Windows.Forms.DateTimePicker();
            this.pickerDo = new System.Windows.Forms.DateTimePicker();
            this.chcboxAktivan = new System.Windows.Forms.CheckBox();
            this.cmbHotel = new System.Windows.Forms.ComboBox();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.txtAkcijskaCijena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.txtPopust = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnKarte = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pickerOd
            // 
            this.pickerOd.Location = new System.Drawing.Point(29, 31);
            this.pickerOd.Name = "pickerOd";
            this.pickerOd.Size = new System.Drawing.Size(224, 22);
            this.pickerOd.TabIndex = 1;
            // 
            // pickerDo
            // 
            this.pickerDo.Location = new System.Drawing.Point(29, 102);
            this.pickerDo.Name = "pickerDo";
            this.pickerDo.Size = new System.Drawing.Size(224, 22);
            this.pickerDo.TabIndex = 2;
            this.pickerDo.Validating += new System.ComponentModel.CancelEventHandler(this.pickerDo_Validating);
            // 
            // chcboxAktivan
            // 
            this.chcboxAktivan.AutoSize = true;
            this.chcboxAktivan.Location = new System.Drawing.Point(29, 169);
            this.chcboxAktivan.Name = "chcboxAktivan";
            this.chcboxAktivan.Size = new System.Drawing.Size(15, 14);
            this.chcboxAktivan.TabIndex = 3;
            this.chcboxAktivan.UseVisualStyleBackColor = true;
            // 
            // cmbHotel
            // 
            this.cmbHotel.FormattingEnabled = true;
            this.cmbHotel.Location = new System.Drawing.Point(28, 219);
            this.cmbHotel.Name = "cmbHotel";
            this.cmbHotel.Size = new System.Drawing.Size(226, 24);
            this.cmbHotel.TabIndex = 4;
            this.cmbHotel.SelectedIndexChanged += new System.EventHandler(this.cmbHotel_SelectedIndexChanged);
            this.cmbHotel.Validating += new System.ComponentModel.CancelEventHandler(this.cmbHotel_Validating);
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(27, 282);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(226, 22);
            this.txtCijena.TabIndex = 5;
            this.txtCijena.MouseLeave += new System.EventHandler(this.txtCijena_MouseLeave);
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // txtAkcijskaCijena
            // 
            this.txtAkcijskaCijena.Location = new System.Drawing.Point(31, 398);
            this.txtAkcijskaCijena.Name = "txtAkcijskaCijena";
            this.txtAkcijskaCijena.ReadOnly = true;
            this.txtAkcijskaCijena.Size = new System.Drawing.Size(226, 22);
            this.txtAkcijskaCijena.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(29, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pocetak";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(25, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kraj";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(25, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Aktivan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(28, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hotel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(28, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cijena";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(27, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Popust(u %)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(27, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Akcijska cijena";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSacuvaj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSacuvaj.Location = new System.Drawing.Point(123, 467);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(116, 26);
            this.btnSacuvaj.TabIndex = 15;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // txtPopust
            // 
            this.txtPopust.Location = new System.Drawing.Point(27, 340);
            this.txtPopust.Name = "txtPopust";
            this.txtPopust.Size = new System.Drawing.Size(226, 22);
            this.txtPopust.TabIndex = 16;
            this.txtPopust.MouseLeave += new System.EventHandler(this.txtPopust_MouseLeave);
            this.txtPopust.Validating += new System.ComponentModel.CancelEventHandler(this.txtPopust_Validating);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCijena);
            this.panel1.Controls.Add(this.pickerOd);
            this.panel1.Controls.Add(this.pickerDo);
            this.panel1.Controls.Add(this.chcboxAktivan);
            this.panel1.Controls.Add(this.txtPopust);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbHotel);
            this.panel1.Controls.Add(this.txtAkcijskaCijena);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(222, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 438);
            this.panel1.TabIndex = 28;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrint.Location = new System.Drawing.Point(599, 406);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 26);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnObrisi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnObrisi.Location = new System.Drawing.Point(599, 467);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(84, 26);
            this.btnObrisi.TabIndex = 29;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnKarte
            // 
            this.btnKarte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnKarte.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKarte.Location = new System.Drawing.Point(311, 467);
            this.btnKarte.Name = "btnKarte";
            this.btnKarte.Size = new System.Drawing.Size(213, 26);
            this.btnKarte.TabIndex = 30;
            this.btnKarte.Text = "Pregled karata za termin";
            this.btnKarte.UseVisualStyleBackColor = false;
            this.btnKarte.Click += new System.EventHandler(this.btnKarte_Click);
            // 
            // frmTerminiDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.btnKarte);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSacuvaj);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "frmTerminiDetalji";
            this.Text = "frmTerminiDetalji";
            this.Load += new System.EventHandler(this.frmTerminiDetalji_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker pickerOd;
        private System.Windows.Forms.DateTimePicker pickerDo;
        private System.Windows.Forms.CheckBox chcboxAktivan;
        private System.Windows.Forms.ComboBox cmbHotel;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.TextBox txtAkcijskaCijena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.TextBox txtPopust;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnKarte;
    }
}