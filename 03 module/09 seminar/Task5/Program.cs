using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"..\..\Целые_числа.txt");
            FileStream fs = file.Create();   // создан файл и поток 
            int next,               // Очередное число
                number = 10,
                pattern = 3;        // Общее количество чисел в файле
            byte[] bin = new byte[4];   // Массив байтов для кода целого 
            Random gen = new Random();
            for (int i = 0; i < number; i++)
            {
                next = gen.Next(1000);
                // Console.Write(next + " "); числа, попавшие в файл
                bin = BitConverter.GetBytes(next);    // байтовое представление 
                fs.Write(bin, 0, bin.Length);       // запись в файл
            }
            fs.Flush();               // очистить буфер
            fs.Position = 0;    // Вернуться в начало файла (потока)
            long lenFs = fs.Length; // Определить размер файла (потока)
            for (int k = 0; k < lenFs / 4; k++)
            {
                fs.Read(bin, 0, bin.Length); // прочитать 4 байта
                int decod;
                decod = BitConverter.ToInt32(bin, 0); // получить значение
                if (decod % pattern == 0)
                    Console.WriteLine("decod=" + decod);
            }
            fs.Close();
            Console.ReadLine();
        }
    }
}
