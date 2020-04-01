using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test string ONE");
            // перенаправляем стандартный поток записи - в файл
            using (FileStream fs = new FileStream("ProgOutPut.txt",
                            FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fs);
                Console.SetOut(sw);
                Console.WriteLine("Test string TWO");
                sw.Flush();
            }
            // восстановление стандартного потока вывода
            StreamWriter stdOutPut = new StreamWriter(Console.OpenStandardOutput());
            stdOutPut.AutoFlush = true;
            Console.SetOut(stdOutPut);
            Console.WriteLine("Test string THREE");
            Console.WriteLine("Test string FOUR");
            Console.ReadLine();
        }
    }
}
