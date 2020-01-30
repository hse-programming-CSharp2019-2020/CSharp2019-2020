using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01
{
    delegate void MyEvent1(int n);
    class MyEvent
    {
        public event MyEvent1 Event1;
        public void OnEvent1(int n)
        {
            Event1?.Invoke(n);
        }
    }
    class Program
    {
        static void Main()
        {
            MyEvent ev = new MyEvent();
            ev.Event1 += (n) => Console.Write(n++ * 8);
            ev.OnEvent1(3);
            ev.OnEvent1(2);
            Console.ReadKey();
        }
    }
}
