using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task05
{
    public partial class Form1 : Form
    {
        CircleVizualizator cv;
        Circle c;
        public Form1()
        {
            InitializeComponent();
            c = new Circle(100);
            cv = new CircleVizualizator(pictureBox1, c);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.R = double.Parse(textBox1.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) cv.PenColor = Color.Black;
            else cv.PenColor = Color.Green;
            cv.Draw(sender, e);
        }
    }
    class Circle
    {
        double r;
        public event EventHandler RadiusChanged;
        public double R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
                OnRadiusChanged(EventArgs.Empty);
            }
        }
        public virtual void OnRadiusChanged(EventArgs e)
        {
            if (RadiusChanged != null) RadiusChanged(this, e);
        }
        public Circle(double rad)
        {
            if (rad <= 0) throw new ArgumentOutOfRangeException();
            r = rad;
        }
    }

    class CircleVizualizator
    {
        Circle c;
        System.Windows.Forms.PictureBox trq;
        Pen pen;
        public CircleVizualizator(System.Windows.Forms.PictureBox pb, Circle c)
        {
            trq = pb;
            pen = new Pen(Color.Black);
            this.c = c;
            c.RadiusChanged += Draw;
        }

        public Color PenColor
        {
            set
            {
                pen.Color = value;
            }
        }

        public void Draw(object obj, EventArgs e)
        {
            Graphics g = trq.CreateGraphics();
            g.Clear(Color.Gray);
            g.DrawEllipse(pen, 0, 0, (float)c.R, (float)c.R);
        }
        
    }
   
}
