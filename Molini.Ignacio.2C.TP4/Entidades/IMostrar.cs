using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Metodo a ser implementado para mostrar datos
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Retorna un string con los datos</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
