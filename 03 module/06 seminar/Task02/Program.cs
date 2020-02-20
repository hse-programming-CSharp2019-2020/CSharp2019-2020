using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task02
{
    interface A
    {
        void Do();
    }
    class B
    {
        public void Do()
        {
            Console.WriteLine("Do from B");
        }
    }
    class C : B, A
    {
        public void Do()
        {
            Console.WriteLine("Do from C");
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Main()
        {
            logger.Trace("trace message");
            logger.Debug("debug message");
            logger.Info("info message");
            logger.Warn("warn message");
            logger.Error("error message");
            logger.Fatal("fatal message");
            B b = new C();
            b.Do();

            C c = new C();
            c.Do();

            Console.ReadKey();
        }
    }
}
