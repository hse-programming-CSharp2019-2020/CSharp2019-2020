using System;
using LibraryTask03;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Conus[] conArr = { new Conus(0,0,0,1,1),
                            new Conus(0,0,0,3,4),
                            new Conus(1,1,1,3,4)};
            foreach (Conus con in conArr)
                Console.WriteLine(con.ToString());
            Console.WriteLine("====== Площади сечений =======");
            Console.WriteLine("Конус 2: " + conArr[1].CrossSection() +
                     "\nКонус 3: " + conArr[2].CrossSection());
            Console.ReadKey();
        }
    }
}
