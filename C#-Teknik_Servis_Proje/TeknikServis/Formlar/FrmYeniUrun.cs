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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BrnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtUrunAd.Text != "" && TxtUrunAd.Text.Length <= 30 && TxtMarka.Text != "" && TxtMarka.Text.Length <= 30)
            {
                TBLURUN tb = new TBLURUN();
                tb.AD = TxtUrunAd.Text;
                tb.MARKA = TxtMarka.Text;
                tb.KATEGORI = byte.Parse(LookUpKategori.EditValue.ToString());
                tb.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
                tb.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
                tb.STOK = short.Parse(TxtStok.Text);
                tb.DURUM = false;
                db.TBLURUN.Add(tb);
                db.SaveChanges();
                MessageBox.Show("Ürün kaydı sisteme başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ürün adı ve marka değerleri boş olamaz ve 30 karakterden az olmalıdır !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void TxtUrunAd_Click(object sender, EventArgs e)
        {
            TxtUrunAd.Text = "";
            TxtUrunAd.Focus();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            LookUpKategori.Properties.DataSource = (from x in db.TBLKATEGORI
                                                    select new
                                                    {
                                                        x.ID,
                                                        x.AD
                                                    }).ToList();
        }

        private void TxtMarka_Click(object sender, EventArgs e)
        {
            TxtMarka.Text = "";
            TxtMarka.Focus();
        }

        private void TxtAlisFiyat_Click(object sender, EventArgs e)
        {
            TxtAlisFiyat.Text = "";
            TxtAlisFiyat.Focus();
        }

        private void TxtSatisFiyat_Click(object sender, EventArgs e)
        {
            TxtSatisFiyat.Text = "";
            TxtSatisFiyat.Focus();
        }

        private void TxtStok_Click(object sender, EventArgs e)
        {
            TxtStok.Text = "";
            TxtStok.Focus();
        }
    }
}
