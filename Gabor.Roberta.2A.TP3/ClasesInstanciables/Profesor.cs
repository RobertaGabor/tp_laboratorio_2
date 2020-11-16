using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Archivos;
using System.Runtime.CompilerServices;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor default
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// Constructor default que instancia un numero random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor al que recibe parametros, instancia la cola, y genera 2 clases random para el profesor
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI STRING</param>
        /// <param name="nacionalidad">Enumerado</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClase();
            this.randomClase();
        }
        #endregion

        #region metodos
        /// <summary>
        /// Coloca en la cola del profesor seleccionado 1 clase random del enum de Clases
        /// </summary>
        public void randomClase()
        {
            int numeroIndice;
            numeroIndice = Profesor.random.Next(0, 3);
            this.clasesDelDia.Enqueue((Universidad.EClases)numeroIndice);
        }
        /// <summary>
        /// informa las clases que tiene en cola el profesor
        /// </summary>
        /// <returns>CLASES DEL DIA: + las clases</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASES DEL DIA: ");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.Append($"{clases.ToString()}, ");
            }
            return sb.ToString();
        }
        /// <summary>
        /// devuelve los datos de atributos de la clase base y los datos de atributos propios
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// llama a MostrarDatos()
        /// </summary>
        /// <returns>string devuelto por MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un profesor es igual a una clase si este profesor tiene en la cola de clases el parametro de la clase
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns>true si parte la clase, false si no</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool rtn = false;
            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if (item==clase)
                {
                    rtn = true;
                }
            }

            return rtn;
        }
        /// <summary>
        /// verifica que ese profesor no tenga esa clase
        /// </summary>
        /// <param name="i">profesir</param>
        /// <param name="clase">clase</param>
        /// <returns>true si no a tiene sino false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
