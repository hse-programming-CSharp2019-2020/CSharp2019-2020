using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib5;

namespace Task05
{
    class Program
    {
        static void Main()
        {
            MassPoint[] elements;
            int N; // количество точек на плоскости
            Random gen = new Random(0);
            do Console.Write("Введите количество точек на плоскости: ");
            while (!int.TryParse(Console.ReadLine(), out N) || N < 1);
            elements = new MassPoint[N];
            for (int i = 0; i < elements.Length; i++)
            {
                PointS ps = new PointS(gen.Next(-10, 11), gen.Next(-10, 11));
                elements[i] = new MassPoint(ps, gen.Next(1, 6));
                Console.WriteLine(elements[i].ToString());
            }
            SetOfMassPoint real;
            do
            {
                double R = 0;
                do Console.Write("Введите радиус множества: ");
                while (!double.TryParse(Console.ReadLine(), out R) || R <= 1);
                real = new SetOfMassPoint(elements, new PointS(0, 0), R);
                Console.WriteLine(real.ToString());
                Console.WriteLine(real.MassCenter.ToString());
                Console.WriteLine("Для завершения работы нажмите Escape ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
