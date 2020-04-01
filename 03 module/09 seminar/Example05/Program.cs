using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* File
ReadAllText(). Самая простая операция — это прочитать файл целиком. 
    Данный метод является статическим. Здесь в качестве параметра можно указать полный путь к 
    файлу. Когда указываем путь к файлу, не забываем экранировать символ "\".
ReadAllLines(). Этот статический метод возвращает массив строк, т.е. читает файл построчно.
WriteAllText(). Здесь в качестве параметра передаём строку, и эта строка целиком 
    добавляется в файл с перезаписью содержимого файла.
AppendAllText(). Здесь содержимое добавляется поверх существующего файла, без его перезаписи.
*/

namespace Example05
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\cities.txt";

            string allText = File.ReadAllText(path);
            Console.WriteLine(allText);

            Console.WriteLine("**********");

            string[] allLines = File.ReadAllLines(path);
            foreach(string str in allLines)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("**********");
            File.AppendAllText(path, "\nRim");

            allLines = File.ReadAllLines(path);
            foreach (string str in allLines)
            {
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }
    }
}
