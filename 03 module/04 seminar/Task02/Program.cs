using System;

namespace Task02
{
    public delegate double ExpDel(double x);
    public delegate void ExpChanged();
    class Expression
    {
        ExpDel ex;

        public event ExpChanged OnExpChanged;

        public Expression(ExpDel e)
        {
            ex = e;
        }
        public double ExVal(double x)
        {
            return ex(x);
        }
        public ExpDel Ex
        {
            set
            {
                ex = value;
                OnExpChanged();
            }
        }

    }

    class ValueStore
    {
        Expression exp;
        double x0;
        double expCurrValue;
        public ValueStore(Expression e1, double x0)
        {
            exp = e1;
            this.x0 = x0;
            expCurrValue = exp.ExVal(x0);
        }
        public double CurrVal
        {
            get
            {
                return expCurrValue;
            }
        }

        public void OnExpChangedHandler()
        {
            expCurrValue = exp.ExVal(x0);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Expression me = new Expression(x => { return x * x + 2 * x - 3; });
            ValueStore vs = new ValueStore(me, 0);
            me.OnExpChanged += vs.OnExpChangedHandler;
            Console.WriteLine(vs.CurrVal);
            me.Ex = x => { return Math.Sqrt(Math.Abs(x)); };
            Console.WriteLine(vs.CurrVal);
            me.Ex = x => { return Math.Sin(x); };
            Console.WriteLine(vs.CurrVal);
            me.Ex = x => { return x * x * x - 1; };
            Console.WriteLine(vs.CurrVal);
            Console.ReadKey();
        }
    }
}
