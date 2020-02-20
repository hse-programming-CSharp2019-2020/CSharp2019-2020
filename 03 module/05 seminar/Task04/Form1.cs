using LibraryTask04Estimates;
using System;
using System.Windows.Forms;

namespace Task04
{
    public partial class Form1 : Form
    {
        public Form1()
        {    // конструктор умолчания
            InitializeComponent();
        }

        Form2 form2;    // ссылка на объект формы 2
        public bool flag = true; // флаг для формы 2
        Estimates estimate; // сылка на объект класса оценок

        private void Form1_Load(object sender, EventArgs e)
        {
            estimate = new Estimates();
            gen = new Random(); // генератор случайных чисел
        }

        int increment = 100;    // приращение выборки
        Random gen; // ссылка на генератор случайных чисел
                    // event handler

        private void PrintButtonClick(object sender, EventArgs e)
        {
            if (flag == true) // Чтобы формы не "размножались"
            {
                form2 = new Form2(this);
                flag = false;
            }
            button1.Text = "Увеличить выборку на " + increment.ToString();
            form2.Lab1 = "Размер выборки: " + estimate.Numb;
            form2.Lab2 = "Среднее: " + estimate.Average.ToString("F3");
            form2.Lab3 = "С. к. о.: " + estimate.Deviation.ToString("F3");
            form2.Lab4 = "xMin: " + estimate.Xmin.ToString("F3");
            form2.Lab5 = "xMax: " + estimate.Xmax.ToString("F3");
            form2.Show();
            for (int i = 0; i < increment; i++)
                estimate.add(gen.NextDouble());

        }
    }
}
