// Анонимные типы, выражение LINQ-запроса, 
using System;
using System.Linq;

namespace LINQ_6
{
    class Program_6
    {
        // Рекурсивная функция выделения цифр числа:
        static public string figures(uint k)
        {
            if (k / 10 == 0) return k.ToString();
            else return figures(k / 10) + " " + k % 10;
        }
        static void Main()
        {
            var numbers = new[] {
                new {value = 0, name = "нуль"},
                new {value = 1, name = "один"},
                new {value = 2, name = "два"},
                new {value = 3, name = "три"},
                new {value = 4, name = "четыре"},
                new {value = 5, name = "пять"},
                new {value = 6, name = "шесть"},
                new {value = 7, name = "семь"},
                new {value = 8, name = "восемь"},
                new {value = 9, name = "девять"}
                };

            Console.WriteLine("Объекты анонимного типа:");
            foreach (var rec in numbers)
                Console.WriteLine(rec);
            do
            {  // цикл для повторения решения
                uint numb;
                do Console.Write("Введите целое не отрицательное число: ");
                while (!uint.TryParse(Console.ReadLine(), out numb));
                var res = (from f in figures(numb).Split(' ')
                           from n in numbers
                           where n.value.ToString() == f
                           select n.name).Aggregate((x, y) => x.ToString() +
                                                            "+" + y.ToString());
                Console.WriteLine("Названия цифр числа: \n" + res);
                Console.WriteLine("Для выхода нажмите клавишу ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}