using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad get/set del legajo para poder serializar
        /// </summary>
        public int Legajo
        {
            get
            {
                return this.legajo;
            }
            set
            {
                this.legajo = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Constructor con parámetros de Universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
        : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método para mostrar los datos 
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");

            return sb.ToString();
        }
        
        /// <summary>
        /// Método abstracto
        /// </summary>
        /// <returns>Retorna un string</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobreescritura del método Equals para comparar si dos objetos son del mismo tipo
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>Retorna un bool con true si son del mismo tipo y false si no lo son</returns>
        public override bool Equals(object obj)
        {
            return !(obj is null) && this.GetType() == obj.GetType();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador == para determinar si dos univerisatarios son iguales
        /// solo si son del mismo tipo y si tienen igual dni o legajo
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Retorna un bool con true si son iguales y false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {    
            return pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo); ;
        }

        /// <summary>
        /// Sobrecarga del operador != para determinar si dos univerisatarios son distintos
        /// si son de distinto tipo o tienen distinto dni y legajo
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Retorna un bool con true si son distintos y false si no lo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
