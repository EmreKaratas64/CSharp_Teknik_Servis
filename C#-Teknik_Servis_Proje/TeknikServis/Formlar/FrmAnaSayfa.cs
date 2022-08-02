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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            gridView2.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            gridView3.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
            gridView4.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";

            gridControl1.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.MARKA,
                                           x.STOK
                                       }).Where(x => x.STOK < 30).ToList();

            gridControl2.DataSource = (from c in db.TBLCARI
                                       select new
                                       {
                                           c.AD,
                                           c.SOYAD,
                                           c.TELEFON,
                                           c.IL
                                       }).ToList();



            // her bir kategriden kaç tane ürün olduğunu öğrendiğimiz linq sorgusu
            //gridControl3.DataSource = db.TBLURUN.GroupBy(u => u.TBLKATEGORI.AD).Select(y => new
            //{
            //    KATEGORI = y.Key,
            //    TOPLAM = y.Count()
            //}).ToList();

            gridControl3.DataSource = db.urunkategori().ToList();



            DateTime bugun = DateTime.Today;

            var degerler = (from x in db.TBLNOTLARIM.OrderBy(y => y.ID)
                            where (x.TARIH == bugun)
                            select new
                            {
                                x.BASLIK,
                                x.ICERIK
                            });

            gridControl4.DataSource = degerler.ToList();


            /*
             Button btn = new Button();
             btn.Text = "Topla";
             btn.Location = new Point(10,50);
             this.Controls.Add(btn);
             */

            /*
              

            LabelControl[] label= new LabelControl[7] { labelControl1, labelControl2, labelControl3, labelControl4, labelControl5, labelControl6, labelControl7 };

           for(int i = 0; i <7; i++)

            {

               konu[i] = db.tbl_message.First(m => m.Id == i+1).Baslik;

                ad[i] = db.tbl_message.First(m => m.Id == i+1).AdSoyad;

                label[i].Text = konu[i] + " - " + ad[i];

            }   
             */

            string[] konu = new string[10];

            string[] ad = new string[10];

            Label[] label = new Label[10] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 };

            for (int i = 0; i < 10; i++)
            {
                konu[i] = db.TBLILETISIM.First(x => x.ID == i + 1).KONU;
                ad[i] = db.TBLILETISIM.First(x => x.ID == i + 1).ADSOYAD;
                label[i].Text = konu[i] + " - " + ad[i];
                
            }

        }
    }
}
