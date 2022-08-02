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
    public partial class FrmArızaDetay : Form
    {
        public FrmArızaDetay()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void pictureClose_MouseHover(object sender, EventArgs e)
        {
            pictureClose.BackColor = System.Drawing.Color.FromArgb(52, 125, 206);
        }

        private void pictureClose_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.BackColor = Color.Transparent;
        }
        public string seri_no,id;
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if(TextEditSeriNo.Text != "" && TxtEditTarih.Text != "" && CmbUrunDurumDetay.Text != "Ürün Durumu" &&
                    RchAciklama.Text != "")
                {
                    TBLURUNTAKIP t = new TBLURUNTAKIP();
                    t.ACIKLAMA = RchAciklama.Text;
                    t.TARIH = DateTime.Parse(TxtEditTarih.Text);
                    t.SERINO = TextEditSeriNo.Text;
                    db.TBLURUNTAKIP.Add(t);

                    //Ürün durum detay güncellemesi
                    TBLURUNKABUL tb = new TBLURUNKABUL();
                    int islem_id = int.Parse(id);
                    var deger = db.TBLURUNKABUL.Find(islem_id);
                    deger.URUNDURUMDETAY = CmbUrunDurumDetay.Text;
                    db.SaveChanges();
                    MessageBox.Show("Ürün arıza detayları başarılı bir şekilde güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Geçersiz değer girişi, lütfen boş değer girmeyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmArızaDetay_Load(object sender, EventArgs e)
        {
            if(seri_no != null)
            {
                TextEditSeriNo.Text = seri_no.ToString();
            }
        }
    }
}
