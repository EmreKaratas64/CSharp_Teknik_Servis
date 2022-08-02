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

namespace TeknikServis.Formlar
{
    public partial class FrmSifremiUnuttum : Form
    {
        public FrmSifremiUnuttum()
        {
            InitializeComponent();
        }

        static Random r = new Random();
        static string kod = r.Next(100000, 999999).ToString();
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmSifremiUnuttum_Load(object sender, EventArgs e)
        {
        }

        private void circularpicturebox1_MouseHover(object sender, EventArgs e)
        {
            circularpicturebox1.BackColor = System.Drawing.Color.FromArgb(1, 80, 165);
        }

        private void circularpicturebox1_MouseLeave(object sender, EventArgs e)
        {
            circularpicturebox1.BackColor = System.Drawing.Color.FromArgb(25, 118, 216);
        }

        private void circularpicturebox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnKodGonder_Click(object sender, EventArgs e)
        {

            try
            {
                if (TxtMail.Text != "")
                {
                    string gonderen, sifre, alici, konu, icerik;
                    label7.Text = kod;
                    gonderen = "emrekaratas076@gmail.com";
                    sifre = "t5K7*rs.";
                    alici = TxtMail.Text;
                    konu = "Doğrulama";
                    icerik = "Doğrulama kodunuz " + kod + ".Lütfen kimseyle paylaşmayın !";
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
                    MessageBox.Show("Mail alanı boş olamaz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Mail gönderilemiyor", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BtnSifreDegistir_Click(object sender, EventArgs e)
        {
            if (TxtKod.Text != "" && TxtYeniSifre1.Text != "" && TxtYeniSifre1.Text == TxtYeniSifre2.Text && TxtKod.Text == label7.Text)
            {
                int id = int.Parse(TxtID.Text);
                var deger = db.TBLADMIN.Find(id);
                deger.SIFRE = TxtYeniSifre1.Text;
                db.SaveChanges();
                MessageBox.Show("Şifre başarıyla değiştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Doğrulama kodunu girdiğinizden veya Şifre alanlarının eşleştiğinden emin olup tekrar deneyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
