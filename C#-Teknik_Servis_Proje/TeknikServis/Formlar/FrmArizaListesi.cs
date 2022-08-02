using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            var degerler = from u in db.TBLURUNKABUL
                           select new
                           {
                               u.ISLEMID,
                               CARİ = u.TBLCARI.AD + " " + u.TBLCARI.SOYAD,
                               PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                               u.GELISTARIH,
                               u.CIKISTARIH,
                               u.URUNSERINO,
                               u.URUNDURUMDETAY
                           };

            gridControl1.DataSource = degerler.ToList();
        }

        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";

            listele();

            LblMevcutArizaliUrunSayisi.Text = db.TBLURUNKABUL.Count().ToString();
            LblTadilatiBitmisUrunSayisi.Text = db.TBLURUNKABUL.Where(x => x.CIKISTARIH != null).Count().ToString();
            LblParcaBekleyenUrunSayisi.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Parça Bekliyor").ToString();
            LblMesajBekleyenUrunSayisi.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Mesaj Bekliyor").ToString();
            ToplamUrunSayisi.Text = db.TBLURUN.Count().ToString();
            LblIptalEdilenIslemSayisi.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "İptal Edildi").ToString();

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NKLMS7G;initial catalog=DbTeknikServis;integrated security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY,COUNT(*) FROM TBLURUNKABUL GROUP BY URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Formlar.FrmArızaDetay fr = new FrmArızaDetay();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.seri_no = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            fr.Show();
        }
    }
}
