using System;

namespace LibraryTask01
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        // TODO1: Конструктор с двумя параметрами
        public Point(double x, double y)
        {
            X = x; Y = y;
        }

        // TODO2: Метод вычисления расстояния 
        public double Distance(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X- X, 2) + Math.Pow(point.Y - Y, 2));
        }

    }
}
