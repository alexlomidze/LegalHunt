using System;
using System.Windows.Forms;
using System.Threading;

namespace LegalHunt
{
    public partial class SplaScreen : Form
    {
        public SplaScreen()
        {
            InitializeComponent();
        }

        private void SplaScreen_Load(object sender, EventArgs e)
        {

            pictureBox1.ImageLocation = "logo2.png";
            //Thread.Sleep(5000);
            //this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
