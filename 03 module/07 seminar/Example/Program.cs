using System;
class A
{
    public void B<T>() where T : struct
    {
        Console.Write(321);
    }
}

class D<E> : A where E : struct
{
    public void B<T>() where T : class
    {
        Console.Write(123);
    }
}

class Program
{
    static void Main(string[] args)
    {
        D<int> d = new D<int>();
        d.B<string>();
        A a = new A();
        a.B<int>();
        Console.ReadKey();
    }
}