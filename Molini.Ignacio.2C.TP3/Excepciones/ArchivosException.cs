using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Contructor por defecto de ArchivosException con mensaje por defecto
        /// </summary>
        public ArchivosException() : this("Error en el guardado/lectura del archivo.")
        {

        }

        /// <summary>
        /// Contructor de ArchivosException con mensaje por parámetro
        /// </summary>
        public ArchivosException(string message) : base(message)
        {

        }

        /// <summary>
        /// Contructor de ArchivosException con mensaje por defecto e innerExcepcion por parámetro
        /// </summary>
        public ArchivosException(Exception innerException) : base("Error en el guardado/lectura del archivo.", innerException)
        {

        }
    }
}
