using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example09
{
    [Serializable]
    public class Person
    {
        public int age;
        public string name;
        public Person() { }
        public Person(int a, string n)
        {
            age = a;
            name = n;
        }
    }

    [Serializable]
    public class Student : Person
    {
        public int mark;
        public Student() { }
        public Student(int a, int m, string n) : base (a, n)
        {
            mark = m;   
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(29, 8, "Tom");
            Student s2 = new Student(14, 5, "Bill");
            Person p3 = new Person(13, "Anna");
            Person[] people = new Person[] { s1, s2, p3 };

            XmlSerializer formatter = new XmlSerializer(
                typeof(Person[]), new Type[] { typeof(Student) });

            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }

            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])formatter.Deserialize(fs);

                foreach (Person p in newpeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.name, p.age);
                }
            }

            Console.ReadKey();
        }
    }
}
