using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Exceptions
{
    internal class NegocioExeption : Exception
    {
       
        public NegocioExeption()
        {
        }

        
        public NegocioExeption(string message)
            : base(message)
        {
        }

        
        public NegocioExeption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
