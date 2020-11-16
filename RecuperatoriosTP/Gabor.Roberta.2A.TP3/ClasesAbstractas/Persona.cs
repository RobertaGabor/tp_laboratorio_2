﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region constructores
        /// <summary>
        /// constructor default
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// constructor que recibe parametros
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="nacionalidad">enumerado</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// constructor que recibe parametros e invoca a otro constructor
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">DNI INT</param>
        /// <param name="nacionalidad">enumerado</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// constructor que recibe parametros e invoca a otro constructor
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">DNI STRING</param>
        /// <param name="nacionalidad">enumerado</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region propiedades
        /// <summary>
        /// propiedad que valide que el dni sea del rango addecuado para su nacionalidad
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = Persona.ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// propiedad de ENacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// propiedad que asegura que el apellido solo contenga letras
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// propiedad que asegura que el nombre solo contenga letras
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// propiedad que verifica que el dni, solo contenga espacion o puntos y numeros, y que sea del rango adecuado a su nacionalidad
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region validaciones
        /// <summary>
        /// valida que el dni vaya del rango adecuado segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">enumerado</param>
        /// <param name="dato">DNI INT</param>
        /// <returns>devuelve el numero si esta correcto, sino lanza excepcion de tipo NacionalidadInvalidaException()</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }
        /// <summary>
        /// verifica que el dni solo tenga . y espacios y numeros, sino lanza DniInvalidoException(), luego corrobora con ValidarDni de int
        /// </summary>
        /// <param name="nacionalidad">enumerado</param>
        /// <param name="dato">DNI STRING</param>
        /// <returns>el DNI en forma de int sino lanzara excepcion de tipo NacionalidadInvalidaException()</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");
            int numeroDni;

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());

            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }
        /// <summary>
        /// valida que el nombre solo contenga letras, sino devuelve cadena vacia
        /// </summary>
        /// <param name="dato">string a corroborar</param>
        /// <returns>el dato si se pudo sino espacio en blanco</returns>
        private static string ValidarNombreApellido(string dato)
        {
            bool pudo = Regex.IsMatch(dato, @"^[a-zA-Z]+$");
            if (pudo)
            {
                return dato;
            }

            return "";
        }
        #endregion

        #region metodos
        /// <summary>
        /// devuelve los atributos y su informacion como string
        /// </summary>
        /// <returns>string de los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NUMERO DNI: {this.dni}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad.ToString()}");
            return sb.ToString();
        }
        #endregion
        /// <summary>
        /// enumerados de nacionalidad
        /// </summary>
        #region enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
