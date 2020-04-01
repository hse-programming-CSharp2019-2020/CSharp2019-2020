using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask1;

namespace Task1Add
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../MyTest.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл \"{0}\" не найден!", path);
                Console.ReadLine(); return;
            }
            // Таймер для профилирования фрагмента кода:
            System.Diagnostics.Stopwatch timer =
                        new System.Diagnostics.Stopwatch();
            timer.Start();
            string[] arrData = File.ReadAllLines(path);
            List<ColorPoint> list = new List<ColorPoint>();
            int N = arrData.Length; // Количество строк в файле   
            for (int i = 0; i < N; i++)
            {
                string s = arrData[i];   //  
                list.Add(ColorPoint.GetObj(s));    // TODO: разработать GetObj(s)  - 
                                        // статический метод разбора строки и создания объекта ColorPoint:
            }
            timer.Stop();

            foreach (ColorPoint l in list)
                Console.WriteLine(l.ToString());

            Console.WriteLine("Прочитаны {0} строк из файла: \n{1}", N, path);
            Console.WriteLine("Метод: ReadAllLines \nВремя обработки: {0}", timer.Elapsed);
            Console.WriteLine("Время в миллисекундах: {0}", timer.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
