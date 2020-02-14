using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task00
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
    class Input
    {
        public event EventHandler<StringEventArgs> UserInput;

        public void GetUserInput()
        {
            while (true)
            {
                Console.WriteLine(
                    "Type any characters or 'q' to quit end press Enter.");
                string input = Console.ReadLine();
                if (input.Trim() != "q")
                {
                    UserInput(this, new StringEventArgs(input));
                }
                else break;
            }
        }
    }
    class Program
    {
        public static void UserInputHadler(object o, StringEventArgs str)
        {
            Console.WriteLine("You Typed: " + str);
        }
        static void Main(string[] args)
        {
            Input input = new Input();

            input.UserInput += UserInputHadler;

            input.GetUserInput();

            Console.ReadKey();
        }
    }
}
