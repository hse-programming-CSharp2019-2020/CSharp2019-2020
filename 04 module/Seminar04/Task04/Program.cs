using System;
using System.Collections;
public class Evens
{
    int Nmin, Nmax;
    public Evens(int mi, int ma)
    { // конструктор
        if (mi >= ma) throw new Exception("Error!");
        Nmin = mi; Nmax = ma;
    }
    public IEnumerator GetEnumerator()
    {
        for (int p = Nmin; p <= Nmax; p++)
        {
            if (p % 2 == 0) yield return p;
        }
    }
}
class Program
{
    static void Main()
    {
        Evens ev = new Evens(20, 43);
        foreach (var t in ev)
            Console.Write(t + "  ");
        Console.WriteLine();
        Console.ReadKey();
    }
}