using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    abstract class Animal
    {
        int age; //возраст животного
        public Animal(int age) { Age = age; }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Descript()
        {
            return string.Format("{0}. Возраст: {1}", this.GetType().Name, Age);
        }
    }
    public interface IRun
    { //Бег
        string Run();
    }
    public interface IJump
    {//Прыжки
        string Jump();
    }
    class Cockroach : Animal, IRun
    { //Таракан – животное и может бегать
        int speed;
        public Cockroach(int age, int speed) : base(age)
        {
            this.speed = speed;
        }
        public string Run()
        {
            return string.Format("Таракан бегает со скоростью {0} км/ч", speed);
        }
    }
    class Kangaroo : Animal, IJump
    {//Кенгуру животное и может прыгать
        int length;
        public Kangaroo(int age, int length) : base(age)
        {
            this.length = length;
        }
        public string Jump()
        {
            return string.Format("Кенгуру прыгает на {0} м", length);
        }
    }
    class Chetar : Animal, IRun, IJump
    {//Гепард животное, может бегать и   					   //прыгать
        int speed;
        int length;
        public Chetar(int age, int speed, int length) : base(age)
        {
            this.speed = speed;
            this.length = length;
        }
        public string Run()
        {
            return string.Format("Гепард бегает со скоростью {0} км/ч", speed);
        }
        public string Jump()
        {
            return string.Format("Гепард прыгает на {0} м", length);
        }
    }

    class Program
    {
        static Animal[] genZoo()
        { //Создание массива животных
            Animal[] Zoo;
            Random gen;
            gen = new Random();
            Zoo = new Animal[10];
            for (int i = 0; i < 10; i++)
            {
                //0 –Таракан, 1 – Кенгуру, 2 - Гепард
                int AnimalType = gen.Next(0, 3);
                switch (AnimalType)
                {
                    case 0: //Таракан
                        Zoo[i] = new Cockroach(gen.Next(0, 5), gen.Next(3, 8));
                        break;
                    case 1: //Кенгуру
                        Zoo[i] = new Kangaroo(gen.Next(0, 30), gen.Next(1, 5));
                        break;
                    case 2: //Гепард
                        Zoo[i] = new Chetar(gen.Next(0, 30),
                        gen.Next(70, 120), gen.Next(3, 8));
                        break;
                }
            }
            return Zoo;
        }

        static void Main(string[] args)
        {
            Animal[] Zoo = genZoo(); //Создание массива животных
            foreach (Animal An in Zoo) //Вывод массива на экран
            {
                Console.WriteLine(An.Descript());
                if (An is IJump) //Если животное умеет прыгать
                    Console.WriteLine(((IJump)An).Jump());
                if (An is IRun) //Если животное умеет бегать
                    Console.WriteLine(((IRun)An).Run());
            }
            Console.ReadKey();
        }
    }
}
