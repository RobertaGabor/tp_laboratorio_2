using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
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
            char x;
            char operadorValido;
            double respuesta=0;
            
            if(string.IsNullOrEmpty(operador)==false)    
            {   
                x = char.Parse(operador);
                operadorValido = char.Parse(Calculadora.ValidarOperador(x));
                switch (operadorValido)
                {
                    case '+':
                        respuesta = num1 + num2;
                        break;
                    case '-':
                        respuesta = num1 - num2;
                        break;
                    case '*':
                        respuesta = num1 * num2;
                        break;
                    case '/':
                        respuesta = num1 / num2;
                        break;
                }
                
            }
            else
            {
                respuesta = -1;
            }
            
            return respuesta;
        }
    }
}
