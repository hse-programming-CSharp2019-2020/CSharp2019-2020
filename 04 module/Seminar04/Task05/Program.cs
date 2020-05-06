using System;
using System.Collections;
class IteratorSample : IEnumerable
{
    object[] values; // итерируемая последовательность
    int start;       // начальная позиция
    public IteratorSample(object[] val, int start)
    {
        this.values = val;
        this.start = start;
    }
    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < values.Length; index++)
            yield return values[(index + start) % values.Length];
    }
    static void Main()
    {
        object[] values = { 1, 2, 3, 4, 5, 6 };
        IteratorSample collect_3 = new IteratorSample(values, 3);
        foreach (object ob in collect_3)
            Console.Write(ob + "  ");
        Console.WriteLine();
        foreach (int ob in new IteratorSample(values, 1))
            Console.Write(ob + "  ");
        Console.WriteLine();
        Console.WriteLine("\nНажмите ENTER. . . ");
        Console.ReadLine();
    }
}

