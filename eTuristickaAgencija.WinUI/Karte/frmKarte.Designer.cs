namespace eTuristickaAgencija.WinUI.Karte
{
    partial class frmKarte
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKarte = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumKreiranja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ponistena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chckPonistena = new System.Windows.Forms.CheckBox();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKarte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKarte);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 344);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Karte";
            // 
            // dgvKarte
            // 
            this.dgvKarte.AllowUserToAddRows = false;
            this.dgvKarte.AllowUserToDeleteRows = false;
            this.dgvKarte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKarte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.KorisnikId,
            this.DatumKreiranja,
            this.Ponistena});
            this.dgvKarte.Location = new System.Drawing.Point(0, 25);
            this.dgvKarte.Name = "dgvKarte";
            this.dgvKarte.ReadOnly = true;
            this.dgvKarte.RowHeadersWidth = 51;
            this.dgvKarte.RowTemplate.Height = 24;
            this.dgvKarte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKarte.Size = new System.Drawing.Size(900, 320);
            this.dgvKarte.TabIndex = 0;
            this.dgvKarte.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKarte_MouseDoubleClick);
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
            // KorisnikId
            // 
            this.KorisnikId.DataPropertyName = "KorisnikId";
            this.KorisnikId.HeaderText = "KorisnikId";
            this.KorisnikId.MinimumWidth = 6;
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            this.KorisnikId.Visible = false;
            this.KorisnikId.Width = 125;
            // 
            // DatumKreiranja
            // 
            this.DatumKreiranja.DataPropertyName = "DatumKreiranja";
            this.DatumKreiranja.HeaderText = "Datum kreiranja";
            this.DatumKreiranja.MinimumWidth = 6;
            this.DatumKreiranja.Name = "DatumKreiranja";
            this.DatumKreiranja.ReadOnly = true;
            this.DatumKreiranja.Width = 125;
            // 
            // Ponistena
            // 
            this.Ponistena.DataPropertyName = "Ponistena";
            this.Ponistena.HeaderText = "Ponistena";
            this.Ponistena.MinimumWidth = 6;
            this.Ponistena.Name = "Ponistena";
            this.Ponistena.ReadOnly = true;
            this.Ponistena.Width = 125;
            // 
            // chckPonistena
            // 
            this.chckPonistena.AutoSize = true;
            this.chckPonistena.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chckPonistena.Location = new System.Drawing.Point(95, 28);
            this.chckPonistena.Name = "chckPonistena";
            this.chckPonistena.Size = new System.Drawing.Size(85, 20);
            this.chckPonistena.TabIndex = 1;
            this.chckPonistena.Text = "Ponistena";
            this.chckPonistena.UseVisualStyleBackColor = true;
            // 
            // btnPretraga
            // 
            this.btnPretraga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPretraga.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPretraga.Location = new System.Drawing.Point(221, 28);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(93, 36);
            this.btnPretraga.TabIndex = 3;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = false;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmKarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(900, 506);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.chckPonistena);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmKarte";
            this.Text = "frmKarte";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKarte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKarte;
        private System.Windows.Forms.CheckBox chckPonistena;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumKreiranja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ponistena;
    }
}