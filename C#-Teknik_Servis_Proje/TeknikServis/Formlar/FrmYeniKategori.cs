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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void PictureClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BrnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtKategoriAd.Text != "" && TxtKategoriAd.Text.Length <= 30)
            {
                TBLKATEGORI k = new TBLKATEGORI();
                k.AD = TxtKategoriAd.Text;
                db.TBLKATEGORI.Add(k);
                db.SaveChanges();
                MessageBox.Show("Kategori ekleme işlemi başarıyla yapılmıştır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori adı boş olamaz ve 30 karakterden fazla olamaz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void TxtKategoriAd_Click(object sender, EventArgs e)
        {
            TxtKategoriAd.Text = "";
            TxtKategoriAd.Focus();
        }
    }
}
