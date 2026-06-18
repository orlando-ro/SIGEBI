using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Exceptions
{
    internal class NegocioExeption : Exception
    {
       
        public NegocioException()
        {
        }

        
        public NegocioException(string message)
            : base(message)
        {
        }

        
        public NegocioException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
