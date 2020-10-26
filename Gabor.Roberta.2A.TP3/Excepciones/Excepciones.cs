using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
    }
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            : base("El DNI ingresado no es un número válido")
        {
        }
        public DniInvalidoException(string message)
            : this(message, null)
        {

        }
        public DniInvalidoException(Exception e)
            : base("El DNI ingresado no es un número válido", e)
        {

        }
        public DniInvalidoException(string message, Exception e)
            : base("El DNI ingresado no es un número válido:" + message, e)
        {

        }
    }
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se coindice con el DNI")
        {
        }
        public NacionalidadInvalidaException(string message)
            : base("La nacionalidad no se condice con el número de DNI: " + message)
        {
        }
    }
    public class SinProfesorException : Exception
    {
    }
    public class ArchivosException : Exception
    {
    }

}
