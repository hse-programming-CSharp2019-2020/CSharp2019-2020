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
                BeadRadiusChangedEvent?.Invoke(r);
                // TODO 1 - end
            }
        }

        private void SetRadius(double value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Радиус бусины не может быть меньше или равен нулю");
            r = value;
        }

        public event BeadRadiusChanged BeadRadiusChangedEvent;  // TODO 1 

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
    }
}
