using System;
class Account<T>
{
    public static T session;

    public T Id { get; set; }
    public int Sum { get; set; }
}
public class Example
{
    public static void Main()
    {
        Account<int> account1 = new Account<int> { Sum = 5000 };
        Account<int>.session = 54;
        Account<string> account2 = new Account<string> { Sum = 4000 };
        Account<string>.session = "45";
        Console.WriteLine(Account<int>.session);
        Console.WriteLine(Account<string>.session);
        Console.ReadKey();
    }
}