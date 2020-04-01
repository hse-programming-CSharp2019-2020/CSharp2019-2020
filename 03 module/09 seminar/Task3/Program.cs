using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi = new FileInfo(@"..\..\Alphabet.txt");
            FileStream fs = fi.Open(FileMode.OpenOrCreate);
            long len = fs.Length;   // Размер файла
            if (len == 26) Console.WriteLine("Aлфавит собран!");
            else
            {
                if (len == 0) Console.WriteLine("Файл пуст!");
                fs.Seek(len, SeekOrigin.Begin);
                byte bt = (byte)((int)'A' + len);
                fs.WriteByte(bt);
                Console.WriteLine("Добавляем в файл букву " + (char)bt);
            }
            Console.WriteLine("Буквы в файле:");
            fs.Seek(0, SeekOrigin.Begin);
            int u;
            while ((u = fs.ReadByte()) != -1)
                Console.Write((char)u + "  ");
            Console.WriteLine();
            fs.Flush(); // Освободить буфер
            fs.Close(); // Закрыть поток и файл
            fs = null;  // Обнулить ссылку на поток
        }
    }
}
