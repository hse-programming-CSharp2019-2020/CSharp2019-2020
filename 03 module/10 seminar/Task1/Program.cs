// Проект 1. Запись целых чисел в двоичный поток 
using System;
using System.IO;
class Program
{
    static void Main()
    {
        BinaryWriter fOut = new BinaryWriter(
            new FileStream(@"../../../t.txt", FileMode.Create));
        for (int i = 0; i <= 10; i += 2)
            fOut.Write(i);
        fOut.Close();
    }
}
