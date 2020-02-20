using System;

namespace LibraryTask03
{
    public class Point
    {
        double x; // координаты
        double y;
        double z;
        // свойства доступа к координатам
        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Z { get { return z; } }
        public Point(double x, double y, double z)
        {   // конструктор
            this.x = x;
            this.y = y;
            this.z = z;
        }
        // переопределение ToString() для Dot
        public override string ToString()
        {
            string res = string.Format("[Точка: x = {0:f2} y = {1:f2} z = {2:f2}]", x, y, z);
            return res;
        }

    }
}
