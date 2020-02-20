using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask01;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Circle> list = new List<Circle>();
            Point p0 = new Point(0, 0); // начало координат
            Circle ct; // ссылка на очередной объект, вводимый с клавиатуры  
            do
            {
                double r = 0, x = 0, y = 0;

                do Console.Write("Введите X:  ");
                while (!double.TryParse(Console.ReadLine(), out x));

                do Console.Write("Введите Y:  ");
                while (!double.TryParse(Console.ReadLine(), out y));

                do Console.Write("Введите радиус:  ");
                while (!double.TryParse(Console.ReadLine(), out r) || r <= 0);

                ct = new Circle(x, y, r);
                list.Add(ct);
                // Сортируем список (в обратном порядке):
                list.Sort(delegate (Circle c1, Circle c2) {
                    double dis1 = p0.Distance(c1.center) * c1.Rad;
                    double dis2 = p0.Distance(c2.center) * c2.Rad;
                    if (dis1 > dis2) return -1;
                    if (dis1 < dis2) return +1;
                    return 0;
                });
                //.. Выводим элементы списка:
                foreach (Circle cir in list)
                    Console.WriteLine(cir.ToString());
                Console.WriteLine("Для завершения работы нажмите Escape ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
