using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

// https://metanit.com/sharp/tutorial/6.5.php

namespace Serialization
{
    [Serializable]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }

        public Person(string name, int year)
        {
            Name = name;
            Age = year;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Person person1 = new Person("Tom", 29);
            Person person2 = new Person("Bill", 25);
            Person[] people = new Person[] { person1, person2 };

            DataContractJsonSerializer jsonFormatter = 
                new DataContractJsonSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("people.json", 
                FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, people);
            }

            using (FileStream fs = new FileStream("people.json", 
                FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])jsonFormatter.
                    ReadObject(fs);

                foreach (Person p in newpeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                }
            }

            Console.ReadLine();
        }
    }
}