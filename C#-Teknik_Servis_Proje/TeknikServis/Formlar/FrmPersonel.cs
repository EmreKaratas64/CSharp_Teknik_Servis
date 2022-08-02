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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            var degerler = from p in db.TBLPERSONEL
                           select new
                           {
                               p.ID,
                               p.AD,
                               p.SOYAD,
                               DEPARTMAN = p.TBLDEPARTMAN.AD,
                               p.FOTOGRAF,
                               p.MAIL,
                               p.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();

            lookUpEditDepartman.Properties.DataSource = (from d in db.TBLDEPARTMAN
                                                         select new
                                                         {
                                                             d.ID,
                                                             d.AD
                                                         }).ToList();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            lookUpEditDepartman.EditValue = null;
            TextEditMail.Text = "";
            TextEditTelefon.Text = "";
            TxtFotograf.Text = "";
            TxtAd.Focus();

        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            listele();
            string ad1, soyad1, dep1, mail1;
            string ad2, soyad2, dep2, mail2;
            string ad3, soyad3, dep3, mail3;
            string ad4, soyad4, dep4, mail4;

            ad1 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            dep1 = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;
            mail1 = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;

            ad2 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            dep2 = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;
            mail2 = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;

            ad3 = db.TBLPERSONEL.First(x => x.ID == 5).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 5).SOYAD;
            dep3 = db.TBLPERSONEL.First(x => x.ID == 5).TBLDEPARTMAN.AD;
            mail3 = db.TBLPERSONEL.First(x => x.ID == 5).MAIL;

            ad4 = db.TBLPERSONEL.First(x => x.ID == 6).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 6).SOYAD;
            dep4 = db.TBLPERSONEL.First(x => x.ID == 6).TBLDEPARTMAN.AD;
            mail4 = db.TBLPERSONEL.First(x => x.ID == 6).MAIL;

            LblAdSoyad.Text = ad1 + " " + soyad1;
            LblDepartman.Text = dep1;
            LblMail.Text = mail1;

            LblAdSoyad2.Text = ad2 + " " + soyad2;
            LblDepartman2.Text = dep2;
            LblMail2.Text = mail2;

            AdSoyad3.Text = ad3 + " " + soyad3;
            LblDepartman3.Text = dep3;
            LblMail3.Text = mail3;

            LblAdSoyad4.Text = ad4 + " " + soyad4;
            LblDepartman4.Text = dep4;
            LblMail4.Text = mail4;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAd.Text.Length <= 30 && TxtSoyad.Text.Length <= 30 && TxtFotograf.Text.Length <= 100 && TextEditMail.Text.Length <= 50 && TextEditTelefon.Text.Length <= 20
                    && TxtAd.Text != "" && TxtSoyad.Text != "" && TxtFotograf.Text != "" && TextEditMail.Text != "" &&
                    TextEditTelefon.Text != "" && lookUpEditDepartman.EditValue != null)
                {
                    TBLPERSONEL tp = new TBLPERSONEL();
                    tp.AD = TxtAd.Text;
                    tp.SOYAD = TxtSoyad.Text;
                    tp.DEPARTMAN = byte.Parse(lookUpEditDepartman.EditValue.ToString());
                    tp.FOTOGRAF = TxtFotograf.Text;
                    tp.MAIL = TextEditMail.Text;
                    tp.TELEFON = TextEditTelefon.Text;
                    db.TBLPERSONEL.Add(tp);
                    db.SaveChanges();
                    MessageBox.Show("Personel kaydı başarıyla yapıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamadı lütfen girdiğiniz değerleri kontrol ediniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            //lookUpEditDepartman.Text = gridView1.GetFocusedRowCellValue("DEPARTMAN");
            TxtFotograf.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF").ToString();
            TextEditMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            TextEditTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAd.Text.Length <= 30 && TxtSoyad.Text.Length <= 30 && TxtFotograf.Text.Length <= 100 && TextEditMail.Text.Length <= 50 && TextEditTelefon.Text.Length <= 20
                    && TxtAd.Text != "" && TxtSoyad.Text != "" && TxtFotograf.Text != "" && TextEditMail.Text != "" &&
                    TextEditTelefon.Text != "" && lookUpEditDepartman.EditValue != null)
                {
                    int id = int.Parse(TxtID.Text);
                    var deger = db.TBLPERSONEL.Find(id);
                    deger.AD = TxtAd.Text;
                    deger.SOYAD = TxtSoyad.Text;
                    deger.DEPARTMAN = byte.Parse(lookUpEditDepartman.EditValue.ToString());
                    deger.FOTOGRAF = TxtFotograf.Text;
                    deger.MAIL = TextEditMail.Text;
                    deger.TELEFON = TextEditTelefon.Text;
                    db.SaveChanges();
                    MessageBox.Show("Personel başarıyla güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Personel kaydı güncellenemedi lütfen girdiğiniz değerleri kontrol ediniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
