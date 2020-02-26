using System;
using System.Collections.Generic;
using System.Text;

namespace Lib5
{
    public struct SetOfMassPoint
    { // Множество материальных точек
        MassPoint[] set;    // набор точек множества
        double rad;         // радиус множества
                            // Конструктор выбирает из массива точки: 
        public SetOfMassPoint(MassPoint[] collection, PointS ps, double rad)
        {
            List<MassPoint> list = new List<MassPoint>();
            foreach (MassPoint mp in collection)
                if ((mp.coord.distance(ps) <= rad)) list.Add(mp);
            set = list.ToArray();
            this.rad = rad;
        }
        // Свойство формирует центр масс множества материальных точек:
        public MassPoint MassCenter
        {
            get
            {
                double xc = 0, yc = 0, mc = 0;
                foreach (MassPoint mp in set)
                {
                    mc += mp.Mass;
                    xc += mp.Mass * mp.coord.X;
                    yc += mp.Mass * mp.coord.Y;
                }
                return new MassPoint(new PointS(xc / mc, yc / mc), mc);
            }
        } // MassCenter
    }

}
