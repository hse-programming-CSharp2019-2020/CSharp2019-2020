using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    class Program
    {
        /// <summary>
        /// Считывает целое положительное число, проверяет на корректность
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        static bool ReadInt(ref int k)
        {
            if (!int.TryParse(Console.ReadLine(), out k) || k <= 0)
            {
                Console.WriteLine("Вы ввели недопустимое значение");
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            //Добавляем обработчики.
            Publisher.LineBreakHappened += Subscriber.LineBreakHappenedHandler;
            Publisher.NewItemFilled += Subscriber.AverageSumHandler;
            Publisher.NewItemFilled += Subscriber.MaxItemHandler;

            do
            {
                int m = 0, n = 0;
                //Считываем количество строк.
                do
                {
                    Console.WriteLine("Введите число строк в массиве. Целое положительное число.");
                } while (!ReadInt(ref m));
                //Считываем количество столбцов.
                do
                {
                    Console.WriteLine("Введите число столбцов в массиве. Целое положительное число.");
                } while (!ReadInt(ref n));

                //Заполняем массив.
                int[,] arr = Publisher.CreateArray(m, n);

                //Метод, который вызывает событие.
                Publisher.PrintArray(arr);

                Console.WriteLine("Для завершения работы нажмите Escape");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
