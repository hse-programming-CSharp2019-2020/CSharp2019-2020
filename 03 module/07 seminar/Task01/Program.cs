using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task01
{
    class TestClass : IComparable
    { // тестовый класс
        public int X { get; set; }
        public int CompareTo(Object another)
        {
            if (this.X > ((TestClass)another).X) return 1;
            else if (this.X < ((TestClass)another).X) return -1;
            return 0;
        }
    }
    struct TestStruct : IComparable
    { // тестовая структура
        public int x;
        public int CompareTo(Object another)
        {
            if (this.x > ((TestStruct)another).x) return 1;
            else if (this.x < ((TestStruct)another).x) return -1;
            return 0;
        }
    }

    class Program
    {
        public static Random rnd = new Random();
        private const int N = 100000;
        public static void PrintTime(TimeSpan timesp)
        {
            Console.WriteLine("Struct time");

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                      timesp.Hours, timesp.Minutes, timesp.Seconds,
                      timesp.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
        static void Main(string[] args)
        {
            TestClass[] tc = new TestClass[N]; // 
            TestStruct[] ts = new TestStruct[N]; // 
            for (int i = 0; i < N; i++)
            {
                tc[i] = new TestClass();
                int tmp = rnd.Next();
                tc[i].X = tmp;
                ts[i].x = tmp;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Array.Sort(ts); // сортируем массив структур
            sw.Stop(); PrintTime(sw.Elapsed);
            sw.Start();
            Array.Sort(tc); // сортируем массив объектов классов
            sw.Stop(); PrintTime(sw.Elapsed);
            Console.ReadKey();
        }
    }
}
