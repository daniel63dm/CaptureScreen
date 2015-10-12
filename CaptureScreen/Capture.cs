using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureScreen
{
    public partial class Capture : Form
    {
        public Capture()
        {
            InitializeComponent();
        }

        private void mouse_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtLog.Text = $"click {e.Location.ToString()}";
            }
        }

        private void key_press(object sender, KeyEventArgs e)
        {
            txtLog.Text = e.KeyCode.ToString();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            ScreenShot.CaptureScreen(ScreenRectangle.Draw(this));
        }
    }
}
