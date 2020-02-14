using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class SomethingHappenedSubscriber
    {
        public void SomethingHappenedHandler() //обработчик
        {
            // код обработки события
            Console.WriteLine("Subscriber has handled an event!");
        }
    }
}


