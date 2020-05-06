using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    // Блок итератора в коллекции. Возвращает члены ряда Фибоначчи.
    class Fibbonacci
    {
        int s = 1, n = 0;
        public System.Collections.IEnumerable nextMemb(int limit)
        {
            int t;
            for (int i = 0; i < limit; i++)
            {
                t = s + n;
                s = n;
                yield return n = t;
                /*
                t = s + n;
                s = n;
                yield return n = t;

                if (i == limit - 1)
                {
                    s = 1;
                    n = 0;
                }
                */
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Fibbonacci fi = new Fibbonacci();
            foreach (int numb in fi.nextMemb(7))
                Console.Write(numb + "  ");
            Console.WriteLine();

            foreach (int numb in fi.nextMemb(7))
                Console.Write(numb + "  ");
            Console.WriteLine();
            Console.ReadKey();

        } // end of Main()
    } // end of Program

}
