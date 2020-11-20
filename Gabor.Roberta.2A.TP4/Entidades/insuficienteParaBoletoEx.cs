using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class insuficienteParaBoletoException : Exception
    {
        public insuficienteParaBoletoException()
            : base("No le alcanzan las monedas de bronce para comprar Boletos, cada boleto cuesta 5")
        {
        }
        public insuficienteParaBoletoException(string message)
            : this(message, null)
        {

        }
        public insuficienteParaBoletoException(Exception e)
            : base("No le alcanzan las monedas de bronce para comprar Boletos, cada boleto cuesta 5", e)
        {

        }
        public insuficienteParaBoletoException(string message, Exception e)
            : base("No le alcanzan las monedas de bronce para comprar Boletos, cada boleto cuesta 5:" + message, e)
        {

        }
    }
}
