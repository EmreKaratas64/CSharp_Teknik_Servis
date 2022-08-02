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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            var degerler = from u in db.TBLCARI
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.TELEFON,
                               u.MAIL,
                               u.IL,
                               u.ILCE,
                               u.BANKA,
                               u.VERGIDAIRESI,
                               u.VERGINO,
                               u.STATUS,
                               u.ADRES
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        void temizle()
        {
            TxtCariAd.Text = "";
            TxtCariSoyad.Text = "";
            TxtID.Text = "";
            MskTelefon.Text = "";
            TxtMail.Text = "";
            TxtBanka.Text = "";
            //lookUpEditIL.EditValue = null;
            lookUpEditIlce.EditValue = null;
            TxtVergiNo.Text = "";
            TxtV_Dairesi.Text = "";
            memoEditAdres.Text = "";
            TxtStatus.Text = "";
            TxtCariAd.Focus();
        }


        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            listele();
            LblToplamCari.Text = db.TBLCARI.Count().ToString();
            LblAktifCari.Text = db.TBLCARI.Count(x => x.STATUS.ToUpper() == "AKTİF").ToString();
            LblToplamIL.Text = (from x in db.TBLCARI select x.IL).Distinct().Count().ToString();
            //(from x in db.TBLCARI select x.ILCE).Distinct().Count().ToString(); // toplam ilçe sayısı
            LblEnFazlaCariliIL.Text = db.enfazlacarili_il().FirstOrDefault();


            lookUpEditIL.Properties.DataSource = (from x in db.TBLILLER
                                                  select new
                                                  {
                                                      x.id,
                                                      x.sehir
                                                  }).ToList();

            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtCariAd.Text.Length <= 30 && TxtCariSoyad.Text.Length <= 30 && MskTelefon.Text.Length <= 20 && TxtMail.Text.Length <= 50 && TxtBanka.Text.Length <= 50 && TxtV_Dairesi.Text.Length <= 50 && TxtVergiNo.Text.Length <= 50 && TxtStatus.Text.Length <= 50 && memoEditAdres.Text.Length <= 250)
                {
                    TBLCARI tb = new TBLCARI();
                    tb.AD = TxtCariAd.Text;
                    tb.SOYAD = TxtCariSoyad.Text;
                    tb.TELEFON = MskTelefon.Text;
                    tb.MAIL = TxtMail.Text;
                    tb.IL = lookUpEditIL.Text;
                    tb.ILCE = lookUpEditIlce.Text;
                    tb.BANKA = TxtBanka.Text;
                    tb.VERGIDAIRESI = TxtV_Dairesi.Text;
                    tb.VERGINO = TxtVergiNo.Text;
                    tb.STATUS = TxtStatus.Text.ToUpper();
                    tb.ADRES = memoEditAdres.Text;
                    db.TBLCARI.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Cari kaydı başarıyla yapıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Cari kaydı yapılamadı lütfen girdiğiniz değerleri kontrol ediniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {

                TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtCariAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                TxtCariSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
                MskTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
                TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
                lookUpEditIL.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
                lookUpEditIlce.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
                TxtBanka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
                TxtV_Dairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRESI").ToString();
                TxtVergiNo.Text = gridView1.GetFocusedRowCellValue("VERGINO").ToString();
                TxtStatus.Text = gridView1.GetFocusedRowCellValue("STATUS").ToString();
                memoEditAdres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Boş değer");
            }
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = TxtCariAd.Text;
            deger.SOYAD = TxtCariSoyad.Text;
            deger.TELEFON = MskTelefon.Text;
            deger.MAIL = TxtMail.Text;
            deger.IL = lookUpEditIL.Text;
            deger.ILCE = lookUpEditIlce.Text;
            deger.BANKA = TxtBanka.Text;
            deger.VERGIDAIRESI = TxtV_Dairesi.Text;
            deger.VERGINO = TxtVergiNo.Text;
            deger.STATUS = TxtStatus.Text.ToUpper();
            deger.ADRES = memoEditAdres.Text;
            db.SaveChanges();
            MessageBox.Show("Cari kaydı başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
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
