namespace eTuristickaAgencija.WinUI.Destinacije
{
    partial class frmDestinacije
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
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDestinacije = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pretraga = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPretraga = new System.Windows.Forms.Button();
            this.cmbKontinent = new System.Windows.Forms.ComboBox();
            this.cmbDrzava = new System.Windows.Forms.ComboBox();
            this.cmbGrad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNovi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinacije)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(142, 24);
            this.txtPretraga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(181, 20);
            this.txtPretraga.TabIndex = 0;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDestinacije);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(11, 184);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(563, 171);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destinacije";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvDestinacije
            // 
            this.dgvDestinacije.AllowUserToAddRows = false;
            this.dgvDestinacije.AllowUserToDeleteRows = false;
            this.dgvDestinacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDestinacije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv});
            this.dgvDestinacije.Location = new System.Drawing.Point(0, 17);
            this.dgvDestinacije.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDestinacije.Name = "dgvDestinacije";
            this.dgvDestinacije.ReadOnly = true;
            this.dgvDestinacije.RowHeadersWidth = 51;
            this.dgvDestinacije.RowTemplate.Height = 24;
            this.dgvDestinacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDestinacije.Size = new System.Drawing.Size(600, 180);
            this.dgvDestinacije.TabIndex = 0;
            this.dgvDestinacije.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDestinacije_MouseDoubleClick);
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
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 125;
            // 
            // Pretraga
            // 
            this.Pretraga.AutoSize = true;
            this.Pretraga.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Pretraga.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pretraga.Location = new System.Drawing.Point(140, 7);
            this.Pretraga.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Pretraga.Name = "Pretraga";
            this.Pretraga.Size = new System.Drawing.Size(40, 16);
            this.Pretraga.TabIndex = 2;
            this.Pretraga.Text = "Naziv";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnPretraga
            // 
            this.btnPretraga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPretraga.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPretraga.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPretraga.Location = new System.Drawing.Point(333, 143);
            this.btnPretraga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(71, 24);
            this.btnPretraga.TabIndex = 12;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = false;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            this.btnPretraga.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPretraga_MouseClick);
            // 
            // cmbKontinent
            // 
            this.cmbKontinent.FormattingEnabled = true;
            this.cmbKontinent.Location = new System.Drawing.Point(142, 65);
            this.cmbKontinent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbKontinent.Name = "cmbKontinent";
            this.cmbKontinent.Size = new System.Drawing.Size(181, 21);
            this.cmbKontinent.TabIndex = 13;
            this.cmbKontinent.SelectedIndexChanged += new System.EventHandler(this.cmbKontinent_SelectedIndexChanged);
            this.cmbKontinent.Validating += new System.ComponentModel.CancelEventHandler(this.cmbKontinent_Validating);
            // 
            // cmbDrzava
            // 
            this.cmbDrzava.FormattingEnabled = true;
            this.cmbDrzava.Location = new System.Drawing.Point(142, 110);
            this.cmbDrzava.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDrzava.Name = "cmbDrzava";
            this.cmbDrzava.Size = new System.Drawing.Size(181, 21);
            this.cmbDrzava.TabIndex = 14;
            this.cmbDrzava.SelectedIndexChanged += new System.EventHandler(this.cmbDrzava_SelectedIndexChanged);
            this.cmbDrzava.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDrzava_Validating);
            // 
            // cmbGrad
            // 
            this.cmbGrad.FormattingEnabled = true;
            this.cmbGrad.Location = new System.Drawing.Point(142, 148);
            this.cmbGrad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbGrad.Name = "cmbGrad";
            this.cmbGrad.Size = new System.Drawing.Size(181, 21);
            this.cmbGrad.TabIndex = 15;
            this.cmbGrad.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGrad_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(140, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Kontinent";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(140, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Drzava";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(140, 132);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Grad";
            // 
            // btnNovi
            // 
            this.btnNovi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNovi.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNovi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNovi.Location = new System.Drawing.Point(438, 143);
            this.btnNovi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNovi.Name = "btnNovi";
            this.btnNovi.Size = new System.Drawing.Size(80, 24);
            this.btnNovi.TabIndex = 21;
            this.btnNovi.Text = "Novi";
            this.btnNovi.UseVisualStyleBackColor = false;
            this.btnNovi.Click += new System.EventHandler(this.btnNovi_Click);
            // 
            // frmDestinacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnNovi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbGrad);
            this.Controls.Add(this.cmbDrzava);
            this.Controls.Add(this.cmbKontinent);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.Pretraga);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPretraga);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmDestinacije";
            this.Text = "frmDestinacije";
            this.Load += new System.EventHandler(this.frmDestinacije_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinacije)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDestinacije;
        private System.Windows.Forms.Label Pretraga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.ComboBox cmbGrad;
        private System.Windows.Forms.ComboBox cmbDrzava;
        private System.Windows.Forms.ComboBox cmbKontinent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNovi;
    }
}