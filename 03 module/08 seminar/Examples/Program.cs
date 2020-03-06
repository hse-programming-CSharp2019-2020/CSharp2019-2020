using System;
class D<E> 
{
    E F { set; get; }

    public D()
    {
        F = default(E);
    }
    public D(E d)
    {
        F = d;
    }
}

class C<A, B>
{
    public A First { set; get; }
    public B Second { set; get; }
}
class AA<T> where T : class, System.Enum, ICloneable { }

class Program
{
    static void Main(string[] args)
    {
        C<D<string>, 
            int> c = new C<D<string>, int>();
        c.First = new D<string>("25");
        c.Second = 25;
        Console.Write(c.Second + c.First.ToString());
        Console.ReadKey();
    }
}
