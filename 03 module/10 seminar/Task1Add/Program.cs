// Проект 2. Чтение целых из двоичного потока. 
// ЧИТАТЬ И ЗАПИСЫВАТЬ СТРОГО ПО ОДНОМУ ЧИСЛУ!!! 
using System;
using System.IO;
class Program
{
    static void Main()
    {
        FileStream f = new FileStream("../../../t.txt", FileMode.Open);
        BinaryReader fIn = new BinaryReader(f);
        long n = f.Length / 4;
        int a;
        for (int i = 0; i < n; i++)
        {
            a = fIn.ReadInt32();
            Console.Write(a + " ");
        }
        Console.WriteLine("\nЧисла в обратном порядке:");
        // 1) TODO: Прочитать и напечатать все числа из файла в обратном порядке
        // 2) TODO: увеличить  все числа в файле в 5 раз
        // 3) TODO: Прочитать и напечатать все числа из файла в прямом порядке
        fIn.Close();
        f.Close();
    }
}

