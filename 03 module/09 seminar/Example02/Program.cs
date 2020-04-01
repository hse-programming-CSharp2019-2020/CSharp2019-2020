using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Удаление файла
            string path = @"..\..\1.cs";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                Console.WriteLine("Deleted");
                // альтернатива с помощью класса File
                // File.Delete(path);
            }
            Console.ReadKey();
        }
    }
}
