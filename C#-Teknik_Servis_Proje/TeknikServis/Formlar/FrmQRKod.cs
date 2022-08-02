using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace TeknikServis.Formlar
{
    public partial class FrmQRKod : Form
    {
        public FrmQRKod()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            PictureQR.Image = encoder.Encode(TxtSeriNO.Text);
        }

        private void pictureClose_MouseHover(object sender, EventArgs e)
        {
            pictureClose.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
        }

        private void pictureClose_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.BackColor = Color.Transparent;
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity > 0.00)
            {
                this.Opacity -= 0.2;
            }
            else
            {
                timer1.Stop();
                this.Hide();
            }
        }
    }
}
