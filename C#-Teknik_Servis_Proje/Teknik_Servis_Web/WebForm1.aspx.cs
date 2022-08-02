using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teknik_Servis_Web.Entity;

namespace Teknik_Servis_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //var degerler = db.TBLURUNTAKIP.ToList();
            //Repeater1.DataSource = degerler;
            //Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var degerler = db.TBLURUNTAKIP.Where(x => x.SERINO == TextBox1.Text);
            if (degerler.Any())
            {
                Repeater1.DataSource = degerler.ToList();
                Repeater1.DataBind();
            }
            else
            {
                Response.Write("Girdiğiniz değerde ürün bulunmamaktadır");
            }
        }
    }
}