using System;

namespace Task06
{
    // 1) класс с данными о событии "Кольцо найдено"
    public class RingIsFoundEventArgs : EventArgs
    {
        public RingIsFoundEventArgs(string s)
        {
            Message = s;
        }
        // Будем передавать только строку
        public String Message { get; set; }
    }

    public class Wizard
    { 
        public string Name { get; private set; }
        //2) событийный делегат
        public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);
        //3) событие "Кольцо найдено"
        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;
        public Wizard(string s) { Name = s; }
        public Wizard() { }
        // Когда волшебнику кажется, что кольцо найдено, он вызывает этот метод
        public void SomeThisIsChangedInTheAir()
        {
            Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл! ");
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Ривендейл"));
        }
    }

    public class Hobbit
    {
        public string Name { get; private set; }
        public Hobbit(string s) { Name = s; }
        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Покидаю Шир! Иду в " + e.Message);
        }
    }
    public class Human
    {
        public string Name { get; private set; }
        public Human(string s) { Name = s; }
        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Волшебник {((Wizard)sender).Name} позвал. Моя цель {e.Message}");
        }
    }
    public class Elf
    {
        public string Name { get; private set; }
        public Elf(string s) { Name = s; }
        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Звёзды светят не так ярко как обычно. Цветы увядают. Листья предсказывают идти в " + e.Message);
        }
    }
    public class Dwarf
    {
        public string Name { get; private set; }
        public Dwarf(string s) { Name = s; }
        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Точим топоры, собираем припасы! Выдвигаемся в " + e.Message);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Гендальф");
            Hobbit[] hobbits = new Hobbit[4];
            // TODO создать объекты хоббитов из Шира
            for (int i = 0; i < hobbits.Length; i++)
            {
                hobbits[i] = new Hobbit("Hobbit " + i);
            }
            // TODO подписать хоббитов на событие волшебника
            for (int i = 0; i < hobbits.Length; i++)
            {
                wizard.RaiseRingIsFoundEvent += hobbits[i].RingIsFoundEventHandler;
            }
            Human[] humans = { new Human("Боромир"), new Human("Арагорн") };
            Dwarf dwarf = new Dwarf("Гимли");
            Elf elf = new Elf("Леголас");
            // подписывает гномов, людей и эльфов на событие
            wizard.RaiseRingIsFoundEvent += dwarf.RingIsFoundEventHandler;
            wizard.RaiseRingIsFoundEvent += elf.RingIsFoundEventHandler;
            foreach (Human h in humans)
                wizard.RaiseRingIsFoundEvent += h.RingIsFoundEventHandler;
            // волшебник оповещает всех 
            wizard.SomeThisIsChangedInTheAir();
            Console.ReadKey();
        }
    }
}
