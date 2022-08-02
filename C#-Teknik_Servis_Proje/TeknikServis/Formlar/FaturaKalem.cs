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
    public partial class FaturaKalem : Form
    {
        public FaturaKalem()
        {
            InitializeComponent();
        }

        void listele()
        {
            var degerler = (from x in db.TBLFATURADETAY
                            select new
                            {
                                x.FATURADETAYID,
                                x.URUN,
                                x.ADET,
                                x.FIYAT,
                                x.TUTAR,
                                x.FATURAID
                            });
            gridControl1.DataSource = degerler.ToList();
        }

        void temizle()
        {
            TxtFaturaDetayID.Text = "";
            TxtAdet.Text = "";
            TxtFiyat.Text = "";
            TxtTutar.Text = "";
            TxtFaturaID.Text = "";
            TxtUrun.Text = "";
            TxtUrun.Focus();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtUrun.Text != "" && TxtUrun.Text.Length <= 50 && TxtAdet.Text != "" && TxtFiyat.Text != "" &&
                    TxtTutar.Text != "" && TxtFaturaID.Text != "")
                {
                    TBLFATURADETAY tb = new TBLFATURADETAY();
                    tb.URUN = TxtUrun.Text;
                    tb.ADET = short.Parse(TxtAdet.Text);
                    tb.FIYAT = decimal.Parse(TxtFiyat.Text);
                    tb.TUTAR = decimal.Parse(TxtTutar.Text);
                    tb.FATURAID = int.Parse(TxtFaturaID.Text);
                    db.TBLFATURADETAY.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Fatura detayı başarılı bir şekilde sisteme kaydedilmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Geçersiz değer girişi, lütfen boş değer girmemeye ve karakter uzunluklarına dikkat ederek tekrar deneyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTutarHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                decimal birim_fiyat = decimal.Parse(TxtFiyat.Text);
                short adet = short.Parse(TxtAdet.Text);
                decimal tutar = birim_fiyat * adet;
                TxtTutar.Text = (birim_fiyat * adet).ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FaturaKalem_Load(object sender, EventArgs e)
        {
            listele();
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtFaturaDetayID.Text = gridView1.GetFocusedRowCellValue("FATURADETAYID").ToString();
                TxtUrun.Text = gridView1.GetFocusedRowCellValue("URUN").ToString();
                TxtAdet.Text = gridView1.GetFocusedRowCellValue("ADET").ToString();
                TxtFiyat.Text = gridView1.GetFocusedRowCellValue("FIYAT").ToString();
                TxtTutar.Text = gridView1.GetFocusedRowCellValue("TUTAR").ToString();
                TxtFaturaID.Text = gridView1.GetFocusedRowCellValue("FATURAID").ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Bu fatura bilgisini sistemden silmek istediğinize emin misiniz?","Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if(onay == DialogResult.Yes)
            {
                int id = int.Parse(TxtFaturaDetayID.Text);
                var deger = db.TBLFATURADETAY.Find(id);
                db.TBLFATURADETAY.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Fatura bilgileri sistemden silindi !", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
            else
            {
                MessageBox.Show("Fatura bilgileri silme işlemi başarıyla iptal edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtUrun.Text != "" && TxtUrun.Text.Length <= 50 && TxtAdet.Text != "" && TxtFiyat.Text != "" &&
                    TxtTutar.Text != "" && TxtFaturaID.Text != "")
                {
                    int id = int.Parse(TxtFaturaDetayID.Text);
                    var degerler = db.TBLFATURADETAY.Find(id);
                    degerler.URUN = TxtUrun.Text;
                    degerler.ADET = short.Parse(TxtAdet.Text);
                    degerler.FIYAT = decimal.Parse(TxtFiyat.Text);
                    degerler.TUTAR = decimal.Parse(TxtTutar.Text);
                    degerler.FATURAID = int.Parse(TxtFaturaID.Text);
                    db.SaveChanges();
                    MessageBox.Show("Fatura bilgileri başarıyla güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Geçersiz değer girişi, lütfen boş değer girmemeye ve karakter uzunluklarına dikkat ederek tekrar deneyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
