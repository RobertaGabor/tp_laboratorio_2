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
            : base("El DNI ingresado no es un número válido")
        {
        }
        public cantidadInvalidaException(string message)
            : this(message, null)
        {

        }
        public cantidadInvalidaException(Exception e)
            : base("El DNI ingresado no es un número válido", e)
        {

        }
        public cantidadInvalidaException(string message, Exception e)
            : base("El DNI ingresado no es un número válido:" + message, e)
        {

        }
    }
}
