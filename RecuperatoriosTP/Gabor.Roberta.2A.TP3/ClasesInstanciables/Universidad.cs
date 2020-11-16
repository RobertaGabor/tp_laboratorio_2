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
    public class Universidad
    {
        #region atributos
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;
        #endregion

        #region constructores
        /// <summary>
        /// constructor default que instancia las 3 listas de la clase
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornadas = new List<Jornada>();
        }
        #endregion

        #region propiedades
        /// <summary>
        /// propiedad se lectura y escritura de atributos alumnos
        /// </summary>
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
        /// propiedad se lectura y escritura de atributos profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// propiedad se lectura y escritura de atributos jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }
        /// <summary>
        /// Propiedad lectura y escritura al atributo jornadas con un indexador
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                if ((i>=0&&i<this.jornadas.Count)&&this.jornadas.Count>0)
                {
                    return this.jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0&&i< this.jornadas.Count)
                {
                    this.jornadas[i] = value;
                }
                else
                {
                    this.jornadas[i] = null;
                }

            }

        }

        #endregion

        #region metodos
        /// <summary>
        /// un alumno sera igual a una universidad si este asiste a ella y pertenece a la lista de alumnos
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>true si esta, sino false</returns>
        public static bool operator ==(Universidad g,Alumno a)
        {
            bool rtn = false;
            if(g.alumnos.Count>0)
            {
                foreach(Alumno item in g.alumnos)
                {
                    if(item.Equals(a))
                    {
                        rtn = true;
                    }
                }
            }
            return rtn;
        }
        /// <summary>
        /// verifica que el alumno no pertenezca a la universidad
        /// </summary>
        /// <param name="g">alumno</param>
        /// <param name="a">universidad</param>
        /// <returns>true si no pertenece sino false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// un aprofesor sera igual a una universidad si este enseña en ella y pertenece a la lista de profesores
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="p">profesor</param>
        /// <returns>true si enseña ahi, sino false</returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            bool rtn = false;
            if (g.profesores.Count > 0)
            {
                foreach (Profesor item in g.profesores)
                {
                    if (item.Equals(p))
                    {
                        rtn = true;
                    }
                }
            }
            return rtn;
        }
        /// <summary>
        /// verifica que un profesor no pertenezca a la universidad
        /// </summary>
        /// <param name="g">profesir</param>
        /// <param name="p">universidad</param>
        /// <returns>true si no pertenece sino false</returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        /// <summary>
        /// una universidad sera igual a una clase si hay al menos un profesor que dicta esa clase, si no hay, lanzara
        /// una excepcion de tipo SinProfesorException()
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="c">profesor</param>
        /// <returns>devuelve el priemr profesor que dicta esa clase, sino lanza la exccpcion</returns>
        public static Profesor operator ==(Universidad g, Universidad.EClases c)
        {
            bool ok = false;
            Profesor aux = new Profesor();
            foreach(Profesor item in g.profesores)
            {
                if(item==c)
                {
                    ok = true;
                    aux = item;
                    break;
                }

            }
            if(ok)
            {
                return aux;
            }
            else
            {
                throw new Excepciones.SinProfesorException();
            }
        }
        /// <summary>
        /// seran distintas si no hay ningun profesor que de la clase y se lance la excepcion
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="c">profesor</param>
        /// <returns>devovlera un profesor nulo si encontro un profesor que dicte la clase, sino el primer
        /// profesor que no de esa clase</returns>
        public static Profesor operator !=(Universidad g, Universidad.EClases c)
        {
            Profesor p= new Profesor();
            try
            {
                p = g == c;
                p = null;
            }
            catch(Excepciones.SinProfesorException)
            {
                foreach (Profesor item in g.profesores)
                {
                    if (item != c)
                    {
                       p = item;
                       break;
                    }

                }
            }
            return p;
        }
        /// <summary>
        /// se podra agregar una clase a la universidad, generando una jornada que dicte esa clase y un profesor; se agregan alumnos 
        /// que atiendan a esa materia
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="c">clase</param>
        /// <returns>Universidad con una jornada de esa clase</returns>
        public static Universidad operator +(Universidad g, Universidad.EClases c)
        {
            try
            {
                Jornada jornada = new Jornada(c, g == c);
                Universidad aux = new Universidad();
                aux = g;
                foreach (Alumno item in g.alumnos)
                {
                    if (item == c)
                    {

                      jornada += item;/*no dejar la jornada sin alumnos para poder recorrer universidad*/
                        //solo se agregan a 1 jornada toda una clase??
                    }
                }
                aux.jornadas.Add(jornada);
                return aux;
            }
            catch(Excepciones.SinProfesorException)
            {
                throw new Excepciones.SinProfesorException();
            } 
        }
        /// <summary>
        /// se podra agregar un profesor a la universidad si este no pertenece ya a ella
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>true si se agrego sino false</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            Universidad aux = new Universidad();
            aux = g;
            if(g!=i)
            {
                aux.profesores.Add(i);
            }
            return aux;
        }
        /// <summary>
        /// se podra agregar un alumno a la universidad si este no pertenece ya a ella
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>true si se agrego sino false</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g==a)
            {
                throw new Excepciones.AlumnoRepetidoException();
            }
            else
            {
                Universidad aux = new Universidad();
                aux = g;
                aux.alumnos.Add(a);
                return aux;
            }
        }
        /// <summary>
        /// Muestra Los datos de todas las jornadas
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>informacion devuelta por Jornada.ToString</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Jornada item in uni.jornadas)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<------------------------------------->");
            }
            return sb.ToString();
        }
        /// <summary>
        /// llama a MostrarDatos()
        /// </summary>
        /// <returns>lo devuelto por la funcion a la cual llama</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda en un archivo de xml los datos de la universidad devuelto por MostrarDatos() de universidad
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>true si se pudo sino excepciond e tipo ArchivosException()</returns>
        public static bool Guardar(Universidad uni)
        {
            bool rtn = false;

            Xml<Universidad> aux = new Xml<Universidad>();
  
            try
            {
                aux.Guardar("Universidad.xml", uni);
                rtn = true;
            }
            catch (Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return rtn;
        }
        /// <summary>
        /// Lee un archivo tipo xml y lo guarda en una variable de tipo Universidad
        /// </summary>
        /// <returns>true si se leyo bien, sino una excepcion de tipo ArchivosException()</returns>
        public static Universidad Leer()
        {
            Universidad informacion=new Universidad();
         
            Xml<Universidad> aux = new Xml<Universidad>();
     
            try
            {
                aux.Leer("Universidad.xml", out informacion);
            }
            catch (Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }

            return informacion;
        }
        #endregion
        /// <summary>
        /// enumerados de clases
        /// </summary>
        #region enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
