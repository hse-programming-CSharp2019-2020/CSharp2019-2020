using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/iterators
namespace Example03
{
    class Program
    {
        static void Main()
        {
            foreach (int number in EvenSequence(5, 18))
            {
                Console.Write(number.ToString() + " ");
            }
            // Output: 6 8 10 12 14 16 18
            Console.ReadKey();
        }

        public static IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.
            for (int number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }
    }
}
