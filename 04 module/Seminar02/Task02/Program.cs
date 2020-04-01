using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Task02
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; set; }
        public Human() { }
        public Human(string name)
        {
            this.Name = name;
        }
    }

    [DataContract]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
    }

    [DataContract]
    public class Dept
    {
        [DataMember]
        public string DeptName { get; set; }
        [DataMember]
        List<Human> staff;
        [DataMember]
        public List<Human> Staff { get { return staff; } set { staff = value;  } }
        public Dept() { }
        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            staff = new List<Human>(staffList);
        }
    }
    [DataContract]
    public class University
    {
        [DataMember]
        public string UniversityName { get; set; }
        [DataMember]
        public List<Dept> Departments { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            University HSE = new University();
            HSE.UniversityName = "NRU HSE";

            Professor[] deptStaff = { new Professor("Ivanov"),
                      new Professor("Petrov")
                    };

            Dept SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept>();
            HSE.Departments.Add(SE);

            DataContractJsonSerializer binformatter = 
                new DataContractJsonSerializer(typeof(University),
                new Type[] { typeof(Professor)});

            // Сериализация
            using (Stream file = new FileStream("BinSer.dat",
                   FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binformatter.WriteObject(file, HSE);
            }
            // Десериализация
            University HSEdeserial;
            using (Stream file = File.OpenRead("BinSer.dat"))
            {
                HSEdeserial = (University)binformatter.ReadObject(file);
                Console.WriteLine("Binary - " + HSEdeserial.UniversityName);
            }
            foreach (Dept d in HSEdeserial.Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }
            Console.ReadKey();
        }
    }
}
