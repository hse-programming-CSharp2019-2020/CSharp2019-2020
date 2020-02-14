using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    public delegate void LineBreak(); //событийный делегат
    class Publisher
    {
        public static event LineBreak LineBreakHappened; //событие

        /// <summary>
        /// Выводит массив с использованием события для переноса строки
        /// </summary>
        /// <param name="arr">массив, который нужно вывести</param>
        public static void PrintArray(int[,] arr)
        {
            int n = 0; //номер элемента
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                    n++; //изменяем номер элемента

                    //В условии сказано, что надо выводить по 5 элементов в строке,
                    // независимо от количества строк в матрице!
                    if (n % 5 == 0) LineBreakHappened(); //вызываем событие
                }
            }
        }
    }
}
