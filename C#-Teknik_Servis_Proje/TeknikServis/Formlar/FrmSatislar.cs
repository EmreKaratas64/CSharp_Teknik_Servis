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
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            var degerler = from t in db.TBLURUNHAREKET
                           select new
                           {
                               t.HAREKETID,
                               t.TBLURUN.AD,
                               MUSTERI = t.TBLCARI.AD + " " + t.TBLCARI.SOYAD,
                               PERSONEL = t.TBLPERSONEL.AD + " " + t.TBLPERSONEL.SOYAD,
                               t.TARIH,
                               t.ADET,
                               t.FIYAT,
                               t.URUNSERINO
                           };

            gridControl1.DataSource = degerler.ToList();
        }


        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            listele();
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
        }
    }
}
