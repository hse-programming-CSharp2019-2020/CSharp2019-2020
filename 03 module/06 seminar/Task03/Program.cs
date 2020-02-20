using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public interface ISeries
    { // интерфейс числовых рядов

        void setBegin();            // задать начальное состояние
        int GetNext { get; }        // вернуть очередной член ряда
        int this[int k] { get; }    // вернуть к-й член ряда
    }
    public class Pell : ISeries
    { // Ряд Пелла: 1, 2, 5, 12,...      
        int old, last;              // два предыдущих члена ряда
        public Pell() { setBegin(); }   // конструктор
        public void setBegin()
        {// задать начальное состояние
            old = 1; last = 0;
        }
        public int GetNext
        {    // вернуть следующий после last         
            get
            {
                int now = old + 2 * last;
                old = last; last = now;
                return now;
            }
        }
        public int this[int k]
        { // вернуть к-й член ряда        
            get
            {
                int now = 0;
                setBegin();
                if (k <= 0) return -1;
                for (int j = 0; j < k; j++) now = GetNext;
                return now;
            }
        }
    } // end of Pell

    class Program
    {
        // вывести n членов ряда
        public static void seriesPrint(int n, ISeries s)
        {
            for (int i = 0; i < n; i++)
                Console.Write(s.GetNext + "\t");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Pell pell = new Pell();
            seriesPrint(9, pell);
            Console.WriteLine("pell[3] = " + pell[3]);
            seriesPrint(4, pell);
            seriesPrint(3, pell);
            Console.ReadKey();
        }

    }
}
