using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto de NacionalidadInvalidaException con mensaje por defecto
        /// </summary>
        public NacionalidadInvalidaException() : this("La nacionalidad no se condice con el número de DNI.")
        {

        }

        /// <summary>
        /// Constructor de NacionalidadInvalidaException con mensaje por parámetro
        /// </summary>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
