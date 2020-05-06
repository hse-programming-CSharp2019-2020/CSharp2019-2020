using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Rainbow
    {   // Радуга
        public System.Collections.IEnumerator GetEnumerator()
        {
            yield return "каждый ";
            yield return "охотник ";
            yield return "желает ";
            yield return "знать ";
            yield return "где ";
            yield return "сидит ";
            yield return "фазан ";
        }
    }
    class Program
    {
        static void Main()
        {
            Rainbow colors = new Rainbow();
            int i = 0;
            foreach (string color in colors)
            {
                if (++i % 3 == 0) break;
                Console.Write(color);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
