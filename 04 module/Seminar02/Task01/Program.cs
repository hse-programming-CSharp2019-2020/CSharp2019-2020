using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    [DataContract]
    class Student
    {
        [DataMember]
        public string name;
        [DataMember]
        public int year;
        public Student(string n, int y)
        {
            name = n;
            year = y;
        }
    }
    [DataContract]
    class Group
    {
        [DataMember]
        public string ident;   // group's identifier
        [DataMember]
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

            Group[] groups = new Group[] { gr171, gr271 };

            FileStream bas = new FileStream("group.ser", FileMode.Create);
            DataContractJsonSerializer format = 
                new DataContractJsonSerializer(typeof(Group[]));
            format.WriteObject(bas, groups);
            bas.Close();

            Console.WriteLine("Выполнена запись в файл group.ser");

            bas = new FileStream("group.ser", FileMode.Open);


            Group[] gr1 = (Group[])format.ReadObject(bas);
            foreach (Group gr2 in gr1)
                Console.WriteLine(gr2.ToString());

            Console.ReadKey();
        }
    }
}