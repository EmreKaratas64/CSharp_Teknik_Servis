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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";

            var degerler = db.TBLURUN.OrderBy(x => x.STOK).GroupBy(x => x.MARKA).Select(x => new
            {
                MARKA = x.Key,
                ToplamUrun = x.Sum(y => y.STOK)
            }).ToList();
            gridControl1.DataSource = degerler.ToList();

            LblToplamUrun.Text = db.TBLURUN.Count().ToString();

            LblEnFazlaUrunuOlanMarka.Text = db.enfazlaurunlumarka().FirstOrDefault();

            LblToplamMarkaSayisi.Text = (from x in db.TBLURUN
                                         select x.MARKA).Distinct().Count().ToString();
            LblEnYuksekFiyatliMarka.Text = (from x in db.TBLURUN
                                            orderby x.SATISFIYAT descending
                                            select x.MARKA).FirstOrDefault();

            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NKLMS7G;initial catalog=DbTeknikServis;integrated security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA,COUNT(*) FROM TBLURUN GROUP BY MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            baglanti.Close();



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TBLKATEGORI.AD,COUNT(*) FROM TBLURUN INNER JOIN TBLKATEGORI ON TBLKATEGORI.ID = TBLURUN.KATEGORI GROUP BY TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]),int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();

        }
    }
}
