using System;

namespace LibraryTask04Estimates
{
    public class Estimates
    {
        double xMin, xMax, sumX, sumX2;
        int numb;
        public int Numb { get { return numb; } }
        public double Xmin { get { return xMin; } }
        public double Xmax { get { return xMax; } }
        // Вычисляемые свойства:
        public double Average { get { return numb == 0 ? 0 : sumX / numb; } }
        public double Deviation
        {
            get
            {
                return numb < 2 ? 0 :
                    Math.Sqrt(sumX2 / (numb - 1) - sumX * sumX / numb / (numb - 1));
            }
        }    // добавление в выборку еще одного значения:
        public void add(double x)
        {
            numb++;
            sumX += x;
            sumX2 += x * x;
            xMax = Xmax < x ? x : xMax;
            xMin = xMin > x ? x : Xmin;
        }
    }
}
