using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
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
        /// Propiedad get/set de la clase
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
        /// Propiedad get/set del profesor
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

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Jornada que instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con parámetros de Jornada que a su vez llama al por defecto 
        /// para instanciar la lista
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método para guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna un bool en true si se guardo y false si no lo hizo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;          
            Texto datosDeLaJornada = new Texto();

            if(datosDeLaJornada.Guardar("DatosDeLaJornada.txt", jornada.ToString()))
            {
                retorno = true;
            }
            
            return retorno;
        }

        /// <summary>
        /// Método que carga un string con los datos que lee de un archivo de texto
        /// </summary>
        /// <returns>Retorna un string con los datos del archivo</returns>
        public static string Leer()
        {
            string retornoLectura = "";
            Texto datosDeLaJornada = new Texto();

            datosDeLaJornada.Leer("DatosDeLaJornada.txt", out retornoLectura);

            return retornoLectura;
        }

        /// <summary>
        /// Sobreescritura del método ToString para que muestre los datos de la jornada
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"CLASE DE {this.Clase} POR ");
            sb.Append(this.instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador == que nos dice si un alumno esta en la jornada
        /// </summary>
        /// <param name="j">Jornada a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns>Retorna un bool en true si el alumno está en la jornada y false si no está</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno item in j.alumnos)
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
        /// Sobrecarga del operador != que nos dice si un alumno no esta en la jornada
        /// </summary>
        /// <param name="j">Jornada a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns>Retorna un bool en true si el alumno no está en la jornada y false si está</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un alumno a la jornada validando 
        /// previamente que no este
        /// </summary>
        /// <param name="j">Jornada a evaluar</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la jornada con un nuevo alumno, si este no estaba antes</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }
        #endregion

    }
}
