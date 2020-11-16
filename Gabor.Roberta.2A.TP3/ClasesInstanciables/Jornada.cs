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
    public class Jornada
    {
        #region atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region constructores
        /// <summary>
        /// constructor por default que instancia la lista alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// constructor al que se le pasa parametros y llama al default
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">profesor que dicta la clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion
        /// <summary>
        /// propiedad de escritura y lectura del atributo alumno
        /// </summary>
        #region propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// propiedad de escritura y lectura del atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// propiedad de escritura y lectura del atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Una jornada es igual a un alumno si ese alumno se encuentra en la lista de alumnos d ela jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>true si pertenece a la lista, sino false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool rtn = false;

            if (j.alumnos.Count > 0)
            {
                foreach (Alumno item in j.alumnos)
                {
                    if (item.Equals(a))
                    {
                        rtn = true;
                        break;
                    }
                }
            }


            return rtn;
        }
        /// <summary>
        /// verifica que ese alumno no se encuentra en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Se podra añadir un alumno a una jornada si este no pertenece ya a la misma, sino 
        /// se lanzara una excepcion de tipo AlumnoRepetidoException()
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>La jornada con el almno agregado a la lista si se pudo</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            Jornada aux = new Jornada();
            aux = j;
            if (j != a)
            {
                aux.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return aux;
        }
        /// <summary>
        /// devuelve los datos de los atributos de la jornada, del profesor y de los alummnos completos
        /// </summary>
        /// <returns>string con la informacion</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine($"CLASE DE: {this.clase} POR {this.instructor.ToString()}");
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Guarda los datos de la jornada.ToString en un archivo de tipo txt en el directorio bin/debug del proyecto
        /// </summary>
        /// <param name="jornada">jornada a guardar</param>
        /// <returns>true si se pudo, sino lanza una excepcion de tipo ArchivosException()</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool rtn = false;

            Texto texto = new Texto();

            try
            {
                texto.Guardar("Jornada.txt", jornada.ToString());
                rtn = true;
            }
            catch (Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return rtn;
        }
        /// <summary>
        /// Lee el texto de un archivo y lo guarda en una variable 
        /// </summary>
        /// <returns>devuelve lo leido</returns>
        public static string Leer()
        {
            string informacion;

            Texto texto = new Texto();

            try
            {
                texto.Leer("Jornada.txt", out informacion);
            }
            catch (Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return informacion;
        }
        #endregion

    }
}
