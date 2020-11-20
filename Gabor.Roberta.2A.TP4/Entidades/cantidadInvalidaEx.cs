using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class cantidadInvalidaException : Exception
    {
        public cantidadInvalidaException()
            : base("La cantidad ingresada no es un número válido")
        {
        }
        public cantidadInvalidaException(string message)
            : this(message, null)
        {

        }
        public cantidadInvalidaException(Exception e)
            : base("La cantidad ingresada no es un número válido", e)
        {

        }
        public cantidadInvalidaException(string message, Exception e)
            : base("La cantidad ingresada no es un número válido:" + message, e)
        {

        }
    }
}
