using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void PictureShowPassword_MouseHover(object sender, EventArgs e)
        {
            TxtSifre.Properties.UseSystemPasswordChar = false;
        }

        private void PictureShowPassword_MouseLeave(object sender, EventArgs e)
        {
            TxtSifre.Properties.UseSystemPasswordChar = true;
        }

        private void PictueClose_MouseHover(object sender, EventArgs e)
        {
            PictueClose.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private void PictueClose_MouseLeave(object sender, EventArgs e)
        {
            PictueClose.BackColor = Color.White;
        }

        private void PictueClose_Click(object sender, EventArgs e)
        {
            DialogResult onay = XtraMessageBox.Show("Programdan çıkmak istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(onay == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void BtnGirisYap_MouseHover(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = System.Drawing.Color.FromArgb(25, 118, 216);
            BtnGirisYap.ForeColor = Color.White;
        }

        private void BtnGirisYap_MouseLeave(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.White;
            BtnGirisYap.ForeColor = System.Drawing.Color.FromArgb(25, 118, 216);
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.TBLADMIN
                        where x.KULLANICIAD == TxtKullanıcıad.Text &
                        x.SIFRE == TxtSifre.Text
                        select x;

            if (sorgu.Any())
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Geçersiz kullanıcı adı veya şifre !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LnkSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formlar.FrmSifremiUnuttum fr = new Formlar.FrmSifremiUnuttum();
            fr.Show();
        }
    }
}
