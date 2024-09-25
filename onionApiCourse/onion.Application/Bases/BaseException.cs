using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Bases
{
    public class BaseException : ApplicationException
    {
        public BaseException()
        {
        }

        public BaseException(String message) : base(message) { }
        

    }
}
