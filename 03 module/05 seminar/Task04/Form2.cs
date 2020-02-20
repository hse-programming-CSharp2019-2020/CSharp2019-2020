using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task04
{
    public partial class Form2 : Form
    {
        public Form2() { InitializeComponent(); }
        public string Lab1 { set { this.label1.Text = value; } }
        public string Lab2 { set { this.label2.Text = value; } }
        public string Lab3 { set { this.label3.Text = value; } }
        public string Lab4 { set { this.label4.Text = value; } }
        public string Lab5 { set { this.label5.Text = value; } }
        Form1 sender; // Ссылка на создавшую форму
        public Form2(Form1 author) : this() { sender = author; }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.sender.flag = true;
        }

    }
}
