using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Chico;
            }
        }

        public Moto(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {

        }

        /// <summary>
        /// Muestra todos los datos de la moto
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------");
            sb.AppendLine("MOTO");
            sb.Append(base.Mostrar());
            sb.AppendLine(String.Format("TAMAÑO: {0}", this.Tamanio));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
