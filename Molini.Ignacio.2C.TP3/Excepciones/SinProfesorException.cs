using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor por defecto de SinProfesorException con mensaje por defecto
        /// </summary>
        public SinProfesorException() : this("No hay profesor para dicha clase.")
        {

        }

        /// <summary>
        /// Constructor de SinProfesorException con mensaje por parámetro
        /// </summary>
        public SinProfesorException(string message) : base(message)
        {

        }
    }
}
