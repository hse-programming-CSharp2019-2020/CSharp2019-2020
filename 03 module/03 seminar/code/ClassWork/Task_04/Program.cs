using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_04;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI c = new ConsoleUI();
            c.CreateUI(); // запускаем выполнение объекта класса ConsoleUI
            do
            {
                c.GetStringFromUI();  // изменяем значение строки
                Console.WriteLine("Чтобы закончить эксперименты, нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
