using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_03
{
    public delegate void Del(object sender, EventArgs e);//создали делегат
    public partial class Form1 : Form
    {
        public event Del OnMouseEnter;
        public event Del OnMouseClick;
        public event Del OnMouseDoubleClick;

        static int counter;//количество входов мыши в форму

        static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            //Обработчик на вход мыши в видимую часть формы.
            this.OnMouseEnter += (object sender, EventArgs e) =>
            {
                this.BackColor = Form.DefaultBackColor;
                this.Text = ("My Form " + counter++);
            };

            //Обработчик на клик мыши.
            this.OnMouseClick += (object sender, EventArgs e) =>
            {
                this.BackColor = Color.Red;
            };
            //Обработчик на двойной клик мыши.
            this.OnMouseDoubleClick += (object sender, EventArgs e) =>
            {
                this.Size = new System.Drawing.Size(rnd.Next(100,1001), rnd.Next(100, 1001));
            };

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(sender, e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(sender, e);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(sender, e);
        }
    }
}
