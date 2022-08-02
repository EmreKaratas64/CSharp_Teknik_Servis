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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void PictureClose_MouseHover(object sender, EventArgs e)
        {
            PictureClose.BackColor = System.Drawing.Color.FromArgb(34, 36, 49);
        }

        private void PictureClose_MouseLeave(object sender, EventArgs e)
        {
            PictureClose.BackColor = Color.Transparent;
        }

        private void PictureClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BrnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtAd.Text.Length <= 50 && TxtAd.Text != "")
                {
                    TBLDEPARTMAN td = new TBLDEPARTMAN();
                    td.AD = TxtAd.Text;
                    db.TBLDEPARTMAN.Add(td);
                    db.SaveChanges();
                    MessageBox.Show("Departman ekleme işlemi başarıyla yapılmıştır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Departman kaydı yapılamdı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
