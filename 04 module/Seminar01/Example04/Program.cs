using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/*
https://professorweb.ru/my/csharp/thread_and_files/level4/4_2.php
*/
namespace Example04
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        [NonSerialized]
        public string radioID = "XF-552RF6";
    }
    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondClass : Car
    {
        public bool canFly;
        public bool canSubmerge;
    }

    class Program
    {
        static void Main(string[] args)
        {
            JamesBondClass jbc = new JamesBondClass();
            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;
            // Сохранить объект в указанном файле в двоичном формате
            SaveBinaryFormat(jbc, "carData.txt");
            Console.ReadLine();
        }

        static void SaveBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("--> Сохранение объекта в Binary format");
        }
    }
}
