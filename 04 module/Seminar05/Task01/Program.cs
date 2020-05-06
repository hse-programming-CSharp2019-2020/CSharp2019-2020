using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main()
        {
            string[] names = { "Маша", "Вася", "Наташа",
                             "Петя", "Ира", "Даня"};
            Array.ForEach(names, Console.WriteLine);
            Console.WriteLine("=======================");
            IEnumerable<string> namesWithSh = from g in names
                                              where g.Contains("ш")
                                              select g;
            foreach (string str in namesWithSh)
                Console.Write(str + " ");
            Console.ReadKey();
        }
    }

}
