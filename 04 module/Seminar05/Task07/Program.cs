using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task07
{
    public class Point
    {// Класс "точка на плоскости"    
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public double Mod
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        // Сравнение двух точек:
        public bool Equals(Point other)
        {
            if (X == other.X & Y == other.Y)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return String.Format("x = {0}, y = {1}, mod = {2:G5}", X, Y, Mod);
        }
    }   // class Point

    // Класс - последовательность несовпадающих точек:
    public class PointList : IEnumerable<Point>
    {
        // Закрытый список для хранения элементов последовательности:
        private List<Point> list;
        public PointList()
        { // Конструктор - class PointList
            list = new List<Point>();
        }
        // Количество элементов в последовательности:
        public int Count { get { return list.Count; } }
        // Индексатор для класса PointList:
        public Point this[int index]
        {
            get { return (Point)list[index]; }
            set { list[index] = value; }
        }
        // Добавлять в список только новые точки:
        public void Add(Point point)
        {
            foreach (Point p in list)
                if (p.Equals(point) == true) return;
            list.Add(point);
        }
        // Реализуем члены интерфейсов:
        public IEnumerator<Point> GetEnumerator() { return new PointEnumerator(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new PointEnumerator(this); }
    }   // class PointList

    // Класс-нумератор для последовательности PointList:
    public class PointEnumerator : IEnumerator<Point>
    {
        private PointList _list;
        private int curIndex;
        private Point curPoint;
        // Конструктор:
        public PointEnumerator(PointList pointList)
        {
            _list = pointList;
            curIndex = -1;
            curPoint = default(Point);
        }
        public bool MoveNext()
        {
            // Проверка достижения конца коллекции
            if (++curIndex >= _list.Count) return false;
            // Сделать текущим следующий элемент последовательности:
            curPoint = _list[curIndex];
            return true;
        }
        // Установить итератор в начало последовательности:
        public void Reset() { curIndex = -1; }

        // Заглушка для не реализованного члена интерфейса IEnumerator:   
        void IDisposable.Dispose() { }

        // Свойство для возврата текущего элемента последовательности: 
        public Point Current
        { get { return curPoint; } }

        // Свойство для возврата текущего элемента последовательности: 
        object IEnumerator.Current
        { get { return Current; } }

    }   // class PointEnumerator

    class Program
    {
        static void Main()
        {
            PointList set = new PointList();
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(7, 1));
            set.Add(new Point(7, 2));
            set.Add(new Point(5, 2));
            set.Add(new Point(7, 2));
            Console.WriteLine("Список точек на плоскости:");
            foreach (Point p in set)
                Console.WriteLine(p.ToString());
            // Обработка списка в LINQ-запросах:
            IEnumerable<Point> newList =
                from v in set
                orderby v.Mod
                select v;
            //set.OrderBy(d => d.Mod);  // аналог приведенного запроса 
            Console.WriteLine("Список упорядоченных точек:");
            foreach (Point p in newList)
                Console.WriteLine(p.ToString());

            var res = from r in set
                      where r.Mod > 7
                      select r;
            //Console.WriteLine(res.GetType());
            Console.WriteLine("Список точек c модулем большим 7:");
            foreach (Point p in res)
                Console.WriteLine(p.ToString());
            Console.ReadKey();
        }   // void Main

    }
}
