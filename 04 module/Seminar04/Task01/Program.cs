using System;
using System.Collections;

public class A : IEnumerable
{
    private string[] arr = { "раз ромашка ", "два ромашка ",
                                  "три ромашка ", "пять ромашка ", "шесть ромашка " };
    public IEnumerator GetEnumerator()
    {
        return arr.GetEnumerator(); // определен для каждого массива
    }
} // end of A
class Program
{
    static void Main()
    {
        string[] testArr = { "раз ", "два ", "три " };
        foreach (string str in testArr) // "проходит" по любому массиву
            Console.Write(str);
        A a = new A();
        foreach (string str in a) // ошибка компиляции
            Console.Write(str);
        Console.ReadKey();
    } // end of Main()
} // end of Program
