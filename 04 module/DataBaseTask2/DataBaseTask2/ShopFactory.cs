using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class ShopFactory : IEntityFactory<Shop>
    {
        private static long _id = 1;

        private string _name;

        public ShopFactory(string name)
        {
            _name = name;
        }

        public Shop Instance => new Shop(_id++, _name);
    }
}
