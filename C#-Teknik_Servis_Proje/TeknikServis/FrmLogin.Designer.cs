
namespace TeknikServis
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.LnkSifremiUnuttum = new System.Windows.Forms.LinkLabel();
            this.BtnGirisYap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtKullanıcıad = new DevExpress.XtraEditors.TextEdit();
            this.TxtSifre = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.PictureShowPassword = new System.Windows.Forms.PictureBox();
            this.PictueClose = new TeknikServis.circularpicturebox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullanıcıad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictueClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.label1.Location = new System.Drawing.Point(239, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // LnkSifremiUnuttum
            // 
            this.LnkSifremiUnuttum.ActiveLinkColor = System.Drawing.Color.Red;
            this.LnkSifremiUnuttum.AutoSize = true;
            this.LnkSifremiUnuttum.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LnkSifremiUnuttum.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.LnkSifremiUnuttum.Location = new System.Drawing.Point(432, 301);
            this.LnkSifremiUnuttum.Name = "LnkSifremiUnuttum";
            this.LnkSifremiUnuttum.Size = new System.Drawing.Size(133, 21);
            this.LnkSifremiUnuttum.TabIndex = 34;
            this.LnkSifremiUnuttum.TabStop = true;
            this.LnkSifremiUnuttum.Text = "Şifremi Unuttum";
            this.LnkSifremiUnuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSifremiUnuttum_LinkClicked);
            // 
            // BtnGirisYap
            // 
            this.BtnGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGirisYap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.BtnGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGirisYap.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGirisYap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.BtnGirisYap.Location = new System.Drawing.Point(243, 345);
            this.BtnGirisYap.Name = "BtnGirisYap";
            this.BtnGirisYap.Size = new System.Drawing.Size(136, 37);
            this.BtnGirisYap.TabIndex = 3;
            this.BtnGirisYap.Text = "Giriş Yap";
            this.BtnGirisYap.UseVisualStyleBackColor = true;
            this.BtnGirisYap.Click += new System.EventHandler(this.BtnGirisYap_Click);
            this.BtnGirisYap.MouseLeave += new System.EventHandler(this.BtnGirisYap_MouseLeave);
            this.BtnGirisYap.MouseHover += new System.EventHandler(this.BtnGirisYap_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 544);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(44, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Giriş Paneli";
            // 
            // TxtKullanıcıad
            // 
            this.TxtKullanıcıad.EditValue = "";
            this.TxtKullanıcıad.Location = new System.Drawing.Point(243, 150);
            this.TxtKullanıcıad.Name = "TxtKullanıcıad";
            this.TxtKullanıcıad.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtKullanıcıad.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.TxtKullanıcıad.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtKullanıcıad.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.TxtKullanıcıad.Properties.Appearance.Options.UseBackColor = true;
            this.TxtKullanıcıad.Properties.Appearance.Options.UseBorderColor = true;
            this.TxtKullanıcıad.Properties.Appearance.Options.UseFont = true;
            this.TxtKullanıcıad.Properties.Appearance.Options.UseForeColor = true;
            this.TxtKullanıcıad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.TxtKullanıcıad.Size = new System.Drawing.Size(322, 28);
            this.TxtKullanıcıad.TabIndex = 1;
            // 
            // TxtSifre
            // 
            this.TxtSifre.EditValue = "";
            this.TxtSifre.Location = new System.Drawing.Point(243, 238);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtSifre.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.TxtSifre.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSifre.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.TxtSifre.Properties.Appearance.Options.UseBackColor = true;
            this.TxtSifre.Properties.Appearance.Options.UseBorderColor = true;
            this.TxtSifre.Properties.Appearance.Options.UseFont = true;
            this.TxtSifre.Properties.Appearance.Options.UseForeColor = true;
            this.TxtSifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.TxtSifre.Properties.UseSystemPasswordChar = true;
            this.TxtSifre.Size = new System.Drawing.Size(322, 28);
            this.TxtSifre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(216)))));
            this.label2.Location = new System.Drawing.Point(239, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 104;
            this.label2.Text = "Şifre";
            // 
            // PictureShowPassword
            // 
            this.PictureShowPassword.BackColor = System.Drawing.Color.White;
            this.PictureShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureShowPassword.Image = ((System.Drawing.Image)(resources.GetObject("PictureShowPassword.Image")));
            this.PictureShowPassword.Location = new System.Drawing.Point(571, 235);
            this.PictureShowPassword.Name = "PictureShowPassword";
            this.PictureShowPassword.Size = new System.Drawing.Size(33, 31);
            this.PictureShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureShowPassword.TabIndex = 76;
            this.PictureShowPassword.TabStop = false;
            this.PictureShowPassword.MouseLeave += new System.EventHandler(this.PictureShowPassword_MouseLeave);
            this.PictureShowPassword.MouseHover += new System.EventHandler(this.PictureShowPassword_MouseHover);
            // 
            // PictueClose
            // 
            this.PictueClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictueClose.Image = ((System.Drawing.Image)(resources.GetObject("PictueClose.Image")));
            this.PictueClose.Location = new System.Drawing.Point(774, 0);
            this.PictueClose.Name = "PictueClose";
            this.PictueClose.Size = new System.Drawing.Size(60, 67);
            this.PictueClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictueClose.TabIndex = 7;
            this.PictueClose.TabStop = false;
            this.PictueClose.Click += new System.EventHandler(this.PictueClose_Click);
            this.PictueClose.MouseLeave += new System.EventHandler(this.PictueClose_MouseLeave);
            this.PictueClose.MouseHover += new System.EventHandler(this.PictueClose_MouseHover);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.BtnGirisYap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 544);
            this.Controls.Add(this.PictureShowPassword);
            this.Controls.Add(this.TxtSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtKullanıcıad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PictueClose);
            this.Controls.Add(this.BtnGirisYap);
            this.Controls.Add(this.LnkSifremiUnuttum);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullanıcıad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictueClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGirisYap;
        private circularpicturebox PictueClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel LnkSifremiUnuttum;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit TxtKullanıcıad;
        private DevExpress.XtraEditors.TextEdit TxtSifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PictureShowPassword;
    }
}