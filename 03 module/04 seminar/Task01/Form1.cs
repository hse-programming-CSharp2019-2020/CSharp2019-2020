using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Form1 : Form
    {
        string result;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Text = "Form1_Activated";
            result += "\nActivated";

        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Text = "Form1_Deactivate";
            result += "\nDeactivate";

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Text = "Form1_FormClosed";
            result = "События в жизни формы: " + result;
            MessageBox.Show(result + "\nFormClosed");

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Text = "Form1_FormClosing";
            result += "\nFormClosing";
            MessageBox.Show("Событие FormClosing");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Form1_Load";
            result += "\nLoad";
            MessageBox.Show("Событие Load");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.Text = "Form1_Paint";
            result += "\nPaint";
            MessageBox.Show("Событие Paint");

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Text = "Form1_Resize";
            result += "\nResize";
            MessageBox.Show("Событие Resize");

        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
