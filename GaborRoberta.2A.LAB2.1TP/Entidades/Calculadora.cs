using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            string validated="+";
            if(operador=='+'|| operador == '-' || operador == '*' || operador == '/')
            {
                validated = (Convert.ToString(operador));
            }
            return validated;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char op = Convert.ToChar(operador);
            operador = Calculadora.ValidarOperador(op);
            Console.WriteLine(operador);

            return 12;
        }


    }
}
