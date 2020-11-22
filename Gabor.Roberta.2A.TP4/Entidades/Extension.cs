using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public static class Extension
    {
        public static string MostrarMonedas(this Casino tipo)
        {
            StringBuilder sb = new StringBuilder();

            foreach (ETipoMoneda item in Enum.GetValues(typeof(ETipoMoneda)))
            {
                sb.Append(item.ToString()+": $");
                sb.AppendLine(Moneda.SacarPrecio(item).ToString());
            }
            return sb.ToString();
        }
    }
}
