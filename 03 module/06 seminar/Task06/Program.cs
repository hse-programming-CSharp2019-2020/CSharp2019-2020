using System;

namespace Task06
{
    public interface IInterFun
    {
        double ArifmeticFuction(double r);  // математическая функция
    }

    public interface IInterRoot
    {
        double RootSearch();            // поиск корня 
        int IterationQuantity { get; }    // количество итераций

    }
    public class RealSearch : IInterFun, IInterRoot
    {
        double a, b, eps;   // границы интервала и точность
        int iter;           // количество итераций оценки корня
        double IInterFun.ArifmeticFuction(double r)
        { // реальная функция
            return Math.Sin(r);
        }
        //Конструктор объектов класса:
        public RealSearch(double ai, double bi, double ei)
        {
            a = ai; b = bi; eps = ei; iter = 0;
        }
        public int IterationQuantity
        {
            get
            {
                if (iter == 0) RootSearch();
                return iter;
            }
        }

        // поиск корня делением интервала пополам
        public double RootSearch()
        {
            double fx, fy, fc, x = a, y = b, c;
            fx = ((IInterFun)this).ArifmeticFuction(x);
            fy = ((IInterFun)this).ArifmeticFuction(y);
            if (fx * fy > 0)
                throw new Exception("Ошибка в локализации корня!");
            do
            {
                c = (y + x) / 2;
                fc = ((IInterFun)this).ArifmeticFuction(c);
                if (fc * fx > 0) { x = c; fx = fc; }
                else { y = c; fy = fc; }
                iter++;             // подсчет итераций
            } while (fc != 0 && y - x > eps);
            return c;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            RealSearch func = new RealSearch(-0.2, 0.3, 0.001);
            Console.WriteLine("Корень функции Sin(x) = {0:G4}",
                                    func.RootSearch());
            Console.WriteLine("Количество итераций = " +
                                    func.IterationQuantity);

            Console.ReadKey();
        }
    }
}
