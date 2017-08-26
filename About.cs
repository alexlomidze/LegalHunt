using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace LegalHunt
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://inadire.ge/");
            }
            catch (Win32Exception)
            {
                Process.Start("IExplore.exe", "https://inadire.ge/");
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://www.gnu.org/licenses/gpl-3.0.en.html");
            }
            catch (Win32Exception)
            {
                Process.Start("IExplore.exe", "https://www.gnu.org/licenses/gpl-3.0.en.html");
            }
        }

        private void richTextBox1_Enter(object sender, System.EventArgs e)
        {
            linkLabel1.Focus();
        }
    }
}
