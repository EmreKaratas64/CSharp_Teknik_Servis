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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        public void listele()
        {
            // Listeleme
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               u.ALISFIYAT,
                               u.SATISFIYAT,
                               u.STOK,
                               KATEGORI = u.TBLKATEGORI.AD,
                               u.DURUM
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        public void temizle()
        {
            TxtID.Text = "";
            TxtUrunAd.Text = "";
            TxtMarka.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            TxtStok.Text = "";
            LookUpKategori.EditValue = null;
            TxtUrunAd.Focus();
        }

        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            listele();
            LookUpKategori.Properties.DataSource = (from x in db.TBLKATEGORI
                                                    select new
                                                    {
                                                        x.ID,
                                                        x.AD
                                                    }).ToList();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                if (TxtUrunAd.Text != "" && TxtUrunAd.Text.Length <= 30 && TxtMarka.Text != "" && TxtMarka.Text.Length <= 30 &&
                TxtAlisFiyat.Text != "" && TxtSatisFiyat.Text != "" && TxtStok.Text != "" && 
                LookUpKategori.Text != "Kategori Seçin")
                {
                    TBLURUN tb = new TBLURUN();
                    tb.AD = TxtUrunAd.Text;
                    tb.MARKA = TxtMarka.Text;
                    tb.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
                    tb.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
                    tb.STOK = short.Parse(TxtStok.Text);
                    tb.KATEGORI = byte.Parse(LookUpKategori.EditValue.ToString());
                    tb.DURUM = false;
                    db.TBLURUN.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Ürün başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ürün adı ve marka değerleri boş olamaz ve 30 karakterden az olmalıdır !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                TxtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
                TxtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
                TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                //LookUpKategori.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Boş değer !");
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtUrunAd.Text != "" && TxtMarka.Text != "" && TxtAlisFiyat.Text != "" && TxtSatisFiyat.Text != "" &&
               TxtStok.Text != "" && LookUpKategori.Text != "Kategori Seçin")
                {
                    int id = int.Parse(TxtID.Text);
                    var deger = db.TBLURUN.Find(id);
                    deger.AD = TxtUrunAd.Text;
                    deger.MARKA = TxtMarka.Text;
                    deger.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
                    deger.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
                    deger.STOK = short.Parse(TxtStok.Text);
                    deger.KATEGORI = byte.Parse(LookUpKategori.EditValue.ToString());
                    db.SaveChanges();
                    MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listele();
                }
                else
                {
                    MessageBox.Show("Geçersiz değer girişi, boş değer girilemez lütfen tekrar deneyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
