using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class GoodFactory : IEntityFactory<Good>
    {
        private static long _id = 0;

        private string _name;

        private long _shopId;

        public GoodFactory(string name, long shopId)
        {
            _name = name;
            _shopId = shopId;
        }

        public Good Instance => new Good(_id++, _name, _shopId);
    }
}
