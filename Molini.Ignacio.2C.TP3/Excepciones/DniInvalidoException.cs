using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de DniInvalidoException con mensaje por defecto
        /// </summary>
        public DniInvalidoException() : this("Error en el formato del DNI.", null)
        {

        }

        /// <summary>
        /// Constructor de DniInvalidoException con mensaje por defecto e innerException por parámetro
        /// </summary>
        public DniInvalidoException(Exception e) : this("Error en el formato del DNI.", e)
        {

        }

        /// <summary>
        /// Constructor de DniInvalidoException con mensaje por parámetro
        /// </summary>
        public DniInvalidoException(string message) : this(message, null)
        {

        }

        /// <summary>
        /// Constructorde DniInvalidoException con mensaje e innerException por parámetro
        /// </summary>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
