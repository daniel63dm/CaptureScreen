using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
 
namespace CaptureScreen
{
    enum OutputTarget
    {
        Clipboard,
        File
    }
    class ScreenShot
    {
        public static String FileName { get; private set; }
        public static string Prefix { get; set; }
        public static bool CaptureScreen(Rectangle selection, OutputTarget target = OutputTarget.Clipboard)
        {
            Point UpLeftDestination = new Point(0, 0);
            using (Bitmap bmap = new Bitmap(selection.Width, selection.Height))
            {
                using (Graphics g = Graphics.FromImage(bmap))
                {
                    g.CopyFromScreen(selection.Location, UpLeftDestination,selection.Size);
                    switch (target)
                    {
                        case OutputTarget.Clipboard:
                            Clipboard.SetImage(bmap);
                            break;
                        case OutputTarget.File:
                            SaveFileDialog diag = new SaveFileDialog();
                            // TODO : Change default directory
                            diag.InitialDirectory = diag.InitialDirectory == ""?GetPath(): diag.InitialDirectory;
                            diag.Filter = "Png Image (.png)|*.png|Bitmap Image (.bmp)|*.bmp|JPEG Image (.jepg)|*.jepg";
                            diag.DefaultExt = "*.png";
                            diag.FileName = Prefix + DateTime.Now.ToString("yyyyMMddhhmmss");
                            ImageFormat format = ImageFormat.Png;
                            if (diag.ShowDialog() == DialogResult.OK)
                            {
                                FileName = diag.FileName;
                                string ext = Path.GetExtension(FileName);
                                format = GetImageFormat(ext.Remove(0,1));

                                bmap.Save( FileName,format);                                    
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return true;
        }
        private static String GetPath()
        {
            return ConfigurationManager.AppSettings["DefaultDirectory"];
        }
        /// <summary>
        /// Convert string to ImageFormat
        /// </summary>
        /// <param name="format">Image format name</param>
        /// <example>
        /// <code>GetImageFormat("bmp")</code>
        /// </example>
        /// <returns>ImageFormat</returns>
        private static ImageFormat GetImageFormat(string format)
        {
            ImageFormat imageFormat = null;

            try
            {
                var imageFormatConverter = new ImageFormatConverter();
                imageFormat = (ImageFormat)imageFormatConverter.ConvertFromString(format);
            }
            catch (Exception e)
            {

                throw new FormatException();
            }

            return imageFormat;
        }
    }
}
