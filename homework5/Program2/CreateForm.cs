using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
            pen.Width = 1.8f;
        }
        public void Draw()
        {
            if (graphics == null)
            {
                graphics = this.CreateGraphics();
            }
            drawCayleyTree(12, 300, 480, 150, -Math.PI / 2);
        }
        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        private Graphics graphics;
        public static double th1 = 30 * Math.PI / 180;
        public static double th2 = 20 * Math.PI / 180;
        public static double per1 = 0.6;
        public static double per2 = 0.7;
        public static double k = 0.91;
        public static Pen pen = new Pen(Color.Pink);
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + k * leng * Math.Cos(th);
            double y2 = y0 + k * leng * Math.Sin(th);
            if (k > 1)
            {
                drawLine(x0, y0, x2, y2);
            }
            else
            {
                drawLine(x0, y0, x1, y1);
            }
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
    }
}
