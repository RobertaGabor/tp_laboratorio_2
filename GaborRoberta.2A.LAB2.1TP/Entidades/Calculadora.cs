using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region metodos
        /// <summary>
        /// Valida que el operador solo sea uno de esos caracteres
        /// </summary>
        /// <param name="operador">char a analizar</param>
        /// <returns>Si es uno de los operadores correctos devuelve el char en string, sino devuelve un + en tipo string</returns>
        private static string ValidarOperador(char operador)
        {
            string validated="+";
            if(operador=='+'|| operador == '-' || operador == '*' || operador == '/')
            {
                validated = (Convert.ToString(operador));
            }
            return validated;
        }

        /// <summary>
        /// Verifica que el operador sea correcto, y realizar la operacion perteneciente a ese operador con los atributos double de esos objetos
        /// </summary>
        /// <param name="num1">primer objeto de tipo Numero</param>
        /// <param name="num2">segundo objeto de tipo Numero</param>
        /// <param name="operador">operador de la cuenta</param>
        /// <returns>devuelve -1 si el operador esta null sino devuelve el valor d ela operacion</returns>
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
        #endregion
    }
}
