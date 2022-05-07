
namespace eTuristickaAgencija.WinUI.Agencija
{
    partial class frmAgencija
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.Rezervacije = new System.Windows.Forms.GroupBox();
            this.dgvAgencija = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rezervacije.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgencija)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(48, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Adresa";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(51, 36);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(191, 20);
            this.txtAdresa.TabIndex = 48;
            // 
            // btnTrazi
            // 
            this.btnTrazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTrazi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTrazi.Location = new System.Drawing.Point(271, 27);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(89, 37);
            this.btnTrazi.TabIndex = 40;
            this.btnTrazi.Text = "Trazi";
            this.btnTrazi.UseVisualStyleBackColor = false;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // Rezervacije
            // 
            this.Rezervacije.Controls.Add(this.dgvAgencija);
            this.Rezervacije.Location = new System.Drawing.Point(12, 107);
            this.Rezervacije.Name = "Rezervacije";
            this.Rezervacije.Size = new System.Drawing.Size(731, 262);
            this.Rezervacije.TabIndex = 37;
            this.Rezervacije.TabStop = false;
            this.Rezervacije.Text = "Agencija";
            // 
            // dgvAgencija
            // 
            this.dgvAgencija.AllowUserToAddRows = false;
            this.dgvAgencija.AllowUserToDeleteRows = false;
            this.dgvAgencija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgencija.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Adresa,
            this.Email,
            this.Telefon});
            this.dgvAgencija.Location = new System.Drawing.Point(0, 25);
            this.dgvAgencija.Name = "dgvAgencija";
            this.dgvAgencija.ReadOnly = true;
            this.dgvAgencija.RowHeadersWidth = 51;
            this.dgvAgencija.RowTemplate.Height = 24;
            this.dgvAgencija.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgencija.Size = new System.Drawing.Size(731, 291);
            this.dgvAgencija.TabIndex = 0;
            this.dgvAgencija.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAgencija_MouseDoubleClick);
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
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 125;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.MinimumWidth = 6;
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            this.Telefon.Width = 125;
            // 
            // frmAgencija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.Rezervacije);
            this.Name = "frmAgencija";
            this.Text = "frmAgencija";
            this.Rezervacije.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgencija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Button btnTrazi;
        private System.Windows.Forms.GroupBox Rezervacije;
        private System.Windows.Forms.DataGridView dgvAgencija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
    }
}