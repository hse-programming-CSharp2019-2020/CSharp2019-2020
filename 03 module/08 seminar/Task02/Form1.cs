using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib2;

namespace Task02
{
    public partial class Form1 : Form
    {
        ElectronicQueue eq;

        public Form1()
        {
            InitializeComponent();
            eq = new ElectronicQueue(); // очередь пуста
                                        // загрузка элементов в очередь для примера
            eq.AddToElectronicQueue(new Person("Jabba", "Hutt", 604));
            eq.AddToElectronicQueue(new Person("Wedge", "Antille", 25));
            eq.AddToElectronicQueue(new Person("Han", "Solo", 33));
            eq.AddToElectronicQueue(new Person("Leia", "Organa", 23));
            eq.AddToElectronicQueue(new Person("Lando", "Calrissian", 35));
            eq.AddToElectronicQueue(new Person("Anakin", "Skywalker", 46));
            //
            timer1.Enabled = true; // запускаем очередь

        }

        private void button1_Click(object sender, EventArgs e)
        {
            eq.AddToElectronicQueue(new Person(textBox1.Text,
                  textBox2.Text, int.Parse(textBox3.Text)));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = eq.CallFromElectronicQueue();
            System.Media.SystemSounds.Exclamation.Play();
            // обновляем очередь
            eq.DeleteFromElectronicQueue();

        }
    }
}
