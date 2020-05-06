using System;
using System.Linq;  // Select, Aggregate
using System.Collections.Generic;   // IEnumerable<T>
namespace LINQ_5
{
    class Program_5
    {
        // Рекурсивная функция подсчета суммы цифр числа:
        static public uint figSum(uint k)
        {
            if (k / 10 == 0) return k;
            return figSum(k / 10) + k % 10;
        }
        // Обобщенная функция печати элементов последовательности:
        static void printSeries<T>(IEnumerable<T> ser)
        {
            var line = ser.Select(x => x.ToString()).
                    Aggregate((a, b) => a + "\t" + b);
            Console.WriteLine(line);
        }

        static void Main()
        {
            uint[] row = { 543, 67, 234, 765 };
            Console.WriteLine("Исходный массив:");
            printSeries(row);
            Console.WriteLine("Суммы цифр элементов массива: ");
            var series = row.Select(x => figSum(x));
            printSeries(series);
            var res = series.Sum(x => x);
            Console.WriteLine("Общая сумма цифр = " + res);
            Console.ReadKey();
        }

    }   // Program_5
}   // LINQ_5
