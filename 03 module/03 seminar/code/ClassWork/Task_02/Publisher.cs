using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    public delegate void EventHappened(); //событийный делегат
    class Publisher
    {
        public event EventHappened somethingHappened; //событие
        public void fireEvent()
        {
            Console.WriteLine("Fire somethingHappened!!!");
            somethingHappened(); // вызываем событие только из этого метода
        }
    }
}
