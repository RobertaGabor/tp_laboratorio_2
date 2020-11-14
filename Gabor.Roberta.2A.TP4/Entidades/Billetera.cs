using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Billetera<T> where T:Moneda
    {
        private int cantidad;
    }
}
