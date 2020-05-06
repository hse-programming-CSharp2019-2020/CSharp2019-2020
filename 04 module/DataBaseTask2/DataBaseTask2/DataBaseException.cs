using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class DataBaseException : Exception
    {
        public DataBaseException()
        {
        }

        public DataBaseException(string message) : base(message)
        {
        }
    }
}
