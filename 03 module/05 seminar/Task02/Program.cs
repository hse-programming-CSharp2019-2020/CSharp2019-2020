using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask02Figures;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleComp tri = new TriangleComp(0, 0, 2, 4, 5, 0);
            double xt, yt;
            ConsoleKeyInfo key; // Нажатая пользователем клавиша
            do
            {
                do Console.Write("Абсцисса точки: ");
                while (!double.TryParse(Console.ReadLine(), out xt));
                do Console.Write("Ордината точки: ");
                while (!double.TryParse(Console.ReadLine(), out yt));
                Point point = new Point(xt, yt);
                if (tri.check(point))
                    Console.WriteLine("Точка принадлежит треугольнику!");
                else Console.WriteLine("Точка вне треугольника!");
                Console.WriteLine("Для выхода нажмите клавишу ESC");
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Escape);

        }
    }
}
