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
    public partial class FrmFaturaDetaylıSorgulama : Form
    {
        public FrmFaturaDetaylıSorgulama()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        // db.TBLFATURADETAY.Where(x => x.FATURAID == fatura_id)
        private void BtnFaturaAra_Click(object sender, EventArgs e)
        {
            /*
                var degerler = (from x in db.TBLFATURADETAY
                                select new
                                {
                                    x.FATURADETAYID,
                                    x.URUN,
                                    x.ADET,
                                    x.FIYAT,
                                    x.TUTAR,
                                    x.FATURAID
                                }).where(x => x.FATURAID == fatura_id);
             */
            // aşağıdaki sorgu yukarıdaki gibi de yazılabilir.


            
            
            try
            {
                if (TxtFaturaID.Text != "" && TxtFaturaID.Text != null)
                {
                    int fatura_id = int.Parse(TxtFaturaID.Text);
                    var degerler = (from x in db.TBLFATURADETAY
                                    where x.FATURAID == fatura_id
                                    select new
                                    {
                                        x.FATURADETAYID,
                                        x.URUN,
                                        x.ADET,
                                        x.FIYAT,
                                        x.TUTAR,
                                        x.FATURAID
                                    });
                    gridControl1.DataSource = degerler.ToList();
                }
                else
                {
                    MessageBox.Show("Lütfen boş değer girmeyiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void FrmFaturaDetaylıSorgulama_Load(object sender, EventArgs e)
        {
            gridView1.GroupPanelText = "Guruplamak için sütun başlığını buraya sürükleyin";
        }
    }
}
