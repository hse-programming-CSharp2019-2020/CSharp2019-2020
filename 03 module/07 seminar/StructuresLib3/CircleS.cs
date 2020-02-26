using System;
using System.Collections.Generic;
using System.Text;

namespace StructuresLib3
{
    public struct CircleS : IComparable
    {     // композиция структур
        PointS center;      // центр круга
        double rad;         // радиус круга
        public CircleS(double xc, double yc, double rad)
        {
            center = new PointS(xc, yc);
            this.rad = rad;
        }
        // Свойcтво для центра окружности:
        public PointS Center
        {
            get { return center; }
            set { center = value; }
        }
        // свойство для радиуса окружности:
        public double Rad
        {
            get { return rad; }
            set { if (rad < 0) throw new ArgumentException();
                        rad = value; }
        }
        // свойство для получения значения длины окружности: 
        public double Len { get { return 2 * rad * Math.PI; } }
        // Строковое представление сведений об окружности:
        public new string ToString()
        {
            string format = "xc={0:f3},\tyc={1:f3},\tRad={2:f3}";
            string res = string.Format(format, center.X, center.Y, Rad);
            return res;
        }

        // Реализация метода интерфейса (сравнение радиусов):
        public int CompareTo(object cs)
        {
            if (this.rad < ((CircleS)cs).Rad) return -1;
            if (this.rad > ((CircleS)cs).Rad) return 1;
            return 0;
        }

    }
}
