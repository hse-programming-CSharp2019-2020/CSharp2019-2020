using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_3_04_03_04Beads
{
    public delegate void BeadRadiusChanged(double r); // TODO 1 

    /// <summary>
    /// Бусина
    /// </summary>
    public class Bead
    {
        /// <summary>
        /// радиус бусины
        /// </summary>
        double r;

        /// <summary>
        /// радиус бусины
        /// </summary>
        public double R { get => r;
            set
            {
                SetRadius(value);
                // TODO 1 - begin
                Console.WriteLine($"BeadRadiusChanged(R={R:f2} => ...): ");
                //BeadRadiusChangedEvent?.Invoke(r);
                OnBeadRadiusChanged(new ChainLenChangedEventArgs(r));
                // TODO 1 - end
            }
        }

        private void SetRadius(double value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Радиус бусины не может быть меньше или равен нулю");
            r = value;
        }

        //public event BeadRadiusChanged BeadRadiusChangedEvent;  // TODO 1 
        public event EventHandler<ChainLenChangedEventArgs> BeadRadiusChangedEvent;  // TODO 1 
        // 3 шаг. В класс Chain добавляем метод запуска события
        protected virtual void OnBeadRadiusChanged(ChainLenChangedEventArgs e)
        {
            BeadRadiusChangedEvent?.Invoke(this, e);
        }


        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="r">радиус бусины</param>
        public Bead(double r)
        {
            SetRadius(r);
        }

        /// <summary>
        /// обработчик события изменения длины нити
        /// </summary>
        /// <param name="newR">новый радиус бусины</param>
        public void ChainLenChangedHandler(double newR) {
            SetRadius(newR);
            Console.WriteLine($"Set {newR:f2} for bead with hash {GetHashCode()}");
        }

        /// <summary>
        /// 5 шаг. Изменяем код обработчика. 
        /// Добавляем параметры "источник" события и "параметры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnChainLenChangedHandler(object sender, ChainLenChangedEventArgs e)
        {
            SetRadius(e.Rad);
            Console.WriteLine($"Set {e.Rad:f2} for bead with hash {GetHashCode()}");
        }

    }
}
