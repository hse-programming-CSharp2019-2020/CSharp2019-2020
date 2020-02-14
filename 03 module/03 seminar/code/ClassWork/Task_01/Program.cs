using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    delegate void Del();//событийный делегат
    
    class Program
    {
        static event Del Ev; //событие

        //Набор функция-обработчиков
        static void f1()
        {
            Console.WriteLine("f1");
        }
        static void f2()
        {
            Console.WriteLine("f2");
        }
        static void f3()
        {
            Console.WriteLine("f3");
        }


        static void Main(string[] args)
        {
            //добавляем обработчики
            Ev += f1;
            Ev += f2;
            Ev += f3;
            Ev(); //Вызываем событие
        }
    }
}
