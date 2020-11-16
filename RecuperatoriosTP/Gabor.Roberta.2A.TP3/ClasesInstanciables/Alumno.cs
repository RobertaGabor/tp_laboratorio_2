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
    public sealed class Alumno : Universitario
    {
        #region atributos 
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor default
        /// </summary>
        public Alumno()
            :base()
        {
        }
        /// <summary>
        /// Constructor al que recibe parametros y llama a otro constructor
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI STRING</param>
        /// <param name="nacionalidad">Enumerado</param>
        /// <param name="clasesQueToma">Enumerado</param>
        /// <param name="estadoCuenta">Enumerado</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Constructor al que recibe parametros y llama al constructor de la clase padre
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellidp</param>
        /// <param name="dni">DNI STRING</param>
        /// <param name="nacionalidad">enumerado</param>
        /// <param name="clasesQueToma">enumerado</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Devuelve un string con la clase que toma el alumno
        /// </summary>
        /// <returns>string TOMA CLASE DE: + la clase del alumno</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE: {this.claseQueToma.ToString()}";
        }
        /// <summary>
        /// Muestra los atributos de la clase padre y propios de la clase
        /// </summary>
        /// <returns>String con todos los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");
            return sb.ToString();
        }
        /// <summary>
        /// Llama a MostrarDatos() 
        /// </summary>
        /// <returns>string con lo devuelto por la clase la cual llama</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Hace saber si un alumno toma determinada clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true si toma la clase y no es deudor, false lo contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool rtn = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                rtn = true;
            }
            return rtn;
        }
        /// <summary>
        /// verifica ese alumno no tome esa clase
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>true si no toma la clase sino false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        #endregion
        /// <summary>
        /// enumerado de estado de cuenta
        /// </summary>
        #region enumerados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
