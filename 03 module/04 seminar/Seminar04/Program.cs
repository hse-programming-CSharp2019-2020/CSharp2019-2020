using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar04
{
    class StringEventArgs : EventArgs
    {
        string s;
        public StringEventArgs(string str)
        {
            s = str;
        }
        public override string ToString()
        {
            return s;
        }
    }
    class Publisher
    {
        public event EventHandler<StringEventArgs> BeginOutput;
        public event EventHandler<StringEventArgs> EndOutput;
        public void Display(string message)
        {
            OnBeginOutput();
            Console.WriteLine(message);
            OnEndOutput();
        }
        private void OnBeginOutput()
        {
            if (BeginOutput != null)
                BeginOutput(this, new StringEventArgs("Starting output"));
        }
        private void OnEndOutput()
        {
            if (EndOutput != null)
                EndOutput(this, new StringEventArgs("Ending output"));
        }

    }   // class Publisher

    class Program
    {
        static void StartOutputCallBack(object o, StringEventArgs message)
        {
            Console.WriteLine("StartOutputCallBack - " + message);
        }
        static void EndOutputCallBack(object o, StringEventArgs message)
        {
            Console.WriteLine("EndOutputCallBack - " + message);
        }

        static void Main()
        {
            Publisher publisher = new Publisher();
            
            publisher.BeginOutput += StartOutputCallBack;
            publisher.EndOutput += EndOutputCallBack;

            publisher.Display("I am a subscriber!");

            publisher.BeginOutput -= StartOutputCallBack;
            publisher.EndOutput -= EndOutputCallBack;
            publisher.Display("\nI am not a subscriber!");

            Console.ReadKey();
        }
    }

}
