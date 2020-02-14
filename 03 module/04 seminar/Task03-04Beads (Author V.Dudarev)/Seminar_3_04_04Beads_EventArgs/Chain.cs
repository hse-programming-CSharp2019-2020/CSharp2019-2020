using System;
using System.Collections.Generic;
using System.Linq;

namespace Seminar_3_04_03_04Beads
{
    //public delegate void ChainLenChanged(double r);
    //public delegate void BeadsCountChanged(double r);

    /// <summary>
    /// цепочка бусин 
    /// </summary>
    public class Chain
    {
        /// <summary>
        /// длина нити, на которую нанизаны бусины
        /// </summary>
        double len;
        /// <summary>
        /// длина нити, на которую нанизаны бусины
        /// </summary>
        public double Len { get => len; 
            set {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Длина нити не может быть меньше или равна нулю");
                len = value;
                // сгенерируем событие изменения длины нити
                double r = GetBeadRadius(len, beads.Count);
                Console.WriteLine($"ChainLenChangedEvent(len={len:f2} => r={r:f2}): ");

                //ChainLenChangedEvent?.Invoke(r);
                // 4 шаг. Изменяем код запуска события, там где он производился
                OnChainLenChanged(new ChainLenChangedEventArgs(r));
            }
        }

        /// <summary>
        /// количество бусин
        /// </summary>
        public int N
        {
            get => beads.Count();
            set {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Количество бусин не может быть меньше или равно нулю");
                if (value > beads.Count) { // добавим бусин
                    CreateBeads(value - beads.Count);
                }
                else if (value < beads.Count) { // удалим бусины
                    RemoveBeads(beads.Count - value);
                }
                else {
                    return; // не надо генерить событие, ведь N не изменилось по факту!
                }
                // сгенерируем событие изменения количества бусин на нити
                double r = GetBeadRadius(len, beads.Count);
                Console.WriteLine($"BeadsCountChangedEvent(N={N} => r={r:f2}): ");
                //BeadsCountChangedEvent?.Invoke(GetBeadRadius(len, beads.Count));
                OnChainLenChanged(new ChainLenChangedEventArgs(GetBeadRadius(len, beads.Count)));
            }
        }

        /// <summary>
        /// расчет радиуса бусины
        /// </summary>
        /// <param name="len">длина нити</param>
        /// <param name="N">количество бусин</param>
        /// <returns></returns>
        public double GetBeadRadius(double len, int N) {
            // return Math.Floor(len / N);
            return len / N;
        }


        /// <summary>
        /// список, составленный из бусин, нанизанных на нить
        /// </summary>
        readonly List<Bead> beads = new List<Bead>();
        /// <summary>
        /// список, составленный из бусин, нанизанных на нить
        /// </summary>
        public List<Bead> Beads => beads;

        /// <summary>
        /// событие изменения длины нити
        /// 2 шаг  описываем событие.
        /// Используем предусмотренный обобщённый делегат
        /// </summary>
        //public event ChainLenChanged ChainLenChangedEvent;
        public event EventHandler<ChainLenChangedEventArgs> ChainLenChangedEvent;

        // 3 шаг. В класс Chain добавляем метод запуска события
        protected virtual void OnChainLenChanged(ChainLenChangedEventArgs e)
        {
            ChainLenChangedEvent?.Invoke(this, e);
        }


        /// <summary>
        /// событие изменения количества бусин на нити
        /// </summary>
        //public event BeadsCountChanged BeadsCountChangedEvent;
        public event EventHandler<ChainLenChangedEventArgs> BeadsCountChangedEvent;
        // 3 шаг. В класс Chain добавляем метод запуска события
        protected virtual void OnBeadsCountChanged(ChainLenChangedEventArgs e)
        {
            BeadsCountChangedEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Конструктор с двумя параметрами – вещественной длиной нити len и целым числом N бусин в цепочке.
        /// Создание бусин выполняет вспомогательный метод CreateBeads(). 
        /// </summary>
        public Chain(double len, int N)
        {
            Len = len;
            CreateBeads(N);
        }

        /// <summary>
        /// создаёт объекты-бусины и добавляет их методы-обработчики в список обработчиков события ChainLenChangedEvent
        /// </summary>
        /// <param name="n">количество бусин, которое надо добавить</param>
        private void CreateBeads(int n) {
            double r = GetBeadRadius(Len, n); // радиус одной бусины
            for (int i = 0; i < n; i++)
            {
                Bead b = new Bead(r);
                // ChainLenChangedEvent += b.ChainLenChanged;
                //BeadsCountChangedEvent += b.ChainLenChangedHandler;
                //b.BeadRadiusChangedEvent += ChildBeadRadiusChangedHandler;
                ChainLenChangedEvent += b.OnChainLenChangedHandler;
                BeadsCountChangedEvent += b.OnChainLenChangedHandler;
                b.BeadRadiusChangedEvent += OnChildBeadRadiusChangedHandler;
                beads.Add(b);
            }
        }

        /// <summary>
        /// удаляет объекты-бусины
        /// </summary>
        /// <param name="n">количество бусин, которое надо удалить</param>
        private void RemoveBeads(int n)
        {
            double r = GetBeadRadius(Len, n); // радиус одной бусины
            for (int i = 0; i < n; i++)
            {
                Bead b = beads[beads.Count - 1];
                // ОЧЕНЬ важно отписать бусины от событий перед их удалением с нити (если не отписать, то они продолжат получать события и по факту будут жить, пока живет нить...)
                //ChainLenChangedEvent -= b.ChainLenChanged;
                //BeadsCountChangedEvent -= b.ChainLenChangedHandler;
                //b.BeadRadiusChangedEvent -= ChildBeadRadiusChangedHandler;
                ChainLenChangedEvent -= b.OnChainLenChangedHandler;
                BeadsCountChangedEvent -= b.OnChainLenChangedHandler;
                b.BeadRadiusChangedEvent -= OnChildBeadRadiusChangedHandler;
                beads.Remove(b);
            }
        }

        /// <summary>
        /// обработчик события изменения радиуса рдной из бусин.
        /// При этом надо (сохраняя длину нити) рассчитать новое количество бусин N (этого же нового радиуса, которые поместятся на нити)
        /// </summary>
        /// <param name="r"></param>
        private void ChildBeadRadiusChangedHandler(double r) {
            if (r <= 0)
                throw new ArgumentOutOfRangeException(nameof(r), "Радиус бусины не может быть меньше или равен нулю");
            int n = (int)Math.Floor(Len / r);
            if (n <= 0)
                throw new ArgumentOutOfRangeException(nameof(n), "Количество бусин не может быть равно нулю");
            N = n;  // вот тут реально изменится количество бусин и они ВСЕ получат новый радиус (т.к. событие BeadsCountChangedEvent сработает)
        }

        /// <summary>
        /// обработчик события изменения радиуса рдной из бусин.
        /// При этом надо (сохраняя длину нити) рассчитать новое количество бусин N (этого же нового радиуса, которые поместятся на нити)
        /// </summary>
        /// <param name="r"></param>
        private void OnChildBeadRadiusChangedHandler(object sender, ChainLenChangedEventArgs e)
        {
            if (e.Rad <= 0)
                throw new ArgumentOutOfRangeException(nameof(e.Rad), "Радиус бусины не может быть меньше или равен нулю");
            int n = (int)Math.Floor(Len / e.Rad);
            if (n <= 0)
                throw new ArgumentOutOfRangeException(nameof(n), "Количество бусин не может быть равно нулю");
            N = n;  // вот тут реально изменится количество бусин и они ВСЕ получат новый радиус (т.к. событие BeadsCountChangedEvent сработает)
        }

        /// <summary>
        /// информация о нити
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            $"Цепочка бусин. Количество бусин: {beads.Count}, длина нити: {Len:f2}, радиус бусины: {GetBeadRadius(Len, beads.Count):f2}";
    }
}
