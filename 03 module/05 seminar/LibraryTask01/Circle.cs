using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask01
{
    public class Circle
    {       // !!!! композиция классов 
        public Point center;    // центр круга
        double rad;             // радиус круга
        public Circle(double xc, double yc, double rad)
        {
            // TODO3: Проверка корректности данных о круге
            center = new Point(xc, yc);
            this.rad = rad;
        }   // Circle()

        public override string ToString()
        {
            string format = "xc={0:g5},\tyc={1:g5},\tRad={2:g5}";
            string res = string.Format(format, center.X, center.Y, rad);
            return res;
        }   // ToString()
            // Радиус круга: 
        public double Rad { get { return rad; } }
    }   // class Circle

}
