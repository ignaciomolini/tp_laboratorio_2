using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Método para guardar datos en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna un bool en true si se guardo y en false si no lo hizo</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using(StreamWriter sw = new StreamWriter(archivo, false, UTF8Encoding.Default))
                {
                    sw.WriteLine(datos);
                    retorno = true;
                }
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return retorno;
        }

        /// <summary>
        /// Método para leer un archivo de texto y cargar los datos en un string
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna un bool en true si se cargaron los datos leidos y false si no se cargaron</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                using(StreamReader sr = new StreamReader(archivo, UTF8Encoding.Default))
                {
                    datos = sr.ReadToEnd();
                    retorno = true;
                }
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return retorno;
        }
    }
}
