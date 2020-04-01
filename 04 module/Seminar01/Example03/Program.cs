using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

/*
Протокол SOAP (Simple Object Access Protocol) представляет простой протокол для обмена данными 
между различными платформами. При такой сериализации данные упакуются в конверт SOAP, данные в 
котором имеют вид xml-подобного документа. 

Сериализацию можно представить как процесс сохранения состояния объекта в среду хранения. 
Во время этого процесса открытые и закрытые поля объекта и имя класса, включая сборку с классом, 
преобразуются в поток байтов, который затем записывается в поток данных. После десериализации 
объекта создается точная копия исходного объекта. 
https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/binary-serialization
https://docs.microsoft.com/ru-ru/dotnet/standard/serialization/basic-serialization
*/

namespace Example03
{
    [Serializable]
    public class MyObject
    {
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";

            SoapFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream("MyFile2.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();

            SoapFormatter formatter1 = new SoapFormatter();
            Stream stream1 = new FileStream("MyFile2.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            MyObject obj2 = (MyObject)formatter1.Deserialize(stream1);
            stream.Close();

            // Here's the proof.  
            Console.WriteLine("n1: {0}", obj2.n1);
            Console.WriteLine("n2: {0}", obj2.n2);
            Console.WriteLine("str: {0}", obj2.str);

            Console.ReadKey();
        }
    }
}
