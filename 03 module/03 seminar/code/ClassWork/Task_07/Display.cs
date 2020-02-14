using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Display
    { // Обработчик событий в этом классе
        static int len = 30;
        static string st = null;

        public static void BarShow(long n, int si, int kl)
        {
            int pos = Math.Abs((int)((double)kl / si * len));
            string s1 = new string('\u258c', pos); //код для вертикального бара
            string s2 = new string('-', len - pos - 1) +
                                       '\u25c4';   // unicode для треугольника;
            st = s1 + '\u258c' + s2; //'\u258c' - код прямоугольника 
            Console.Write("\r\t\t" + st);
        }
    }

}
