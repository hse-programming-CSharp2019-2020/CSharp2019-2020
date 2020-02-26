using System;
using System.Collections.Generic;
using System.Text;

namespace Lib5
{
    public struct MassPoint
    {   // Материальная точка
        public PointS coord;    // координаты
        double mass;            // масса
        public MassPoint(PointS ps, double mass)
        {
            coord = ps;
            this.mass = mass;
        }
        public double Mass { get { return mass; } }
        public string ToString()
        {
            string format = "x={0},\ty={1},\tmass={2}";
            string res = string.Format(format, coord.X, coord.Y, mass);
            return res;
        }
    }

}
