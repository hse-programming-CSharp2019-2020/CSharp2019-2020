using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class Rainbow : IEnumerable<string>
    {
        public System.Collections.Generic.IEnumerator<string>
            GetEnumerator()
        {
            yield return "каждый ";
            yield return "охотник ";
            yield return "желает ";
            yield return "знать ";
            yield return "где ";
            yield return "сидит ";
            yield return "фазан ";
        }
        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        { yield return "Заглушка!!!"; }
    }	// class Rainbow

    class Program
    {
        static void Main()
        {
            Rainbow colors = new Rainbow();
            Console.WriteLine("Исходная последовательность:");
            foreach (string color in colors)
                Console.Write(color);

            Console.WriteLine("\nВыборка коротких слов:");
            var u = from z in colors
                    where z.Length <= 6
                    select z;
            foreach (string color in u)
                Console.Write(color);
            Console.WriteLine("\nСлова упорядочены по длинам:");
            IEnumerable<string> seq = from b in colors
                                      orderby b.Length
                                      select b;
            foreach (string color in seq)
                Console.Write(color);

            Console.WriteLine("\nСлова упорядочены по алфавиту:");
            IEnumerable<string> pre = from b in colors
                                      orderby b.ToString()
                                      select b;
            foreach (string color in pre)
                Console.Write(color);

            Console.WriteLine("\nДля выхода нажмите ENTER...");
            Console.ReadLine();

        }

    }
}
