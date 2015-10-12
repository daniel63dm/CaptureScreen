using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace CaptureScreen
{
    class ScreenRectangle
    { 
        private static Form layer;
        /// <summary>
        /// Upper left point of the rectangle
        /// </summary>
        private static Point posO;
        private static Rectangle rectangle;
        private static Rectangle bordure;
        private static int epaisseurTrait = 5;

        private static bool Selecting = false;
        private static Pen penBack = new Pen(Color.White);

        /// <summary>
        /// Draw a rectangle on the screen
        /// </summary>
        /// <param name="parent">parent form</param>
        /// <returns>the drawn rectangle</returns>
        public static Rectangle Draw(Form parent)
        {
            // TODO : change it to real form for doubleBuffer
            // Create a transparent form on top of <frm>
            layer = new Layer();
    
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
            Size size = new Size(Math.Abs(posO.X - pos.X), Math.Abs(posO.Y - pos.Y));
            return new Rectangle(posO,size);
        }

        private static void MouseDown(object sender, MouseEventArgs e)
        {
                posO = Control.MousePosition;
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
            // Done
            Selecting = false;
            layer.Close();
        }
        /// <summary>
        /// Draw the rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PaintRectangle(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Red);

            if (Selecting)
            {
                Point pos = Control.MousePosition;
                using (Pen pen = new Pen(brush,epaisseurTrait))
                {
                    rectangle.Location = posO;
                    bordure.Location = posO;
                    rectangle.Width = Math.Abs(posO.X - pos.X);
                    rectangle.Height = Math.Abs(posO.Y - pos.Y);
                    bordure.Width = rectangle.Width;
                    bordure.Height = rectangle.Height;
                    e.Graphics.DrawRectangle(pen, rectangle);
                    e.Graphics.FillRectangle(penBack.Brush, rectangle);
                } 
            }
        }
    }

    class Layer : Form
    {
        public Layer()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.White;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size();
            this.Location = Point.Empty;
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.3D;
            this.DoubleBuffered = true;
        }
    }
}
