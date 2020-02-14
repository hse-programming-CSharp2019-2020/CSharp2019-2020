using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class Program
    {
        static Random rnd = new Random();

        /// <summary>
        /// Создает массив случайных целых чисел от 0 до 99
        /// </summary>
        /// <param name="m">число строк в массиве</param>
        /// <param name="n">число столбцов в массиве</param>
        /// <returns></returns>
        static int[,] CreateArray(int m, int n)
        {
            int[,] arr = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    arr[i, j] = rnd.Next(100);

            return arr;
        }

        /// <summary>
        /// Считывает целое положительное число, проверяет на корректность
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        static bool ReadInt(ref int k)
        {
            if(!int.TryParse(Console.ReadLine(), out k) || k<=0)
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
                int[,] arr = CreateArray(m, n);

                //Метод, который вызывает событие.
                Publisher.PrintArray(arr);
                Console.WriteLine("Для завершения работы нажмите Escape");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
