using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuresLib3;

namespace Task03
{
    class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            int n = 10;
            CircleS[] circleS = new CircleS[n];

            for (int i = 0; i < circleS.Length; i++)
            {
                circleS[i] = new CircleS(random.NextDouble() + random.Next(-10, 10),
                                            random.NextDouble() + random.Next(-10, 10),
                                            random.NextDouble() + random.Next(0, 10));
                Console.WriteLine(circleS[i].ToString());
            }
            Console.WriteLine();

            Array.Sort(circleS);

            foreach(CircleS a in circleS)
            {
                Console.WriteLine(a.ToString());
            }
            PointS center = new PointS(0, 0);

            Console.WriteLine();
            Array.Sort(circleS, (CircleS a, CircleS b) => 
                {
                    if (a.Center.distance(center) > b.Center.distance(center)) {
                        return 1;
                    }
                    if (a.Center.distance(center) < b.Center.distance(center)) {
                        return -1;
                    }
                    return 0;
                }
            );

            foreach (CircleS a in circleS)
            {
                Console.WriteLine(a.ToString());
            }

            Array.Sort(circleS);
            Console.WriteLine();

            double[] keys = new double[n];

            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = circleS[i].Center.distance(center);
            }

            Array.Sort(keys, circleS);

            foreach (CircleS a in circleS)
            {
                Console.WriteLine(a.ToString() + " " + a.Center.distance(center));
            }
            
            Console.ReadKey();
        }
    }
}
