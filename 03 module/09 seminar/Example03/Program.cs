using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Перемещение файла
            string path = @"..\..\1.txt";
            string newPath = @"..\1.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath);
                // альтернатива с помощью класса File
                // File.Move(path, newPath);
            }
            Console.ReadKey();
        }
    }
}
