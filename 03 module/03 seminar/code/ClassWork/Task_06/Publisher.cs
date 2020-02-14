using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    public delegate void LineBreak(); //событийный делегат
    public delegate void Recalculate(int[,]arr);//делегат для второго события
    class Publisher
    {
        public static event LineBreak LineBreakHappened; //событие

        public static event Recalculate NewItemFilled;//Событие добавления нового элемента

        int m, n; //Размеры массива


        /// <summary>
        /// Устанавливает размеры массива
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public Publisher(int m, int n)
        {
            this.m = m;
            this.n = n;
        }

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

        static Random rnd = new Random();

        /// <summary>
        /// Создает массив случайных целых чисел от 1 до 99
        /// </summary>
        /// <param name="m">число строк в массиве</param>
        /// <param name="n">число столбцов в массиве</param>
        /// <returns></returns>
        public static int[,] CreateArray(int m, int n)
        {
            int[,] arr = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(1,100);
                    NewItemFilled(arr); //событие
                }

            return arr;
        }
    }
}
