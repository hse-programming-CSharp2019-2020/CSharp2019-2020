using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    interface IEntityFactory<out T>
    {
        T Instance { get; }
    }
}
