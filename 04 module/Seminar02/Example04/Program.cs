using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

// https://docs.microsoft.com/ru-ru/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data
namespace Example04
{
    [DataContract]
    public class TestDuplicateDataBase
    {
        [DataMember]
        public int field1 = 123;
    }

    [DataContract]
    public class TestDuplicateDataDerived : TestDuplicateDataBase
    {
        [DataMember]
        public new int field1 = 999;
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestDuplicateDataDerived obj = new TestDuplicateDataDerived();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(
                typeof(TestDuplicateDataDerived));

            using (FileStream fs = new FileStream("people.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, obj); // исключение - одинаковые поля!!!
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                TestDuplicateDataDerived newpeople = (TestDuplicateDataDerived)jsonFormatter.ReadObject(fs);
            }
            Console.ReadLine();
        }
    }
}
