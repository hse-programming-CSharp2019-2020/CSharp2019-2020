using System;
using System.Collections.Generic;
using System.Text;

namespace Lib2
{
    public class ElectronicQueue
    {
        private Queue<Person> electronicQueue = new Queue<Person>();
        public void AddToElectronicQueue(Person p)
        {
            electronicQueue.Enqueue(p);
        }
        public string CallFromElectronicQueue()
        {
            string output = String.Empty;
            // получаем значение первого элемента очереди
            Person tmp = electronicQueue.Peek(); // исправить исключение!!!
            output = tmp.ToString();
            return output;
        }
        public void DeleteFromElectronicQueue()
        {
            electronicQueue.Dequeue(); // убирает первого из очереди
        }
    }

}
