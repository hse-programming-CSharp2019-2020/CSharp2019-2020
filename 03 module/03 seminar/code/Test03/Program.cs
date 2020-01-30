using System;
namespace Task
{
    class MyEventArgs : EventArgs
    {
        public MyEventArgs() : base() { }
    }
    class Program
    {
        static event EventHandler OnEvent;
        static void Main(string[] args)
        {
            Program pr = new Program();
            OnEvent += MyMethod;
            OnEvent(pr, EventArgs.Empty);
            Console.ReadKey();
        }
        static void MyMethod(object sender, MyEventArgs args)
        {
            Console.WriteLine("This is my method!");
        }
    }
}