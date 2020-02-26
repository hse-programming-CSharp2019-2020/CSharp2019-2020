using System;

namespace StructuresLib4
{
    public struct PointS : IComparable
    {   // "точка на плоскости" 
        double x, y;
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public PointS(double a, double b) { x = a; y = b; }
        public double distance(PointS ps)
        { // расстояние между точками
            double dx = x - ps.X;
            double dy = y - ps.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        // Реализация метода интерфейса (сравнение расстояний):
        public int CompareTo(object ob)
        {
            PointS temp = new PointS(0, 0);
            if (this.distance(temp) <
                ((PointS)ob).distance(temp)) return 1;
            if (this.distance(temp) >
                ((PointS)ob).distance(temp)) return -1;
            return 0;
        }
    }
}
