using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    [Serializable]
    class Student
    {
        public string name;
        public int year;
        public Student(string n, int y)
        {
            name = n;
            year = y;
        }
    }
    [Serializable]
    class Group
    {
        public string ident;   // group's identifier
        public Student[] list;  // students' list
        public Group(string id, Student[] list)
        {
            ident = id;
            this.list = list;
        }
        public new string ToString()
        {
            string temp = ident + ": ";
            foreach (Student st in list)
                temp += st.name + "-" + st.year + "  ";
            return temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] list171 = {new Student("Иванов", 1),
                new Student("Петров", 1),new Student("Сидоров",1)};
            Group gr171 = new Group("ПИ-171", list171);

            Student[] list271 = {new Student("Яколев", 2),
                new Student("Юрьевa", 2),new Student("Энатов",2)};
            Group gr271 = new Group("ПИ-271", list271);

            FileStream bas = new FileStream("group.ser", FileMode.OpenOrCreate);
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(bas, gr171);
            format.Serialize(bas, gr271);
            bas.Close();

            Console.WriteLine("Выполнена запись в файл group.ser");

            bas = new FileStream("group.ser", FileMode.Open);

            while (true)
            {
                try
                {
                    Group gr = (Group)format.Deserialize(bas);
                    Console.WriteLine(gr.ToString());
                }
                catch (SerializationException)
                { // - в конце файла
                    bas.Close(); break;
                }
            }
            Console.ReadKey();
        }
    }
}
