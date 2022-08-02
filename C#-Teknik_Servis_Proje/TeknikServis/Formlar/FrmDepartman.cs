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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }


        DbTeknikServisEntities db = new DbTeknikServisEntities();


        void listele()
        {
            var degerler = from d in db.TBLDEPARTMAN
                           select new
                           {
                               d.ID,
                               d.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            RchAciklama.Text = "";
            TxtAd.Focus();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAd.Text.Length <= 50 && TxtAd.Text != "")
                {
                    TBLDEPARTMAN tb = new TBLDEPARTMAN();
                    tb.AD = TxtAd.Text;
                    db.TBLDEPARTMAN.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Departman kaydı başarıyla yapıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Departman kaydı yapılamadı girdiğiniz değerleri kontrol edin !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            listele();
            LblToplamDepartman.Text = db.TBLDEPARTMAN.Count().ToString();
            LblToplamPersonel.Text = db.TBLPERSONEL.Count().ToString();
            LblEnFazlaCalisanliDepartman.Text = db.enfazlapersonellidepartman().FirstOrDefault();
            LblEnAzCalisanliDepartman.Text = db.enazpersonellidepartman().FirstOrDefault();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                if ((string)gridView1.GetFocusedRowCellValue("AD") == null)
                {
                    TxtAd.Text = "";
                }
                else
                {
                    TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                }
                if((string)gridView1.GetFocusedRowCellValue("ACIKLAMA") == null)
                {
                    RchAciklama.Text = "";
                }
                else
                {
                    TxtAd.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
                }
                
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAd.Text.Length <= 50 && TxtAd.Text != "")
                {
                    int id = int.Parse(TxtID.Text);
                    var deger = db.TBLDEPARTMAN.Find(id);
                    deger.AD = TxtAd.Text;
                    db.SaveChanges();
                    MessageBox.Show("Departman başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listele();
                }
                else
                {
                    MessageBox.Show("Departman güncellenemedi girdiğiniz değerleri kontrol edin !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
