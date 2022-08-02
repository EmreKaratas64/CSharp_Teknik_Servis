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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void listele()
        {
            var degerler = (from x in db.TBLFATURABILGI
                            select new
                            {
                                x.ID,
                                x.SERI,
                                x.SIRANO,
                                x.TARIH,
                                x.SAAT,
                                x.VERGIDAIRE,
                                MUSTERI = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD
                            });
            gridControl1.DataSource = degerler.ToList();
        }

        void cari_listele()
        {
            LookUpCari.Properties.DataSource = (from c in db.TBLCARI
                                                select new
                                                {
                                                    c.ID,
                                                    AD = c.AD + " " + c.SOYAD
                                                }).ToList();
        }

        void personel_listele()
        {
            lookUpPersonel.Properties.DataSource = (from p in db.TBLPERSONEL
                                                    select new
                                                    {
                                                        p.ID,
                                                        AD = p.AD + " " + p.SOYAD
                                                    }).ToList();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            TxtTarih.Text = "";
            TxtSaat.Text = "";
            TxtVergiDairesi.Text = "";
            LookUpCari.EditValue = null;
            lookUpPersonel.EditValue = null;
            TxtSeri.Focus();
        }


        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            listele();
            cari_listele();
            personel_listele();
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
                if (TxtSeri.Text != "" && TxtSiraNo.Text != "" && TxtSiraNo.Text.Length <= 6 &&
                    TxtVergiDairesi.Text != "" && LookUpCari.EditValue != null && lookUpPersonel.EditValue != null)
                {
                    TBLFATURABILGI tb = new TBLFATURABILGI();
                    tb.SERI = TxtSeri.Text;
                    tb.SIRANO = TxtSiraNo.Text;
                    tb.TARIH = Convert.ToDateTime(TxtTarih.Text);
                    tb.SAAT = TxtSaat.Text;
                    tb.VERGIDAIRE = TxtVergiDairesi.Text;
                    tb.CARI = int.Parse(LookUpCari.EditValue.ToString());
                    tb.PERSONEL = short.Parse(lookUpPersonel.EditValue.ToString());
                    db.TBLFATURABILGI.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Fatura bilgileri sisteme başarılı bir şekilde eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemDetaylar fr = new FrmFaturaKalemDetaylar();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtSeri.Text != "" && TxtSiraNo.Text != "" && TxtSiraNo.Text.Length <= 6 &&
                    TxtVergiDairesi.Text != "" && LookUpCari.EditValue != null && lookUpPersonel.EditValue != null)
                {
                    int id = int.Parse(TxtID.Text);
                    var degerler = db.TBLFATURABILGI.Find(id);
                    degerler.SERI = TxtSeri.Text;
                    degerler.SIRANO = TxtSiraNo.Text;
                    degerler.TARIH = DateTime.Parse(TxtTarih.Text);
                    degerler.SAAT = TxtSaat.Text;
                    degerler.VERGIDAIRE = TxtVergiDairesi.Text;
                    degerler.CARI = int.Parse(LookUpCari.EditValue.ToString());
                    degerler.PERSONEL = short.Parse(lookUpPersonel.EditValue.ToString());
                    db.SaveChanges();
                    MessageBox.Show("Fatura bilgileri başarılı bir şekilde güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtSeri.Text = gridView1.GetFocusedRowCellValue("SERI").ToString();
                TxtSiraNo.Text = gridView1.GetFocusedRowCellValue("SIRANO").ToString();
                TxtTarih.Text = gridView1.GetFocusedRowCellValue("TARIH").ToString();
                TxtSaat.Text = gridView1.GetFocusedRowCellValue("SAAT").ToString();
                TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRE").ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
