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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void BrnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtAd.Text != "" && TxtAd.Text.Length < 30 && TxtSoyad.Text != "" && TxtSoyad.Text.Length < 30
                    && TxtStatus.Text != "" && TxtStatus.Text.Length == 5)
                {
                    TBLCARI tb = new TBLCARI();
                    tb.AD = TxtAd.Text;
                    tb.SOYAD = TxtSoyad.Text;
                    tb.TELEFON = TxtTelefon.Text;
                    tb.MAIL = TxtMail.Text;
                    tb.IL = lookUpEditIL.Text;
                    tb.ILCE = lookUpEditIlce.Text;
                    tb.BANKA = TxtBank.Text;
                    tb.VERGIDAIRESI = TxtVergiD.Text;
                    tb.VERGINO = TxtVergiN.Text;
                    tb.STATUS = TxtStatus.Text;
                    tb.ADRES = RchAdres.Text;
                    db.TBLCARI.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Cari kaydetme işlemi başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Geçersiz değer girişi, boş alan girmemeye ve karakter uzunluğuna dikkat ederek tekrar deneyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult onay = MessageBox.Show("Kaydetme işlemini iptal etmek istediğinizden emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (onay == DialogResult.Yes)
                {
                    this.Hide();
                    MessageBox.Show("Kaydetme işlemi iptal edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            lookUpEditIL.Properties.DataSource = (from x in db.TBLILLER
                                                  select new
                                                  {
                                                      x.id,
                                                      x.sehir
                                                  }).ToList();
        }
        int secilen;
        private void lookUpEditIL_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEditIL.EditValue.ToString());
            lookUpEditIlce.Properties.DataSource = (from x in db.TBLILCELER
                                                    select new
                                                    {
                                                        x.id,
                                                        x.ilce,
                                                        x.sehir
                                                    }).Where(y => y.sehir == secilen).ToList();
        }

       
    }
}
