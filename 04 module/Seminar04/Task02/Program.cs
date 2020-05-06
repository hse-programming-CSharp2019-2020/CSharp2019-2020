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
            foreach (string color in colors)
                Console.Write(color);
            Console.WriteLine();

            //.. Второе обращение к тому же объекту:
            foreach (string color in colors)
                Console.Write(color);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
