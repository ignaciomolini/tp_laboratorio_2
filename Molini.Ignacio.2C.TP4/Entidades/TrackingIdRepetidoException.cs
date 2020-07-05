using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Constructores
        /// <summary>
        /// Cosntructor con parametro que recibe un mensaje y se lo pasa al otro cosntructor
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje) : this(mensaje, null)
        {

        }

        /// <summary>
        /// Constructor con parametros que recibe un mensaje y una excepcion que 
        /// se los pasa a la clase base
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public TrackingIdRepetidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
        #endregion
    }
}
