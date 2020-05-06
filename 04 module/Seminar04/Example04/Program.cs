using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/iterators
namespace Example04
{
    class Program
    {
        static void Main()
        {
            DaysOfTheWeek days = new DaysOfTheWeek();
            int i = 0;
            foreach (string day in days)
            {
                Console.Write(day + " ");
                if (i == 2) break;
                i++;
            }
            Console.WriteLine("*********");
            foreach (string day in days)
            {
                Console.Write(day + " ");
            }
            // Output: Sun Mon Tue Wed Thu Fri Sat
            Console.ReadKey();
        }
    }
    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < days.Length; index++)
            {
                // Yield each day of the week.
                yield return days[index];
            }
        }
    }
}

