using DevExpress.XtraEditors;
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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void PictureClose_MouseHover(object sender, EventArgs e)
        {
            PictureClose.BackColor = System.Drawing.Color.FromArgb(63, 63, 65);
        }

        private void PictureClose_MouseLeave(object sender, EventArgs e)
        {
            PictureClose.BackColor = Color.Transparent;
        }

        private void PictureClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            //lookUpEditUrun.EditValue = null;
            LookUpEditMusteri.EditValue = null;
            lookUpEditPersonel.EditValue = null;
            TxtTarih.Text = "";
            TxtAdet.Text = "";
            TxtSatisFiyat.Text = "";
            TxtSeriNo.Text = "";
            TxtToplamTutar.Text = "";
            lookUpEditUrun.Focus();
        }

        private void BrnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if(lookUpEditUrun.EditValue != null && LookUpEditMusteri.EditValue != null &&
                    lookUpEditPersonel.EditValue != null && TxtSeriNo.Text != "" && TxtAdet.Text != ""
                    && TxtAdet.Text.Length <= 4 && TxtSatisFiyat.Text != "" && TxtToplamTutar.Text != "")
                {
                    TBLURUNHAREKET tb = new TBLURUNHAREKET();
                    tb.URUN = int.Parse(lookUpEditUrun.EditValue.ToString());
                    tb.MUSTERI = int.Parse(LookUpEditMusteri.EditValue.ToString());
                    tb.PERSONEL = short.Parse(lookUpEditPersonel.EditValue.ToString());
                    tb.TARIH = DateTime.Parse(TxtTarih.Text);
                    tb.ADET = short.Parse(TxtAdet.Text);
                    tb.FIYAT = decimal.Parse(TxtToplamTutar.Text);
                    tb.URUNSERINO = TxtSeriNo.Text;
                    db.TBLURUNHAREKET.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Ürün satışı başarıyla yapıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Geçersiz değer girişi, lütfen boş değer girmediğinizden ve karakter uzunluklarının uygun olup olmadığını kontrol edip tekrar deneyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lookUpEditUrun.Properties.DataSource = (from x in db.TBLURUN
                                                    select new
                                                    {
                                                        x.ID,
                                                        x.AD
                                                    }).ToList();

            LookUpEditMusteri.Properties.DataSource = (from x in db.TBLCARI
                                                       select new
                                                       {
                                                           x.ID,
                                                           AD = x.AD + " " + x.SOYAD
                                                       }).ToList();

            lookUpEditPersonel.Properties.DataSource = (from x in db.TBLPERSONEL
                                                        select new
                                                        {
                                                            x.ID,
                                                            AD = x.AD + " " + x.SOYAD
                                                        }).ToList();
        }
       
    private void BtnTutarHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtAdet.Text != "" && TxtSatisFiyat.Text != "")
                {
                    int adet = Convert.ToInt32(TxtAdet.Text);
                    decimal birim_fiyat, tutar;
                    birim_fiyat = Convert.ToDecimal(TxtSatisFiyat.Text);
                    tutar = adet * birim_fiyat;
                    TxtToplamTutar.Text = tutar.ToString();
                }
                else
                {
                    XtraMessageBox.Show("Adet ve birim fiyat boş geçilemez !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception e1)
            {
                XtraMessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookUpEditUrun_EditValueChanged(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(lookUpEditUrun.EditValue.ToString());
            var satisfiyat_getir = db.TBLURUN.SingleOrDefault(x => x.ID == id);

            if(satisfiyat_getir != null)
            {
                TxtSatisFiyat.Text = satisfiyat_getir.SATISFIYAT.ToString();
                TxtSeriNo.Text = db.TBLURUNHAREKET.Where(x => x.URUN == id).Select(x => x.URUNSERINO).FirstOrDefault();
            }
            
            if(TxtSeriNo.Text == "")
            {
                XtraMessageBox.Show("Ürünün henüz bir seri numarası olmadığı için getiremiyoruz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
