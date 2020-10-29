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
        public Alumno()//DEFAULT SIN HACER
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma;
        }
        #endregion

        #region metodos
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE: {this.claseQueToma.ToString()}";
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)//CHEQUEAR SI DEBE SER != NULL
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
        public Profesor()//PORQUE?????
        {
        }
        static Profesor()//PRIVADA X DEFAULT
        {
            Profesor.random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClase();
            this.randomClase();
        }
        #endregion

        #region metodos
        public void randomClase()
        {
            int numeroIndice;
            numeroIndice = Profesor.random.Next(0, 3);      
            this.clasesDelDia.Enqueue((Universidad.EClases)numeroIndice);
        }
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

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool rtn = false;
            if (i.clasesDelDia.Contains(clase))//NO HACE FALTA VER NULL PORQUE VA A TENER 2 CLASES MINIMO
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
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"PROFESOR: {this.instructor}");
            sb.AppendLine($"CLASE: {this.clase}");
            sb.AppendLine("ALUMNOS:");
            foreach(Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        
        public static bool Guardar(Jornada jornada)
        {
            bool rtn = false;
            /*instanciar clase texto*/
            Texto texto = new Texto();
            /*busco metodo*/
            try
            {
                texto.Guardar("Jornada.txt", jornada.ToString());//la direccion de guardar ta bien??
                rtn = true;
            }
            catch(Excepciones.ArchivosException e)
            {
                throw new Excepciones.ArchivosException(e);
            }
            
            return rtn;
        }

        public static string Leer()
        {
            string informacion;
            /*instanciar clase texto*/
            Texto texto = new Texto();
            /*busco metodo*/
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

        /*indexador*/
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
        public static Profesor operator !=(Universidad g, Universidad.EClases c)
        {
            Profesor p= new Profesor();
            try
            {
                p = g == c;
            }
            catch(Excepciones.SinProfesorException)
            {
                foreach (Profesor item in g.profesores)
                {
                    if (item != c)
                    {
                       p = item;
                    }

                }
            }
            return p;
        }

        /*Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.
        • MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante
        ToString.
        • Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus
        Profesores, Alumnos y Jornadas.
        • Leer de clase retornará un Universidad con todos los datos previamente serializados.*/

        public static Universidad operator +(Universidad g, Universidad.EClases c)
        {
            try
            {
                Jornada jornada = new Jornada(c, g == c);
                Universidad aux = new Universidad();
                aux = g;
                aux.jornadas.Add(jornada);
                return aux;
            }
            catch(Excepciones.SinProfesorException)
            {
                throw new Excepciones.SinProfesorException();
            } 
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
