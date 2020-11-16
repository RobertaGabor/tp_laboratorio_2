using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class dniInvalidoException : Exception
    {
        public dniInvalidoException()
            : base("El DNI ingresado no es un número válido")
        {
        }
        public dniInvalidoException(string message)
            : this(message, null)
        {

        }
        public dniInvalidoException(Exception e)
            : base("El DNI ingresado no es un número válido", e)
        {

        }
        public dniInvalidoException(string message, Exception e)
            : base("El DNI ingresado no es un número válido:" + message, e)
        {

        }
    }
}
