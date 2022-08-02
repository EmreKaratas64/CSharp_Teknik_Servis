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
    public partial class FrmFaturaKalemDetaylar : Form
    {
        public FrmFaturaKalemDetaylar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();



        public void ExportExel(DevExpress.XtraGrid.Views.Grid.GridView gridView, string dosyaAdi)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Exel Calisma Kitabi | *.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                FileName = dosyaAdi
            };

            dialog.ShowDialog();
            gridView2.ExportToXlsx(dialog.FileName);
        }

        public void ExportPDF(DevExpress.XtraGrid.Views.Grid.GridView gridView2, string dosyaAdi)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "PDF | *.pdf",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                FileName = dosyaAdi
            };

            dialog.ShowDialog();
            gridView2.ExportToPdf(dialog.FileName);
        }



        public int id;
        private void FrmYeniFaturaGirisi_Load(object sender, EventArgs e)
        {
            gridView2.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            gridControl1.DataSource = (from x in db.TBLFATURABILGI
                                       select new
                                       {
                                           x.ID,
                                           x.SERI,
                                           x.SIRANO,
                                           x.TARIH,
                                           x.SAAT,
                                           x.VERGIDAIRE,
                                           CARİ = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                           PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD
                                       }).Where(y => y.ID == id).ToList();

            gridControl2.DataSource = (from x in db.TBLFATURADETAY
                                       select new
                                       {
                                           x.FATURADETAYID,
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR,
                                           x.FATURAID
                                       }).Where(y => y.FATURAID == id).ToList();
        }

        private void PictureClose_MouseHover(object sender, EventArgs e)
        {
            PictureClose.BackColor = System.Drawing.Color.FromArgb(31, 164, 239);
        }

        private void PictureClose_MouseLeave(object sender, EventArgs e)
        {
            PictureClose.BackColor = System.Drawing.Color.FromArgb(25, 118, 216);
        }

        private void PictureClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExel_Click(object sender, EventArgs e)
        {
            ExportExel(gridView2, "Faturaya ait Kalemler");
        }

        private void BtnPDF_Click(object sender, EventArgs e)
        {
            ExportPDF(gridView2, "Faturaya air Kalemler");
        }
    }
}
