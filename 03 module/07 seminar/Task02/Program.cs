using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public struct Coords
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Coords(double x, double y)
        {
            X = x; Y = y;
        }
        public override string ToString()
        {
            return $"x={X};y={Y}";
        }
    }

    public class Circle
    {
        public Coords Center { get; set; }
        double r;
        public double R
        {
            get { return r; }
            set
            {
                if (value > 0) r = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public Circle(Coords c, double r)
        {
            R = r;
            Center = c;
        }
        public Circle(double x, double y, double r)
        {
            R = r;
            Center = new Coords(x, y);
        }
        public override string ToString()
        {
            return $"{Center.ToString()};r={R:f3}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Circle testCircle = new Circle(0, 0, 4);
            Console.WriteLine(testCircle);

            testCircle.Center = new Coords(1, 1);
            Console.WriteLine(testCircle);

            testCircle = new Circle(new Coords(0, 0), 4);
            Console.WriteLine(testCircle);

            testCircle.Center = new Coords(1, 1);
            Console.WriteLine(testCircle);
            Console.ReadKey();
        }
    }
}
