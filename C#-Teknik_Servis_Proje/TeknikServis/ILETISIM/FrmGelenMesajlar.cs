using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.ILETISIM
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            gridControl1.DataSource = (from x in db.TBLILETISIM
                                       select new
                                       {
                                           x.ID,
                                           x.ADSOYAD,
                                           x.MAIL,
                                           x.KONU,
                                           x.MESAJ
                                       }).ToList();

            LblToplamMesajSayisi.Text = db.TBLILETISIM.Count().ToString();
            LblTesekkurMesajSayisi.Text = db.TBLILETISIM.Count(x => x.KONU == "Teşekkürler").ToString();
            LblRicaMesajSayisi.Text = db.TBLILETISIM.Count(x => x.KONU == "Rica").ToString();
            LblSikayetSayisi.Text = db.TBLILETISIM.Count(x => x.KONU == "Şikayet").ToString();
            LblToplamPersonelSayisi.Text = db.TBLPERSONEL.Count().ToString();
            LblToplamCariSayisi.Text = db.TBLCARI.Count().ToString();
            LblToplamKategoriSayisi.Text = db.TBLKATEGORI.Count().ToString();
            LblToplamUrunSayisi.Text = db.TBLURUN.Count().ToString();
        }
    }
}
