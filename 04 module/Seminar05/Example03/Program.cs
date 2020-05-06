using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/linq/standard-query-operators-overview

namespace Example03
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "the quick brown fox jumps over the lazy dog";
            // Split the string into individual words to create a collection.  
            string[] words = sentence.Split(' ');

            // Using query expression syntax.  
            var query = from word in words
                        group word.ToUpper() by word.Length into gr
                        orderby gr.Key
                        select new { Length = gr.Key, Words = gr };

            foreach (var obj in query)
            {
                Console.WriteLine("Words of length {0}:", obj.Length);
                foreach (string word in obj.Words)
                    Console.WriteLine(word);
            }
            Console.ReadKey();
        }
    }
}
