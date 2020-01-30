using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImSorry
{
    class Program
    {
        delegate void del(int x);
        private static event del growth = p_1;
        private static void p_1(int y)
        {
            growth += (int z) => { Console.Write((int)z * z); };
        }
        static void Main(string[] args)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (i % 2 == 1)
                {
                    growth(i);
                }
            }
            Console.ReadKey();
        }
    }
}