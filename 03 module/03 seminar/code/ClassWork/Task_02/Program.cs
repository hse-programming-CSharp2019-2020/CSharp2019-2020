using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // объект класса-издателя
            Publisher pub = new Publisher();

            // объект класса-подписчика
            SomethingHappenedSubscriber shs =
                new SomethingHappenedSubscriber();

            // добавляем подписчика к событию
            pub.somethingHappened += shs.SomethingHappenedHandler;

            // вызвали метод, запускающий событие
            pub.fireEvent();
        }
    }
}
