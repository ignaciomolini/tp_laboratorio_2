using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension que guarda los datos de un string en un archivo de texto en el
        /// escritorio que si no existe lo crea y si no agrega a lo que ya tiene(append)
        /// </summary>
        /// <param name="texto">Datos a guardar</param>
        /// <param name="archivo">Ruta del archivo</param>
        /// <returns>Retorna un bool en true si pudo agregar los datos al archivo
        /// o en false si no pudo</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool seGuardo = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true, UTF8Encoding.Default))
                {
                    sw.WriteLine(texto);
                    seGuardo = true;
                }       
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return seGuardo;
        }
    }
}
