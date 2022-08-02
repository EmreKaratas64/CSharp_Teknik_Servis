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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            LblToplamUrun.Text = db.TBLURUN.Count().ToString();
            LblToplamKategori.Text = db.TBLKATEGORI.Count().ToString();
            LblToplamStok.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            LblTelefonStokSayisi.Text = db.TBLURUN.Where(x => x.KATEGORI == 2).Sum(y => y.STOK).ToString();
            DateTime bugun = DateTime.Today;

            var sorgu = from z in db.TBLURUNHAREKET
                        where z.TARIH == bugun
                        select z;
            if (sorgu.Any())
                LblBugünSatılanUrunSayisi.Text = db.TBLURUNHAREKET.Where(x => x.TARIH == bugun).Sum(y => y.ADET).ToString();
            else
                LblBugünSatılanUrunSayisi.Text = "0";
            


            LblEnFazlaStokluUrun.Text = (from x in db.TBLURUN
                                         orderby x.STOK descending
                                         select x.AD).FirstOrDefault();
            LblEnAzStokluUrun.Text = (from x in db.TBLURUN
                                      orderby x.STOK ascending
                                      select x.AD).FirstOrDefault();

            LblEnFazlaUrunKategorisi.Text = db.enfazlaurununkategori().FirstOrDefault();
            LblEnYuksekFiyatliUrun.Text = (from x in db.TBLURUN
                                           orderby x.SATISFIYAT descending
                                           select x.AD).FirstOrDefault();
            LblEnDusukFiyatliUrun.Text = (from x in db.TBLURUN
                                          orderby x.SATISFIYAT ascending
                                          select x.AD).FirstOrDefault();

            LblToplamMarkaSayisi.Text = (from x in db.TBLURUN
                                         select x.MARKA).Distinct().Count().ToString();

            LblEnFazlaUrunuOlanMarka.Text = db.enfazlaurunlumarka().FirstOrDefault();
            LblArizaliUrunSayisi.Text = db.TBLURUNKABUL.Count().ToString();
            LblTamirderkiUrunSayisi.Text = db.TBLURUNKABUL.Where(x => x.CIKISTARIH == null).Count().ToString();
            LblBugunGetirilenArizaliUrunSayisi.Text = db.TBLURUNKABUL.Count(x => x.GELISTARIH == bugun).ToString();
            LblOnarilmisUrunSayisi.Text = db.TBLURUNKABUL.Where(x => x.CIKISTARIH != null).Count().ToString();
            LblToplamPersonelSayısı.Text = db.TBLPERSONEL.Count().ToString();

            LblBeyazEsyaStokSayisi.Text = db.TBLURUN.Where(x => x.KATEGORI == 4).Sum(y => y.STOK).ToString();
            LblBilgisayarStokSayisi.Text = db.TBLURUN.Where(x => x.KATEGORI == 1).Sum(y => y.STOK).ToString();
            LblKucukEvAletiStokSayısı.Text = db.TBLURUN.Where(x => x.KATEGORI == 3).Sum(y => y.STOK).ToString();
        }
    }
}
