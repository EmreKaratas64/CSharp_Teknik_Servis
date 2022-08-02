using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace TeknikServis.ILETISIM
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Vazgeçmek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(onay == DialogResult.Yes)
            {
                this.Close();
            }
        }
        // t5K7*rs.

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtGonderen.Text != "" && TxtSifre.Text != "" && TxtAlici.Text != "" &&
                    TxtKonu.Text != "" && RchIcerik.Text != "")
                {
                    string gonderen, sifre, alici, konu, icerik;
                    gonderen = TxtGonderen.Text;
                    sifre = TxtSifre.Text;
                    alici = TxtAlici.Text;
                    konu = TxtKonu.Text;
                    icerik = RchIcerik.Text;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(gonderen);
                    mail.To.Add(alici);
                    mail.Subject = konu;
                    mail.Body = icerik;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential(gonderen, sifre);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    MessageBox.Show("Mail başarıyla gönderildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mail gönderilemedi, lütfen boş alan bırakmadan tekrar deneyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureShowPassword_MouseHover(object sender, EventArgs e)
        {
            TxtSifre.Properties.UseSystemPasswordChar = false;
        }

        private void PictureShowPassword_MouseLeave(object sender, EventArgs e)
        {
            TxtSifre.Properties.UseSystemPasswordChar = true;
        }

        private void BtnGonder_MouseHover(object sender, EventArgs e)
        {
            BtnGonder.BackColor = System.Drawing.Color.FromArgb(25, 118, 216);
            BtnGonder.ForeColor = Color.White;
        }

        private void BtnGonder_MouseLeave(object sender, EventArgs e)
        {
            BtnGonder.BackColor = Color.White;
            BtnGonder.ForeColor = System.Drawing.Color.FromArgb(25, 118, 216);
        }

        private void BtnVazgec_MouseHover(object sender, EventArgs e)
        {
            BtnVazgec.BackColor = System.Drawing.Color.FromArgb(25, 118, 216);
            BtnVazgec.ForeColor = Color.White;
        }

        private void BtnVazgec_MouseLeave(object sender, EventArgs e)
        {
            BtnVazgec.BackColor = Color.White;
            BtnVazgec.ForeColor = System.Drawing.Color.FromArgb(25, 118, 216);
        }
    }
}
