using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    [Serializable]  // атрибут сериализации
    public class Multiple
    { // Кратные числа
        public readonly string name;    // название делителя
        public readonly int divisor;    // значение делителя
        public readonly int[] numbers;     // массив чисел, кратных divisor
        public override string ToString()
        {
            string mom = "Делитель: " + divisor + " - " + name + "\nКратные: ";
            foreach (int m in numbers)
                mom += m + "  ";
            return mom;
        }
        public Multiple(int div, int[] ar)
        { // конструктор
            if (div <= 0 || div > 9)
                throw new Exception("Неверно выбран делитель!");
            divisor = div;
            switch (div)
            {
                case 1: name = "один"; break;
                case 2: name = "два"; break;
                case 3: name = "три"; break;
                case 4: name = "четыре"; break;
                case 5: name = "пять"; break;
                case 6: name = "шесть"; break;
                case 7: name = "семь"; break;
                case 8: name = "восемь"; break;
                case 9: name = "девять"; break;
            }
            int[] temp = new int[ar.Length];
            int numb = 0;
            for (int i = 0; i < ar.Length; i++)
                if (ar[i] % div == 0) temp[numb++] = ar[i];
            numbers = new int[numb];
            Array.Copy(temp, numbers, numb);    // Укоротили массив
        }   // конструктор

    }   // class Multiple 

    class Program
    {
        static void Main(string[] args)
        {
            Multiple row;           // ссылка на объект класса
            int size = 0;           // размер генеральной совокупности
            do Console.Write("Введите размер генеральной совокупности: ");
            while (!int.TryParse(Console.ReadLine(), out size) | size < 1);
            Random gen = new Random(5);
            int[] data = new int[size];    // генеральная совокупность
            for (int i = 0; i < size; i++)
            {
                data[i] = gen.Next(0, 100);
                Console.Write(data[i] + "  ");
            }
            Console.WriteLine();
            BinaryFormatter formBin = new BinaryFormatter();
            using (FileStream byteStream = new FileStream("bytes",
                          FileMode.Create, FileAccess.ReadWrite))
            {
                do
                {  // цикл для создания и записи в файл объектов
                    int div;
                    do
                    {    // цикл проверки делителя!
                        do Console.Write("Введите делитель: ");
                        while (!int.TryParse(Console.ReadLine(), out div));
                        try
                        {
                            row = new Multiple(div, data);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Нужен делитель от 1 до 9!");
                            continue;
                        }
                    }
                    while (true);
                    // создан объект row, запишем его код в файл:
                    formBin.Serialize(byteStream, row);
                    byteStream.Flush();
                    Console.WriteLine("\nДля чтения файла - клавиша ESC");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                byteStream.Position = 0;
                while (true) // читать до конца файла 
                    try
                    {
                        row = (Multiple)formBin.Deserialize(byteStream);
                        Console.WriteLine(row.ToString());
                    }
                    catch (SerializationException)
                    { // 
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
