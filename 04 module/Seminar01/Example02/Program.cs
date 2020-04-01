using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/*
Сериализацию можно представить как процесс сохранения состояния объекта в среду хранения. 
Во время этого процесса открытые и закрытые поля объекта и имя класса, включая сборку с классом, 
преобразуются в поток байтов, который затем записывается в поток данных. После десериализации 
объекта создается точная копия исходного объекта. 
https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/binary-serialization
https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/basic-serialization
*/

namespace Example02
{
    [Serializable]
    public class MyObject
    {
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
        public int n3;
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";
           
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
         

            BinaryFormatter formatter1 = new BinaryFormatter();
            Stream stream1 = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            MyObject obj2 = (MyObject)formatter1.Deserialize(stream1);
            stream1.Close();

            // Here's the proof.  
            Console.WriteLine("n1: {0}", obj2.n1);
            Console.WriteLine("n2: {0}", obj2.n2);
            Console.WriteLine("str: {0}", obj2.str);

            Console.ReadKey();
        }
    }
}
