using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;


namespace ClasesAbstractas
{
    public abstract class Universitario:Persona
    {
        #region atributos
        private int legajo;
        #endregion

        #region constructores
        /// <summary>
        /// constructor al que se le pasa parametros y llama a constructor padre
        /// </summary>
        /// <param name="legajo">legajo</param>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">dni</param>
        /// <param name="nacionalidad">enumerado</param>
        public Universitario(int legajo, string nombre,string apellido,string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// constructor default
        /// </summary>
        public Universitario()
            :base()
        {
        }
        #endregion

        #region metodos
        /// <summary>
        /// muestra datos de atributos de clase base y atributos propios
        /// </summary>
        /// <returns>devuelve uns tring con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO: {this.legajo}");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
        /// <summary>
        /// dos clases universitario o hijas de este, seran iguales si son del mismo tipo hijo y tienen mismo legajo o dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool rtn = false;
            if(pg1.GetType()==pg2.GetType()&&(pg1.legajo==pg2.legajo||pg1.DNI==pg2.DNI))
            {
                rtn = true;
            }
            return rtn;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        public override bool Equals(object obj)
        {
            bool rtn = false;
            if(obj is Universitario)
            {
                rtn = this == (Universitario)obj;
            }

            return rtn;
        }
        #endregion

    }
}
