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
    public partial class FrmCariiller : Form
    {
        public FrmCariiller()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NKLMS7G;Initial Catalog=DbTeknikServis;Integrated Security=True");


        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmCariiller_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";

            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select IL,COUNT(*) as 'Müşteri Sayısı' From TBLCARI group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }

            baglanti.Close();


            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.IL).GroupBy(y => y.IL).Select(z => new
            {
                IL = z.Key,
                TOPLAM = z.Count()
            }).ToList();


            //var degerler = db.TBLCARI.OrderBy(x => x.IL).GroupBy(y => y.IL).
            //Select(z => new
            //{
            //    Sehir = z.Key,
            //    Musteri_Toplam = z.Count()
            //});

            
















        }
    }
}
