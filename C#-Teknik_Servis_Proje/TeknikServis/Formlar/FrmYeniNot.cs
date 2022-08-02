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
    public partial class FrmYeniNot : Form
    {
        public FrmYeniNot()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void temizle()
        {
            TxtBaslik.Text = "";
            RchIcerik.Text = "";
            TxtBaslik.Focus();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void pictureClose_MouseHover(object sender, EventArgs e)
        {
            pictureClose.BackColor = System.Drawing.Color.FromArgb(34,36,49);
        }

        private void pictureClose_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.BackColor = System.Drawing.Color.FromArgb(1, 80, 165);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtBaslik.Text.Length <= 50 && RchIcerik.Text.Length <= 500 && TxtBaslik.Text != "" && RchIcerik.Text != "")
                {
                    TBLNOTLARIM nt = new TBLNOTLARIM();
                    nt.BASLIK = TxtBaslik.Text;
                    nt.ICERIK = RchIcerik.Text;
                    nt.DURUM = false;
                    db.TBLNOTLARIM.Add(nt);
                    db.SaveChanges();
                    MessageBox.Show("Not ekleme işlemi başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli değerler girerek tekrar deneyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
