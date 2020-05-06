using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08
{
    public class MyLib
    {
        #region  //   string[ ]  keywords
        static public string[] keywords = {
    "abstract", "as", "base", "bool", "break",
    "byte", "case", "catch", "char", "checked",
    "class", "const", "continue", "decimal", "default",
    "delegate", "do", "double", "else", "enum",
    "event", "explicit", "extern", "false", "finally",
    "fixed", "float", "for", "foreach", "goto",
    "if", "implicit", "in", "int", "interface",
    "internal", "is", "lock", "long", "namespace",
    "new", "null", "object", "operator", "out",
    "override", "params", "private", "protected", "public",
    "readonly", "ref", "return", "sbyte", "sealed",
    "short", "sizeof", "stackalloc", "static", "string",
    "struct", "switch", "this", "throw", "true",
    "try", "typeof", "uint", "ulong", "unchecked",
    "unsafe", "ushort", "using", "virtual", "void",
    "volatile", "while"  };//  string[]
        #endregion
    }   //  class MyLib

    public class FileLines : IEnumerable<string>
    {
        StreamReader input = null; // Поток, представляющий данные файла
        string fileName = null; // Имя файла, с которым связан объект
        // Конструктор:
        public FileLines(string fileName)
        {
            input = new StreamReader(fileName);
            this.fileName = fileName;   // Запомним имя файла 
        }
        // Реализация в классе FileLines интерфейса IEnumerable:
        public IEnumerator<string> GetEnumerator()
        { return new FileEnumerator(this); }
        IEnumerator IEnumerable.GetEnumerator()
        { return new FileEnumerator(this); }

        // Внутренний класс реализует интерфейс IEnumerator:
        private class FileEnumerator : IEnumerator<string>
        {
            private FileLines filelines;    // входная последовательность
            private string resultString = null;// очередная строка (элемент)
            // Конструктор нумератора: 
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
                {
                    filelines.input.Close();
                }
                filelines.input = new StreamReader(filelines.fileName);
            }   // Reset(
            // Объявление свойства Current из интерфейса IEnumerator:
            public string Current
            {
                get { return resultString; } // Текущая строка файла  
            }   // Current
            // Свойство для возврата 
            // текущего элемента последовательности: 
            object IEnumerator.Current { get { return Current; } }
             
            // Заглушка для нереализованного 
            // члена интерфейса IEnumerator:   
            void IDisposable.Dispose() { }

        }   // class FileEnumerator


    }   // class FileLines


    class Program
    {
        static void Main(string[] args)
        {
            FileLines source;
            string fileName = @"..\..\Program.cs";

            if (args.Length == 0)
                Console.WriteLine("В командной строке нет имени файла. " +
                                "\nПрограмма будет обрабатывать код из файла Program.cs.");
            else fileName = args[0];

            try { source = new FileLines(fileName); }
            catch
            {
                Console.WriteLine("Ошибка в имени файла!");
                return;
            }

            // Выбрать короткие строки со служебными словами: 
            var res = from line in source
                      from key in MyLib.keywords
                      where (line.Length < 20) & (line.IndexOf(key) != -1)
                      select new { key, line };

            Console.WriteLine("\n*** Слова и выбранные строки: ***");

            foreach (var item in res)
                Console.WriteLine(item);

            Console.WriteLine("Для выхода нажмите любую клавишу!");
            Console.ReadKey();
        }   // Main

    }
}
