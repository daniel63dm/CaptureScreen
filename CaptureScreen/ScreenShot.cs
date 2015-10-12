using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureScreen
{
    class ScreenShot
    {
        public static bool CaptureScreen(Rectangle selection)
        {
            Point UpLeftDestination = new Point(0, 0);
            using (Bitmap bmap = new Bitmap(selection.Width, selection.Height))
            {
                using (Graphics g = Graphics.FromImage(bmap))
                {
                    g.CopyFromScreen(selection.Location, UpLeftDestination,selection.Size);
                    Clipboard.SetImage(bmap);
                }
            }
            return true;
        }
    }
}
