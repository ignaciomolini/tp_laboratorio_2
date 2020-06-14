using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Método para guardar datos de objetos en un archivo xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna un bool en true si se guardo y en false si no se guardo</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = true;

            try
            {
                using (XmlTextWriter tw = new XmlTextWriter(archivo, UTF8Encoding.Default))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(tw, datos);
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
        /// Método para leer un archivo xml y crear un objeto con los datos leidos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna un bool en true si se pudo deserializar y en false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                using(XmlTextReader tr = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(tr);
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
