using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_3_04_03_04Beads
{
    /// <summary>
    /// 1 шаг. Определяем класс-наследник EventArgs с аргументами для своего события
    /// у нас это событие изменения длины нити и аргумент - радиус
    /// </summary>
    public class ChainLenChangedEventArgs : EventArgs
    {
        public double Rad { get; }
        public ChainLenChangedEventArgs(double r)
        {
            Rad = r;
        }
    }

}
