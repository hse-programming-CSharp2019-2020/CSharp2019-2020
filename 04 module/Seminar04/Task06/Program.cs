using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    // StreamReader
using System.Collections;   // IEnumerable

namespace Task06
{
    public class FileLines : IEnumerable
    {
        StreamReader input = null; // Поток, представляющий файл
        string fileName = null; // Имя файла, с которым связан объект
                                //Конструктор:
        public FileLines(string fileName)
        {
            input = new StreamReader(fileName);
            this.fileName = fileName;   // Запомним имя файла 
        }
        // Реализация в классе FileLines интерфейса IEnumerable:
        public IEnumerator GetEnumerator()
        {
            return new FileEnumerator(this);
        }

        private class FileEnumerator : IEnumerator
        {
            private FileLines filelines;    // входной поток
            private string resultString = null;  // очередная строка из потока

            // Конструктор: 
            public FileEnumerator(FileLines f) { filelines = f; }

            // Объявление метода MoveNext из интерфейса IEnumerator:
            public bool MoveNext()
            {
                resultString = filelines.input.ReadLine();
                if (resultString != null)
                    return true;
                else
                {
                    Reset();    // восстановим состояние объекта
                    return false;
                }
            }

            // Объявление метода Reset из интерфейса IEnumerator:
            public void Reset()
            {
                if (filelines.input != null)
                    filelines.input.Close();

                filelines.input = new StreamReader(filelines.fileName);
            }   // Reset()  

            // Объявление свойства Current из интерфейса IEnumerator:
            public object Current
            {
                get
                {
                    return resultString;  // Текущая строка файла
                }
            }   // Current


        } // class FileEnumerator


    }   // class FileLines
    class Program
    {
        static void Main()
        {
            FileLines source = new FileLines(@"..\..\Program.cs");

            foreach (string item in source)
                Console.WriteLine(item);
            Console.WriteLine("*******************************************");

            foreach (string tem in source)
                Console.WriteLine(tem);

            Console.ReadKey();
        }   // Main( )
    }   // Program

}

