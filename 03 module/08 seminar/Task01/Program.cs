using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        // Из стандарта: 
        static T maximum<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
            //return a > b ? a : b;    //ERROR
        }
        static void Main()
        {
            char p = 'e', q = 'z';
            Console.WriteLine("maximum(p,q) = " + maximum(p, q));
            Console.WriteLine("maximum(3,8) = " + maximum(3, 8));
            Console.WriteLine("maximum() = " +
                         maximum("abcd", "1234"));
            Console.WriteLine("maximum(5L,2L) = " + maximum(5L, 2L));
            Console.ReadKey();
        }
    }
}
