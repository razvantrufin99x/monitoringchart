using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace monitoringchart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Graphics g;
        public Font font0;
        public Pen pen0 = new Pen(Color.Black);
        public Pen pen1 = new Pen(Color.Black, 7);
        public Pen pen2 = new Pen(Color.Red, 8);
        public Brush brush0 = new SolidBrush(Color.Black);
        public float cx, cy, px, py;
        public float step = 5.0f;
        public const double g2r = 180 / Math.PI;
        public int ismd = 0;
        public int su = 0;
        public int eu = 100;


        private void Form1_Load(object sender, EventArgs e)
        {
            font0 = this.Font;
            g = pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        public int calculatecos(int x)
        {
            return (int)Math.Cos(x/57.4)*100+25;
        }
        public int calculatesin(int x)
        {
            return (int)Math.Sin(x / 57.4) * 100 + 25;
        }
        public void drawloadingprogressbar()
        {
            g.Clear(BackColor);
            for (int i = 0; i < 100; i += 10)
            {
                g.DrawLine(pen2, i + 10, 2 / calculatecos(i), i + 20, 1 / calculatecos(i - 1) + 50);
                Thread.Sleep(50);
            }
        }

        public void drawloadingprogressbarsin()
        {
            g.Clear(BackColor);
            for (int i = 0; i < 100; i += 10)
            {
                g.DrawLine(pen2, i + 10, 2 / calculatesin(i), i + 20, 1 / calculatesin(i - 1) + 50);
                Thread.Sleep(5);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //drawloadingprogressbar();
            drawloadingprogressbarsin();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismd == 1)
            {
                Left += e.X;
                Top += e.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = 1;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
