using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            string path = @"..\..\test.txt";
            string path2 = @"..\..\test2.txt";
            string path3 = @"..\..\test3.txt";
            int N = 20;
            string[] numbers = new string[N];

            for (int i = 0; i < N; i++)
            {
                numbers[i] = rnd.Next(-20, 21).ToString();
            }

            File.WriteAllLines(path, numbers);

            string[] readNumbers = File.ReadAllLines(path);
            string even = "";
            string odd = "";

            for (int i = 0; i < N; i++)
            {
                if (int.Parse(readNumbers[i]) % 2 == 0) // нельзя так делать!
                    even += Environment.NewLine + readNumbers[i];
                else 
                    odd += Environment.NewLine + readNumbers[i];
            }

            File.WriteAllText(path2, even);
            File.WriteAllText(path3, odd);

            Console.ReadKey();
        }
    }
}
