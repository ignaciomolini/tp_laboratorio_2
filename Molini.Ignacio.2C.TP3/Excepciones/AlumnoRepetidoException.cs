using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de AlumnoRepetidoException con un mensaje por defecto
        /// </summary>
        public AlumnoRepetidoException() : this("El alumno ya se encuentra en el sistema.")
        {

        }

        /// <summary>
        /// Constructor de AlumnoRepetidoException con mensaje por parámetro
        /// </summary>
        /// <param name="message"></param>
        public AlumnoRepetidoException(string message) : base(message)
        {

        }
    }
}
