using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Grande;
            }
        }

        public Camioneta(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {

        }

        /// <summary>
        /// Muestra todos los datos de la camioneta
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------");
            sb.AppendLine("CAMIONETA");
            sb.Append(base.Mostrar());
            sb.AppendLine(String.Format("TAMAÑO: {0}", this.Tamanio));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
