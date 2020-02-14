using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    /// <summary>
    /// Класс-подписчик, где определен метод переноса строки
    /// </summary>
    class Subscriber
    {
        /// <summary>
        /// Переносит строку
        /// </summary>
        public static void LineBreakHappenedHandler()
        {
            Console.WriteLine(); //перенос строки
        }


        /// <summary>
        /// Выводит среднее значение элементов массива
        /// </summary>
        /// <param name="arr"></param>
        public static void AverageSumHandler(int[,] arr)
        {
            int sum = 0;
            int k = 0;//количество элементов
            for(int i = 0; i < arr.GetLength(0); i++)
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0) break;
                    k++;
                    sum += arr[i, j];
                }
            Console.WriteLine($"Среднее значение элементов массива = {(double)sum/k}");
        }

        /// <summary>
        /// Выводит максимальный элемент массива
        /// </summary>
        /// <param name="arr"></param>
        public static void MaxItemHandler(int[,] arr)
        {
            int max = 0; //максимальный элемент
            int k = 0;//количество элементов
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0) break;
                    k++;
                    if (arr[i, j] > max) max = arr[i, j];
                }
            Console.WriteLine($"Максимальный элемент массива = {max}");
        }
    }
}
