using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;



namespace MainConsolaDePrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculadora.Operar(3, 4, "*");
            double num = 34.8;
            num = Math.Round(num);
            Console.WriteLine(num);

            Numero ejemplo = new Numero();
            string decimale;
            decimale=ejemplo.BinarioDecimal("11");/*ver que pasa si esta en blanco*/
            Console.WriteLine(decimale);

            Console.ReadKey(true);
        }
    }
}
