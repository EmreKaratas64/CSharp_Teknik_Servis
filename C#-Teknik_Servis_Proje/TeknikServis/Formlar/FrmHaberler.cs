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
    public partial class FrmHaberler : Form
    {
        public FrmHaberler()
        {
            InitializeComponent();
        }

        private void FrmHaberler_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.haber.com/");
        }
    }
}
