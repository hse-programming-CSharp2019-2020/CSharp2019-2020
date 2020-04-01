using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

//https://metanit.com/sharp/tutorial/6.5.php 
namespace Serialization
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Town { get; set; }
    }
    [DataContract]
    public class Person : Human
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public Company Company { get; set; }

        public Person(string name, int age, Company comp, string town)
        {
            Name = name;
            Age = age;
            Company = comp;
            Town = town;
        }
    }
    [DataContract]
    public class Company
    {
        [DataMember]
        public string Name { get; set; }
        public Company(string name)
        {
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Tom", 29, new Company("Microsoft"), "Moscow");
            Person person2 = new Person("Bill", 25, new Company("Apple"), "Penza");
            Person[] people = new Person[] { person1, person2 };

            DataContractJsonSerializer jsonFormatter = 
                new DataContractJsonSerializer(
                typeof(Person[]), new Type[] { typeof(Human) });

            using (FileStream fs = new FileStream("people.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, people);
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])jsonFormatter.ReadObject(fs);

                foreach (Person p in newpeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1} --- Компания: {2}", p.Name, p.Age, p.Company.Name);
                }
            }
            Console.ReadLine();
        }
    }
}