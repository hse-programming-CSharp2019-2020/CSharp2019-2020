using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_04
{
    public delegate void NewStringValue(string s);

    public class UIString
    {
        string str = "Default text";
        public string Str { get { return str; } set { str = value; } }

        public void NewStringValueHappenedHandler(string s) //обработчик события
        {
            str = s;
        }
    }

    public class ConsoleUI
    {
        public event NewStringValue NewStringValueHappened; //объявление делегата

        UIString sub = new UIString();
        public void GetStringFromUI()
        {
            Console.WriteLine("Введите новое значение строки");
            NewStringValueHappened(Console.ReadLine());
            RefreshUI();
        }
        public void CreateUI()
        {

            NewStringValueHappened += sub.NewStringValueHappenedHandler; //добавили обработчик к событию
            RefreshUI();
        }
        public void RefreshUI()
        {      // обновление строки     
            Console.Clear();
            Console.WriteLine("Текст строки: " + sub.Str);
        }

    }
}
