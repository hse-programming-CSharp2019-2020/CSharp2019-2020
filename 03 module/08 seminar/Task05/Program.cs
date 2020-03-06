using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class MyStack<T>
    {
        const int MaxStack = 10;    // предельный размер стека
        T[] StackArray;     // массив для элементов
        int StackPointer = 0;   // число элементов в стеке
        public MyStack() { StackArray = new T[MaxStack]; }
        bool IsStackFull { get { return StackPointer >= MaxStack; } }
        bool IsStackEmpty { get { return StackPointer <= 0; } }
        public void Push(T x)
        { // Поместить в стек элемент
            if (!IsStackFull)
                StackArray[StackPointer++] = x;
        }
        public T Pop()
        {    // Получить элемент из стека
            return (!IsStackEmpty)
            ? StackArray[--StackPointer]
            : StackArray[0];
        }
        public void Print()
        {   // Распечатать элементы стека 
            for (int i = StackPointer - 1; i >= 0; i--)
                Console.WriteLine(" Value: {0}", StackArray[i]);
        }
    } //MyStack

    class Program
    {
        static void Main()
        {
            var stackInt = new MyStack<int>();
            var stackString = new MyStack<string>();
            stackInt.Push(3); stackInt.Push(5); stackInt.Push(7);
            stackInt.Print();
            stackString.Push("Generics are great!");
            stackString.Push("Hi there! ");
            stackString.Print();
            Console.ReadKey();
        }
    }
}
