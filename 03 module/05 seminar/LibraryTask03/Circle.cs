namespace LibraryTask03
{
    public class Circle
    {
        Point center; // центр окружности
        double rad; // радиус окружности
                    // свойства доступа к полям
        public double Rad { get { return rad; } }
        public Point Center { get { return center; } }
        // конструктор
        public Circle(double x, double y, double z, double radius)
        {
            center = new Point(x, y, z);
            rad = radius;
        }
        // переопределение ToString для Circle
        public override string ToString()
        {
            string res = string.Format("[Окружность:\n\t\t радиус {0:f2}\n\t\t центр {1}]", rad, center.ToString());
            return res;
        }
    }
}
