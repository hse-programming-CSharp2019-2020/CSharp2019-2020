using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Program
    {
        static Random rnd = new Random();

        /// <summary>
        /// Создает массив случайных целых чисел от 0 до 99
        /// </summary>
        /// <param name="m">число строк в массиве</param>
        /// <returns></returns>
        static int[] CreateArray(int m)
        {
            int[] arr = new int[m];
            for (int i = 0; i < m; i++)
                arr[i] = rnd.Next(1, 100);

            return arr;
        }

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
            do
            {
                int m = 0;
                //Считываем количество строк.
                do
                {
                    Console.WriteLine("Введите число элементов в массиве. Целое положительное число.");
                } while (!ReadInt(ref m));

                try
                {
                    //Заполняем массив.
                    int[] arr = CreateArray(m);

                    //Создаем экземпляр класса Sorting.
                    Sorting sort = new Sorting(arr);

                    //Добавляем обработчики.
                    View count = new View();
                    sort.onSort += count.nShow;
                    sort.onSort += Display.BarShow;

                    //Сортируем.
                    sort.Sort();
                    Console.WriteLine(Environment.NewLine + $"В процессе сортировки всего произошло {sort.count} обменов");
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Слишком большой массив:(");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Не вышло, попробуйте ввести другое число");
                }
                Console.WriteLine("Для завершения программы нажмите Escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }

}
