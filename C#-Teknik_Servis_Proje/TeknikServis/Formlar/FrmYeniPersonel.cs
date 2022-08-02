using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void departman_getir()
        {
            lookUpEditDepartman.Properties.DataSource = (from p in db.TBLDEPARTMAN
                                                         select new
                                                         {
                                                             p.ID,
                                                             p.AD
                                                         }).ToList();
        }


        void temizle()
        {
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            lookUpEditDepartman.EditValue = null;
            TxtMail.Text = "";
            TextEditTelefon.Text = "";
            TxtFoto.Text = "";
            TxtAd.Focus();

        }

        private void pictureClose_MouseHover(object sender, EventArgs e)
        {
            pictureClose.BackColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        private void pictureClose_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.BackColor = System.Drawing.Color.FromArgb(1, 80, 165);
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnKaydet_MouseHover(object sender, EventArgs e)
        {
            BtnKaydet.BackColor = Color.White;
            BtnKaydet.ForeColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        private void BtnKaydet_MouseLeave(object sender, EventArgs e)
        {
            BtnKaydet.BackColor = System.Drawing.Color.FromArgb(34, 36, 49);
            BtnKaydet.ForeColor = Color.White;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAd.Text.Length <= 30 && TxtSoyad.Text.Length <= 30 && TxtFoto.Text.Length <= 100 && TxtMail.Text.Length <= 50 && TextEditTelefon.Text.Length <= 20
                   && TxtAd.Text != "" && TxtSoyad.Text != "" && TxtFoto.Text != "" && TxtMail.Text != "" &&
                   TextEditTelefon.Text != "" && lookUpEditDepartman.EditValue != null)
                { 
                    TBLPERSONEL pr = new TBLPERSONEL();
                    pr.AD = TxtAd.Text;
                    pr.SOYAD = TxtSoyad.Text;
                    pr.DEPARTMAN = byte.Parse(lookUpEditDepartman.EditValue.ToString());
                    pr.FOTOGRAF = TxtFoto.Text;
                    pr.MAIL = TxtMail.Text;
                    pr.TELEFON = TextEditTelefon.Text;
                    db.TBLPERSONEL.Add(pr);
                    db.SaveChanges();
                    MessageBox.Show("Personel kaydı başarıyla gerçekleştirildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel kaydı yapılamadı lütfen girdiğiniz değerleri kontrol ediniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void FrmYeniPersonel_Load(object sender, EventArgs e)
        {
            departman_getir();
        }

        private void BtnTemizle_MouseHover(object sender, EventArgs e)
        {
            BtnTemizle.BackColor = Color.White;
            BtnTemizle.ForeColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        private void BtnTemizle_MouseLeave(object sender, EventArgs e)
        {
            BtnTemizle.BackColor = System.Drawing.Color.FromArgb(34, 36, 49);
            BtnTemizle.ForeColor = Color.White;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
