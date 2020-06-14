using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using Archivos;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enumerados
        /// <summary>
        /// Enumerado de las clases
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio,  Legislacion, SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad get/set de la lista de alumnos
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
        /// Propiedad get/set de la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
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
        /// Propiedad get/set de la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador de la lista de jornadas
        /// </summary>
        /// <param name="i">Índice</param>
        /// <returns>Retorna una jornada correspondiente al índice pasado</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Universidad que instancia las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método que muestra los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad a evaluar</param>
        /// <returns>Retorna un string con los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
                sb.AppendLine("< ------------------------------------------------>\n");
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString para que haga públicos los datos de la universidad
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Método para guardar los datos de la universidad en un archivo xml
        /// </summary>
        /// <param name="uni">Universidad a evaluar</param>
        /// <returns>Retorna un bool en true si se guardaron y en false si no se guardaron</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> datosUniXml = new Xml<Universidad>();

            if(datosUniXml.Guardar("DatosUniXml.xml", uni))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Método para leer los datos de un archivo xml y cargarlos en un objeto del tipo universidad
        /// </summary>
        /// <returns>Retorna una universidad con los datos cargados</returns>
        public static Universidad Leer()
        {
            Universidad uni = null;
            Xml<Universidad> datosUniXml = new Xml<Universidad>();
          
            datosUniXml.Leer("DatosUniXml.xml", out uni);
                      
            return uni;
        }
        #endregion

        /// <summary>
        /// Sobrecarga del operador == para saber si un alumno se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns>Retorna un bool en true si se encuentra y en false si no se encuentra</returns>
        #region Operadores
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno item in g.Alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador != para saber si un alumno no se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns>Retorna un bool en true si no se encuentra y en false si se encuentra</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador == para saber si un profesor se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="i">Profesor a evaluar</param>
        /// <returns>Retorna un bool en true si se encuentra y en false si no se encuentra</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach(Profesor item in g.Instructores)
            {
                if(item == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }


        /// <summary>
        /// Sobrecarga del operador != para saber si un profesor no se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="i">Profesor a evaluar</param>
        /// <returns>Retorna un bool en true si no se encuentra y en false si se encuentra</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador == para encontrar un profesor que pueda dar la clase
        /// y si no lo hay lanzara una excepción
        /// </summary>
        /// <param name="u">Universidad a evaluar</param>
        /// <param name="clase"></param>
        /// <returns>Retorna el primer profesor que pueda dar la clase, si lo hay</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retornoProfe = null;

            foreach(Profesor item in u.Instructores)
            {
                if(item == clase)
                {
                    retornoProfe = item;
                    break;
                }
            }

            if(retornoProfe is null)
            {
                throw new SinProfesorException("No hay Profesor para la clase.");
            }

            return retornoProfe;
        }

        /// <summary>
        /// Sobrecarga del operador != para encontrar un profesor que no pueda dar la clase
        /// </summary>
        /// <param name="u">Universidad a evaluar</param>
        /// <param name="clase"></param>
        /// <returns>Retorna el primer profesor que no pueda dar la clase, si lo hay</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retornoProfe = null;

            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    retornoProfe = item;
                    break;
                }
            }

            return retornoProfe;
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar una nueva jornada a la universidad con la 
        /// clase pasada por parámetro y buscando un profesor que la pueda dar y alumnos que 
        /// la cursen
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="clase"></param>
        /// <returns>Retorna la universidad con la nueva jornada, si la pudo agregar</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profe;
            Jornada jornada;
            List<Alumno> alumnosQueLaCursa = new List<Alumno>();

            profe = (g == clase);

            foreach(Alumno item in g.Alumnos)
            {
                if(item == clase)
                {
                    alumnosQueLaCursa.Add(item);
                }
            }
            
            jornada = new Jornada(clase, profe);
            jornada.Alumnos = alumnosQueLaCursa;

            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un alumno a la universidad si este no está,
        /// de lo contrario lanzara una excepcióm
        /// </summary>
        /// <param name="u">Universidad a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns>Retorna la univeridad con el nuevo alumno, si lo pudo agregar</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido.");
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un profesor a la universida si este no esta
        /// </summary>
        /// <param name="u">Universidad a evaluar</param>
        /// <param name="i">Profesor a evaluar</param>
        /// <returns>Retorna la universidad con el nuevo profesor, si lo pudo agregar</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }
        #endregion
    }
}
