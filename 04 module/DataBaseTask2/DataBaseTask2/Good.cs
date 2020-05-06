using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Good : IEntity
    {
        public long Id { get; }

        public string Name { get; }

        public long ShopId { get; }

        public Good(long id, string name, long shopId)
        {
            Id = id;
            Name = name;
            ShopId = shopId;
        }
    }
}
