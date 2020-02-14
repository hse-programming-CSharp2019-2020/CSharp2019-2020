using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    /// <summary>
    /// Класс-подписчик, где определен метод переноса строки
    /// </summary>
    class Subscriber
    {
        /// <summary>
        /// Переносит строку
        /// </summary>
        public static void LineBreakHappenedHandler()
        {
            Console.WriteLine(); //перенос строки
        }
    }
}
