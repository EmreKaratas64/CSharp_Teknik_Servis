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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtBaslik.Text = "";
            RchICerik.Text = "";
            TxtEditTarih.Text = "";
            CheckDurum.Checked = false;
            TxtBaslik.Focus();
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            gridView2.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtBaslik.Text != "" && RchICerik.Text != "" && TxtEditTarih.Text != "")
                {
                    TBLNOTLARIM tb = new TBLNOTLARIM();
                    tb.BASLIK = TxtBaslik.Text;
                    tb.ICERIK = RchICerik.Text;
                    tb.DURUM = false;
                    tb.TARIH = DateTime.Parse(TxtEditTarih.Text);
                    db.TBLNOTLARIM.Add(tb);
                    db.SaveChanges();
                    MessageBox.Show("Not ekleme işlemi başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Boş değer girilemez lütfen tekrar deneyin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            if (bool.Parse(gridView1.GetFocusedRowCellValue("DURUM").ToString()) == true)
            {
                CheckDurum.Checked = true;
            }
            if (bool.Parse(gridView1.GetFocusedRowCellValue("DURUM").ToString()) == false)
            {
                CheckDurum.Checked = false;
            }

            RchICerik.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();
            TxtEditTarih.Text = gridView1.GetFocusedRowCellValue("TARIH").ToString();

        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
            TxtBaslik.Text = gridView2.GetFocusedRowCellValue("BASLIK").ToString();
            if (bool.Parse(gridView2.GetFocusedRowCellValue("DURUM").ToString()) == true)
            {
                CheckDurum.Checked = true;
            }
            if (bool.Parse(gridView2.GetFocusedRowCellValue("DURUM").ToString()) == false)
            {
                CheckDurum.Checked = false;
            }

            RchICerik.Text = gridView2.GetFocusedRowCellValue("ICERIK").ToString();
            TxtEditTarih.Text = gridView2.GetFocusedRowCellValue("TARIH").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                DialogResult onay = MessageBox.Show("Notu silmek istediğinizden emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                try
                {
                    if (onay == DialogResult.Yes)
                    {
                        int id = int.Parse(TxtID.Text);
                        var deger = db.TBLNOTLARIM.Find(id);
                        db.TBLNOTLARIM.Remove(deger);
                        db.SaveChanges();
                        MessageBox.Show("Not silme işlemi başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        listele();
                    }
                    else
                    {
                        MessageBox.Show("Not silme işlemi başarılı bir şekilde iptal edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e1)
                {

                    MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Silme işleminde ID alanı boş geçilemez lütfen ID girerek tekrar deneyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDurum.Checked == true && TxtBaslik.Text != "" && RchICerik.Text != "" && TxtEditTarih.Text != "")
                {
                    int id = int.Parse(TxtID.Text);
                    var deger = db.TBLNOTLARIM.Find(id);
                    deger.BASLIK = TxtBaslik.Text;
                    deger.ICERIK = RchICerik.Text;
                    deger.DURUM = true;
                    db.SaveChanges();
                    MessageBox.Show("Not güncelleme başarılı bir şekilde yapıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Lütfen girdiğiniz değerleri kontrol edip tekrar deneyin", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e1)
            {

                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
