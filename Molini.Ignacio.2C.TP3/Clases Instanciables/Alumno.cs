using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerados
        /// <summary>
        /// Enumerado de los estados de cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion

        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Constructor con parámetros de Alumno sin el estado de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
        : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor con parámetros de Alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
        : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescritura del método MostrarDatos de la clase base para que muestre todos 
        /// los datos del alumno
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine($"\nESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                sb.AppendLine($"\nESTADO DE CUENTA: {this.estadoCuenta}");
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        } 

        /// <summary>
        /// Sobreescritura del método ParticiparEnClase de la clase base para que 
        /// muestre la clase que toma
        /// </summary>
        /// <returns>Retorna un string con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASES DE {this.claseQueToma}";
        }

        /// <summary>
        /// Sobreescritura del método ToString para que haga públicos los datos 
        /// del método MostrarDatos
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operador == para comprobar si un alumno cursa una clase
        /// </summary>
        /// <param name="a">Alumno a evaluar</param>
        /// <param name="clase"></param>
        /// <returns>Retorna un bool en true si cursa la clase y no es deudor, y false si no ocurre alguna de ambas</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Sobrecarga del operador == para comprobar si un alumno no cursa una clase
        /// </summary>
        /// <param name="a">Alumno a evaluar</param>
        /// <param name="clase"></param>
        /// <returns>Retorna un bool en true si no cursa la clase y en false si la cursa</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion
    }
}
