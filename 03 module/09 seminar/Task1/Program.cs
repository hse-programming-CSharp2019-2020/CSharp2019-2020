using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask1;

namespace Task1
{
    class Program
    {
        static Random gen = new Random();
        public static void Main()
        {
            string path = @"../../../MyTest.txt";
            int N = 10;
            List<ColorPoint> list = new List<ColorPoint>(); ColorPoint one;
            for (int i = 0; i < N; i++)
            {
                one = new ColorPoint();
                one.x = gen.NextDouble();
                one.y = gen.NextDouble();
                int j = gen.Next(0, ColorPoint.colors.Length);
                one.color = ColorPoint.colors[j];
                list.Add(one);
            }
            string[] arrData = Array.ConvertAll(list.ToArray(),
                         (ColorPoint cp) => cp.ToString());
            // Запись массива стpок в текстовый файл:         
            File.WriteAllLines(path, arrData);
            Console.WriteLine("Записаны {0} строк в текстовый файл: \n{1}", N, path);
            Console.ReadKey();
        }
    } 
}