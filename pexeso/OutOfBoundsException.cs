using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pexeso
{
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException()
        {}
        public OutOfBoundsException(string message) : base(message)
        {}
        public OutOfBoundsException(string message, Exception e):base(message, e)
        {}
    }
}