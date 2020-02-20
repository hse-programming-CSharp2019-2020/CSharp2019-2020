using System;

namespace LibraryTask02Figures
{
    public class TriangleComp
    {
        Point A, B, C;  // вершины треугольника
        double a, b, c; // длины сторон
        public TriangleComp(double xa, double ya, double xb, double yb, double xc, double yc)
        {
            A = new Point(xa, ya);
            B = new Point(xb, yb);
            C = new Point(xc, yc);
            a = B.norm(C);
            b = C.norm(A);
            c = A.norm(B);
        }
        public TriangleComp() : this(0, 0, 0, 0, 0, 0) { }
        public double Square
        { // площадь треугольника
            get
            {
                double temp, p = (a + b + c) / 2;
                temp = p * (p - a) * (p - b) * (p - c);
                return Math.Sqrt(temp);
            }
        }
        public bool check(Point P)
        {
            TriangleComp obj = new TriangleComp(P.X, P.Y, A.X, A.Y, B.X, B.Y);
            double spab = obj.Square;
            obj = new TriangleComp(P.X, P.Y, A.X, A.Y, C.X, C.Y);
            double spac = obj.Square;
            obj = new TriangleComp(P.X, P.Y, B.X, B.Y, C.X, C.Y);
            double spbc = obj.Square;
            if (spab + spac + spbc > this.Square) return false;
            return true;
        }

    }
}
