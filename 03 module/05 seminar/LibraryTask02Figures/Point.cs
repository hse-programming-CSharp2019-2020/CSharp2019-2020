using System;

namespace LibraryTask02Figures
{
    public class Point  // "точка на плоскости"
    {
        double x, y;
        public Point(double a, double b) { x = a; y = b; }
        public Point() : this(0, 0) { }// конструктор умолчания
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double norm(Point p)
        {
            double temp = (x - p.x) * (x - p.x) +
                      (y - p.y) * (y - p.y);
            return Math.Sqrt(temp);
        }
    }

}
