using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSonLib;
using System.Diagnostics;
using System.IO;

namespace CaptureScreen
{
    // TODO : add command to write list of files to json file. On Close event ?
    // Build separate tool to fill the image's description
    public partial class Capture : Form
    {
        private List<String> files = new List<string>();
        public Capture()
        {
            InitializeComponent();
            rbFile.Checked = true;
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
            this.Hide();
            ScreenShot.Prefix = $"{txtParam.Text} ";
            ScreenShot.CaptureScreen(ScreenRectangle.Draw(this),rbClipboard.Checked?OutputTarget.Clipboard:OutputTarget.File);
            txtLog.Text += ScreenShot.FileName;
            files.Add(ScreenShot.FileName);
            this.Show();
        }

        private void btnBuildDoc_Click(object sender, EventArgs e)
        {
            JSonBuilder jsonBuilder = new JSonBuilder();
            string json = jsonBuilder.ListToJSon("files",files);
            string filename = Path.GetDirectoryName(ScreenShot.FileName) + @"\files.json";
            writeJson(json, filename);
            }

        private async void writeJson(string json, string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                await outputFile.WriteAsync(json);
            }
        }
    }
}
