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
    public sealed class Alumno:Universitario
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

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        #endregion

        #region enumerados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }



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
            if (i.clasesDelDia.Contains(clase))
            {
                rtn = true;
            }
            return rtn;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }



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
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region propiedades
        public List<Alumno>  Alumnos
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
        public static bool operator==(Jornada j, Alumno a)
        {
            bool rtn = false;

            if(j.alumnos.Count>0)
            {
                foreach(Alumno item in j.alumnos)
                {
                    if(item.Equals(a))
                    {
                        rtn = true;
                        break;
                    }
                }
            }


            return rtn;
        }

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
            if (j!=a)
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
            foreach(Alumno item in this.alumnos)
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
            catch(Excepciones.ArchivosException e)
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
