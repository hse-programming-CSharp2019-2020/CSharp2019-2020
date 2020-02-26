using System;

namespace StructuresLib3
{
    public struct PointS
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
    }
}
