using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático de Profesor para instanciar el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// Contructor con parámetros de Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método para agregar una clase random a las clases que da el profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }

        /// <summary>
        /// Sobreescritura del método ParticiparEnClase para que muestre las clases del profesor
        /// </summary>
        /// <returns>Retorna un string con las clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder("CLASES DEL DIA:\n");

            foreach(int item in this.clasesDelDia)
            {
                sb.AppendLine($"{(Universidad.EClases)item}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método MostrarDatos para que muestre todos los datos del profesor
        /// </summary>
        /// <returns>Retorna un string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString para que haga públicos los datos del profesor
        /// </summary>
        /// <returns>Retorna un string con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador == para un profesor dicta esa clase
        /// </summary>
        /// <param name="i">Profesor a evaluar</param>
        /// <param name="clase"></param>
        /// <returns>Retorna un bool en true si da la clase y false si no la da</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach(int item in i.clasesDelDia)
            {
                if(item == (int)clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador != para un profesor no dicta esa clase
        /// </summary>
        /// <param name="i">Profesor a evaluar</param>
        /// <param name="clase"></param>
        /// <returns>Retorna un bool en true si no da la clase y false si la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
