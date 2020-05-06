using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Shop : IEntity
    {
        public long Id { get; }
        public string Name { get; }

        public Shop(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
