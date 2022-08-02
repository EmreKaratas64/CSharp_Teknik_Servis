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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void temizle()
        {
            TxtMusteriID.Text = "";
            TxtPersonel.Text = "";
            TxtEditTarih.Text = "";
            TextEditSeriNo.Text = "";
            TxtMusteriID.Focus();
        }


        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnTemizle_MouseHover(object sender, EventArgs e)
        {
            BtnTemizle.BackColor = Color.White;
            BtnTemizle.ForeColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        private void BtnTemizle_MouseLeave(object sender, EventArgs e)
        {
            BtnTemizle.BackColor = Color.Transparent;
            BtnTemizle.ForeColor = Color.White;
        }

        private void BtnKaydet_MouseHover(object sender, EventArgs e)
        {
            BtnKaydet.BackColor = Color.White;
            BtnKaydet.ForeColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        private void BtnKaydet_MouseLeave(object sender, EventArgs e)
        {
            BtnKaydet.BackColor = Color.Transparent;
            BtnKaydet.ForeColor = Color.White;
        }

        private void BtnMusteriGetir_MouseHover(object sender, EventArgs e)
        {
            BtnMusteriGetir.BackColor = Color.White;
            BtnMusteriGetir.ForeColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        private void BtnMusteriGetir_MouseLeave(object sender, EventArgs e)
        {
            BtnMusteriGetir.BackColor = Color.Transparent;
            BtnMusteriGetir.ForeColor = Color.White;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void pictureClose_MouseHover(object sender, EventArgs e)
        {
            pictureClose.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
        }

        private void pictureClose_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.BackColor = Color.Transparent;
        }

        private void BtnMusteriGetir_Click(object sender, EventArgs e)
        {

            //string id = db.TBLURUNHAREKET.FirstOrDefault(x => x.URUNSERINO == TextEditSeriNo.Text).MUSTERI.ToString();
            //TxtMusteriID.Text = id;
            //TxtMusteriID.EditValue = Convert.ToInt32(id);

            var verigetir = db.TBLURUNHAREKET.SingleOrDefault(x => x.URUNSERINO == TextEditSeriNo.Text);

            if (verigetir != null)

            {

                TxtMusteriID.Text = verigetir.TBLCARI.ID.ToString();

                TxtPersonel.Text = verigetir.TBLPERSONEL.ID.ToString();

            }

            else
            {
                MessageBox.Show("Ürün seri no alanı boş olamaz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(TxtPersonel.Text.Length < 4 && TxtMusteriID.Text.Length < 4
                    && TxtPersonel.Text != "" && TxtMusteriID.Text != "" && TextEditSeriNo.Text != "")
                {
                    TBLURUNKABUL t = new TBLURUNKABUL();
                    t.CARI = int.Parse(TxtMusteriID.Text);
                    t.PERSONEL = short.Parse(TxtPersonel.Text);
                    t.GELISTARIH = DateTime.Parse(TxtEditTarih.Text);
                    t.URUNSERINO = TextEditSeriNo.Text;
                    t.URUNDURUMDETAY = "Ürün Kaydoldu";
                    db.TBLURUNKABUL.Add(t);
                    db.SaveChanges();
                    MessageBox.Show("Ürün arıza kaydı sisteme başarılı bir şekilde kaydedilmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Geçersiz değer girişi lütfen değerleri kontrol edin !", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                  
            }

            catch (Exception e1)
            {
                  MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void TxtEditTarih_Click(object sender, EventArgs e)
        {
            TxtEditTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
