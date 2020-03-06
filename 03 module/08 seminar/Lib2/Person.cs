using System;

namespace Lib2
{
    public struct Person
    {
        public string name { get; set; }
        public string lastname { get; set; }
        //TODO: нужны проверки корректности возраста
        public int age { get; set; }
        public Person(string name, string lastname, int age)
        {
            this.name = name; this.lastname = lastname;
            this.age = age;
        }
        public override string ToString()
        {
            return name + " " + lastname + " " + age;
        }
    }

}
