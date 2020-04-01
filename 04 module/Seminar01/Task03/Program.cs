// Класс Quadratic - квадратное уравнение
using System; // для атрибута Serializable
using System.IO;    // FileStream
// BinaryFormatter: 
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization; // SerializationException

namespace Task03
{
    // делегат-тип для методов обработки объектов класса Quadratic //(уравнений):
    delegate void q_delegate(Quadratic qe);

    [Serializable]
    class Quadratic
    {
        public int a, b, c;
        public Quadratic() { }
        public Quadratic(int aa, int bb, int cc)
        {
            a = aa;
            b = bb;
            c = cc;
        }

        public int Discriminant
        {
            get
            {
                return b * b - 4 * a * c;
            }
        }

        public double X1
        {
            get { return -b + (Math.Sqrt(Discriminant)) / 2*a; }
        }

        public double X2
        {
            get { return -b - (Math.Sqrt(Discriminant)) / 2 * a; }
        }
    }
    // Класс методов для обработки
    class Processing
    {
        static Random gen = new Random();
        // методы работы с файлами
        // Оценить дискриминант и для неотрицательного - вывести корни: 
        public static void solutionReal(Quadratic eq)
        {
            if (eq.Discriminant < 0) return;
            Console.WriteLine(eq.ToString() + "  дискриминант = " + eq.Discriminant);
            Console.WriteLine("\tКорни: Х1={0,3:g3}  \tX2={1,3:g3}",
               eq.X1, eq.X2);
        }   // solutionReal()
            // Метод выводит на экран сведения об уравнении:
        public static void printEq(Quadratic eq)
        {
            Console.WriteLine(eq.ToString() + "  дискриминант = "
                + (eq.Discriminant).ToString("g3"));
        }   // printEq


        // Создать файл и записать в него объекты, применяя сериализацию.
        // Создать несколько объектов класса и записать их в файл: 
        static public void writeFile(string nameFile, int numb)
        {
            using (FileStream streamOut = new FileStream(nameFile, FileMode.Create))
            {
                BinaryFormatter formatOut = new BinaryFormatter();
                for (int j = 0; j < numb; j++)
                {
                        Quadratic q = new Quadratic(gen.Next(-10, 11),
                            gen.Next(-10, 11), gen.Next(-10, 11));
                        formatOut.Serialize(streamOut, q);
                }
            }
        }   // writeFile() 

        //  Метод читает из файла сериализованные объекты и "не знает" что с 
        //  ними делать:
        public static void process(string fileName, q_delegate q_del)
        {
            using (FileStream streamIn = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatIn = new BinaryFormatter();
                Quadratic eq;
                while (true) // читать до конца файла - там исключение 
                    try
                    {
                        eq = (Quadratic)formatIn.Deserialize(streamIn);
                        q_del(eq);
                    }
                    catch (SerializationException) { streamIn.Close(); break; }
            }
        }   // process() 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Processing.writeFile("equation.ser", 2);
            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");
            // Обращение с использованием делегата:
            Processing.process("equation.ser", new q_delegate(Processing.printEq));
            Console.WriteLine("Для решения уравнений нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("\nРешения уравнений с вещественными корнями: ");
            Processing.process("equation.ser", new q_delegate(Processing.solutionReal));
            Console.WriteLine("Для завершения работы нажмите ENTER.");
            Console.ReadLine();

        }
    }
}
