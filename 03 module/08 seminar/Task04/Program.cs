using System;
class Stack<ItemType>
{
    static int stackSize = 100; // предельный размер каждого стека 
    private ItemType[] items = new ItemType[stackSize];
    private int index = 0; // номер свободного элемента
    public void Push(ItemType data)
    {
        if (index == stackSize)
            throw new ApplicationException("Стек переполнен!");
        items[index++] = data;
    }
    public ItemType Pop()
    {
        if (index == 0)
            throw new ApplicationException("Стек пуст!");
        return items[--index];
    }
}
class point
{// класс, определенный программистом 
    public double X { get; set; }
    public double Y { get; set; }
}

class Program
{
    static void Main()
    {
        Stack<char> charStack = new Stack<char>();
        charStack.Push('A');
        Console.WriteLine("charStack.Pop() = " + charStack.Pop());
        Stack<double> doubleStack = new Stack<double>();
        doubleStack.Push(3.14159);
        double x = doubleStack.Pop();
        Console.WriteLine("x = " + x);
        // charStack.Push(2.7171); - ошибка компиляции 
        Stack<point> pointStack = new Stack<point>();
        pointStack.Push(new point());
        point p = pointStack.Pop();
        Console.WriteLine("p.X = {0}, p.Y = {1}", p.X, p.Y);
        Console.ReadKey();
    }
}
