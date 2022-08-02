using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teknik_Servis_Web.Entity;

namespace Teknik_Servis_Web
{
    public partial class Default : System.Web.UI.Page
    {
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
      
                var deger = db.TBLHAKKIMIZDA.ToList();
                Repeater1.DataSource = deger;
                Repeater1.DataBind();


                var urunler = (from u in db.TBLURUN
                               select new
                               {
                                   u.ID,
                                   u.AD,
                                   u.MARKA,
                                   u.SATISFIYAT,
                                   u.STOK,
                                   KATEGORI = u.TBLKATEGORI.AD
                               });
                Repeater2.DataSource = urunler.ToList();
                Repeater2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                string ad = TextBox1.Text;
                string mail = TextBox2.Text;
                string konu = TextBox3.Text;
                string mesaj = TextBox4.Text;
                if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(konu) && !string.IsNullOrEmpty(mesaj))
                {
                    TBLILETISIM tbl = new TBLILETISIM();
                    tbl.ADSOYAD = TextBox1.Text;
                    tbl.MAIL = TextBox2.Text;
                    tbl.KONU = TextBox3.Text;
                    tbl.MESAJ = TextBox4.Text;
                    db.TBLILETISIM.Add(tbl);
                    db.SaveChanges();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    Response.Write("<script>alert('Mesajınız için teşekkür ederiz :)');</script>");
                }
                else
                {
                    MsgBox("Text alanları boş olamaz !", this.Page, this);
                }  
        }
    }
}