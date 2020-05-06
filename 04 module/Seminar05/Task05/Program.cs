using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    // Слова по алфавиту - нумеруемая коллекция, пригодная для LINQ:
    public class Words : IEnumerable<string[]>
    {
        string[] source; // Ссылка на исходный массив «слов»
        public Words(string[] source)
        {     // Конструктор
            this.source = source;
        }
        public System.Collections.Generic.IEnumerator<string[]>
            GetEnumerator()
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < letters.Length; i++)
            {
                string[] resAr = (from word in source
                                  where letters[i] == word[0]
                                  select word).ToArray();
                yield return resAr;
            }
        }   //  GetEnumerator<>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        { yield return "Заглушка!!!"; }
    }   // class Words

    class Program
    {
        static void Main()
        {
            string[] test = { "one", "two", "three", "four", "five", "zero" };
            Words words = new Words(test);
            Console.WriteLine("Названия цифр по алфавиту:");
            foreach (var item in words)
                foreach (var el in item)
                    Console.Write(el + "  ");
            Console.WriteLine();
            //.. Выберем из поcледовательности массив слов на букву 'f':
            var res = from s in words
                      where s.Length > 0 && s[0][0] == 'f'
                      select s;
            Console.WriteLine("Названия цифр на букву 'f':");
            foreach (var item in res)
                foreach (var el in item)
                    Console.WriteLine(el);
            Console.ReadKey();
            // Создадим объект, представляющий массивы ключевых слов:    
        }   // Main

    }
}
