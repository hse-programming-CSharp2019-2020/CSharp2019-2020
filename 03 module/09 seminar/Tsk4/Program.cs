using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main()
        {
            using (FileStream inFi =
               new FileStream(@"..\..\Program.cs", FileMode.Open))
            {
                int t;      // числовое значение прочитанного байта
                int k = 0;  // позиция байта в потоке (в файле)
                while ((t = inFi.ReadByte()) != -1)
                {
                    if (t >= (int)'0' && t <= (int)'9')
                        Console.WriteLine(t + " - " + (char)t + " - " + k);
                    k++;
                }  
                Console.ReadLine();
            }    
        }   
    }
}
