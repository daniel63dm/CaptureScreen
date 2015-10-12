using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace CaptureScreen
{
    class ScreenRectangle
    { 
        private static Form layer;
        private static Point PosO;
        private static Rectangle rectangle;
        private static Rectangle bordure;
        private static int epaisseurTrait = 5;

        private static bool Selecting = false;
        private static Pen penBack = new Pen(Color.White);

        public static Rectangle Draw(Form parent)
        {
            // TODO : change it to real form for doubleBuffer
            // Create a transparent form on top of <frm>
            layer = new Form();
            layer.FormBorderStyle = FormBorderStyle.None;
            layer.BackColor = Color.Gray;
            layer.TransparencyKey = Color.White;
            layer.ShowInTaskbar = false;
            layer.StartPosition = FormStartPosition.Manual;
            layer.Size = parent.ClientSize;
            layer.Location = Point.Empty;
            layer.WindowState = FormWindowState.Maximized;
            layer.Opacity = 0.3D;           
            layer.MouseMove += MouseMove;
            layer.MouseDown += MouseDown;
            layer.MouseUp += MouseUp;
            layer.Paint += PaintRectangle;
            layer.Load += DoCapture;
            
            // Display the overlay
            layer.ShowDialog(parent);
            // Clean-up and calculate return value
            layer.Dispose();
            layer = null;
            Point pos = Control.MousePosition;
            Selecting = false;
            Size size = new Size(Math.Abs(PosO.X - pos.X), Math.Abs(PosO.Y - pos.Y));
            return new Rectangle(PosO,size);
        }

        private static void MouseDown(object sender, MouseEventArgs e)
        {
                PosO = Control.MousePosition;
                Selecting = true;
        }

        private static void DoCapture(object sender, EventArgs e)
        {
            // Grab the mouse
            layer.Capture = true;
        }
        private static void MouseMove(object sender, MouseEventArgs e)
        {
            // Repaint if selecting
            if (Selecting)
                layer.Invalidate();
        }
        private static void MouseUp(object sender, MouseEventArgs e)
        {
            // Done, close mask
            Selecting = false;
            layer.Close();
        }
        private static void PaintRectangle(object sender, PaintEventArgs e)
        {
            // Draw
            // TODO : Couleur de fond plus blanche/gris très clair
            // TODO : Eclaircir la zone de selection
            Brush brush = new SolidBrush(Color.Red);

            if (Selecting)
            {
                Point pos = Control.MousePosition;
                using (Pen pen = new Pen(brush,epaisseurTrait))
                {
                    rectangle.Location = PosO;
                    bordure.Location = PosO;
                    rectangle.Width = Math.Abs(PosO.X - pos.X);
                    rectangle.Height = Math.Abs(PosO.Y - pos.Y);
                    bordure.Width = rectangle.Width;
                    bordure.Height = rectangle.Height;
                    e.Graphics.DrawRectangle(pen, rectangle);
                    e.Graphics.FillRectangle(penBack.Brush, rectangle);
                } 
            }
        }
    }
}
