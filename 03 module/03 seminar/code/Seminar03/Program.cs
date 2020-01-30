using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar03
{
    class Example
    {
        public delegate void MyDelegate();
        public MyDelegate myDelegate;
        public event MyDelegate myEvent;

        public void raiseEvent()
        {
            myEvent?.Invoke();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
            ex.myEvent += () => Console.WriteLine("1");
            ex.raiseEvent();
            //ex.myDelegate = () => Console.WriteLine("2");
            //ex.myDelegate();
            Console.ReadKey();
        }
    }
}
