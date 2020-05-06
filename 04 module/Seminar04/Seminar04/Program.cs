using System;
using System.Collections;
using System.Collections.Generic;

class MainClass
{
    public static void Main(string[] args)
    {
        Stack stack = new Stack();
        /*
        for (int i = 0; i < 5; i++)
            stack.Push(i ^ 2);

        Console.Write(stack.Count);

        for (int i = 0; i < stack.Count; i++)
            Console.Write(stack.Pop());
            */

        Stack<string> numbers = new Stack<string>();
        numbers.Push("one");
        numbers.Push("two");

        for (int i = 0; i < numbers.Count; i++)
            Console.WriteLine(numbers.Pop());

        Console.ReadKey();
    }
}