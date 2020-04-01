using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Копирование файла
            string path = @"..\..\1.txt";
            string newPath = @"..\1.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                // альтернатива с помощью класса File
                // File.Copy(path, newPath, true);
            }
            Console.ReadKey();
        }
    }
}
