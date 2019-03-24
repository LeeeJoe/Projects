using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class ListException : Exception
    {
        public ListException(string message) : base(message)
        {
            
        }

        public ListException() : this("Undefined ListException.")
        {

        }

        public ListException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
