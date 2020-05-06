using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries

namespace Example02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
            Console.ReadKey();
        }
    }
}
