using System;

namespace Seminar_3_04_03_04Beads
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAllEvents();
        }

        /// <summary>
        /// тестируем все три типа событий с бусинами
        /// </summary>
        private static void TestAllEvents()
        {
            try
            {
                Chain ch = new Chain(100, 11);
                // установим новую длину нити
                ch.Len = 150;
                // изменим количество бусин (увеличим - добавим бусины)
                ch.N = 20;
                // изменим количество бусин (уменьшим - удалим бусины)
                ch.N = 5;
                // установим радиус любой бусины из списка => уменьшим количество бусин и установим всем одинаковые радиусы...
                ch.Beads[0].R = 50;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
