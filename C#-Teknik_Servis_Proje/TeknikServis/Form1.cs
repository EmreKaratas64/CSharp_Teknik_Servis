using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Formlar.FrmUrunListesi fr1;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new Formlar.FrmUrunListesi();
                fr1.MdiParent = this;
                fr1.Show();
            }
            
        }

        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniUrun fr = new Formlar.FrmYeniUrun();
            fr.Show();  
        }
        Formlar.FrmKategori fr2;
        private void BtnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if(fr2 == null || fr2.IsDisposed)
            {   fr2 = new Formlar.FrmKategori();
                fr2.MdiParent = this;
                fr2.Show();
            }
            
        }

        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniKategori fr = new Formlar.FrmYeniKategori();
            fr.Show();
            
            
        }

        Formlar.FrmIstatistik fr3;
        private void BtnUrunIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if(fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmIstatistik();
                fr3.MdiParent = this;
                fr3.Show();
            }
            
        }

        Formlar.FrmMarkalar fr4;
        private void BtnMarkaIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if(fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Formlar.FrmMarkalar();
                fr4.MdiParent = this;
                fr4.Show();
            }
            
        }

        Formlar.FrmCariListesi fr5;
        private void BtnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmCariListesi();
                fr5.MdiParent = this;
                fr5.Show();
            }
                
        }

        Formlar.FrmCariiller fr6;
        private void BtnCariIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmCariiller();
                fr6.MdiParent = this;
                fr6.Show();
            }
               
        }

       
        private void BtnYeniCari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                Formlar.FrmCariEkle fr = new Formlar.FrmCariEkle();
                fr.Show();     
        }

        Formlar.FrmDepartman fr7;
        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmDepartman();
                fr7.MdiParent = this;
                fr7.Show();
            }    
        }

        private void BtnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniDepartman fr = new Formlar.FrmYeniDepartman();  
            fr.Show();
        
        }

        Formlar.FrmPersonel fr8;
        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmPersonel();
                fr8.MdiParent = this;
                fr8.Show();
            }
                
        }

        private void BtnYeniPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniPersonel fr = new Formlar.FrmYeniPersonel();
            fr.Show();
            
                
        }

        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        Formlar.FrmKurlar fr9;
        private void BtnDoviz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmKurlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
                
        }

        Formlar.FrmYouTube fr10;
        private void BtnYouTube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new Formlar.FrmYouTube();
                fr10.MdiParent = this;
                fr10.Show();
            }
            
        }

        Formlar.FrmNotlar fr11;
        private void BtnAjanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmNotlar();
                fr11.MdiParent = this;
                fr11.Show();
            }
                
        }

        Formlar.FrmHaberler fr12;
        private void BtnHaber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmHaberler();
                fr12.MdiParent = this;
                fr12.Show();
            }
                
        }

        private void BtnYeniNot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniNot fr = new Formlar.FrmYeniNot();
            fr.Show();
       
        }

        Formlar.FrmArizaListesi fr13;
        private void BtnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new Formlar.FrmArizaListesi();
                fr13.MdiParent = this;
                fr13.Show();
            }
               
        }

        private void BtnYeniUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunSatis fr = new Formlar.FrmUrunSatis();
            fr.Show();      
        }

        Formlar.FrmSatislar fr14;
        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmSatislar();
                fr14.MdiParent = this;
                fr14.Show();
            }
                
        }

        private void BtnYeniArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunKaydi fr = new Formlar.FrmArizaliUrunKaydi();
            fr.Show();  
        }

        private void BtnArizaliUrunAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArızaDetay fr = new Formlar.FrmArızaDetay();
            fr.Show();    
        }

        Formlar.FrmArizaliUrunDetayListesi fr15;
        private void FrmArizaliUrunDetayListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmArizaliUrunDetayListesi();
                fr15.MdiParent = this;
                fr15.Show();
            }
                
        }

        private void BtnQRKodOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRKod fr = new Formlar.FrmQRKod();
            fr.Show();    
        }

        Formlar.FrmFaturaListesi fr16;
        private void BtnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmFaturaListesi();
                fr16.MdiParent = this;
                fr16.Show();
            }
                
        }

        Formlar.FaturaKalem fr17;
        private void BtnFaturaKalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FaturaKalem();
                fr17.MdiParent = this;
                fr17.Show();
            }
                
        }

        Formlar.FrmFaturaDetaylıSorgulama fr18;
        private void BtnFaturaDetaylıSorgulama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmFaturaDetaylıSorgulama();
                fr18.MdiParent = this;
                fr18.Show();
            }
               
        }

        Formlar.FrmHaritalar fr19;
        private void BtnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmHaritalar();
                fr19.MdiParent = this;
                fr19.Show();
            }
                
        }

        private void BtnRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmRaporlar fr = new Formlar.FrmRaporlar();
            fr.Show();        
        }


        Formlar.FrmAnaSayfa fr;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        private void BtnYeniFaturaGirisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Formlar.FrmFaturaKalemDetaylar fr20 = new Formlar.FrmFaturaKalemDetaylar();
           fr20.Show();
        }

        ILETISIM.FrmRehber fr20;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr20 == null || fr20.IsDisposed)
            {
                fr20 = new ILETISIM.FrmRehber();
                fr20.MdiParent = this;
                fr20.Show();
            }
        }
        ILETISIM.FrmGelenMesajlar fr21;
        private void BtnGelenMesajlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr21 == null || fr21.IsDisposed)
            {
                fr21 = new ILETISIM.FrmGelenMesajlar();
                fr21.MdiParent = this;
                fr21.Show();
            }
        }

        private void BtnMailGonder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ILETISIM.FrmMail fr = new ILETISIM.FrmMail();
            fr.Show();
        }

        private void BtnOturumKapat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLogin lg = new FrmLogin();
            lg.Show();
            this.Hide();
        }

        private void BtnCikisYap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}
