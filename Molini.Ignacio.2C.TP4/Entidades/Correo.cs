using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad get/set de la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que instancia las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que finaliza todos los hilos abiertos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread h in this.mockPaquetes)
            {
                if(h.IsAlive)
                {
                    h.Abort();
                }
            }
        }

        /// <summary>
        /// Metodo que muestra los datos de todos los paquetes de la lista
        /// </summary>
        /// <param name="elementos">Objeto que implementa la interfaz</param>
        /// <returns>Retorna un string con los datos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            Correo c = (Correo)elementos;

            foreach(Paquete p in c.Paquetes)
            {
                sb.AppendLine(String.Format("{0} ({1})", p.ToString(), p.Estado));
            }

            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador + que agrega un paquete a la lista de paquetes del correo
        /// verificando que no este repetido el TrackingID, e inicia y agrega un hilo a la lista de
        /// hilos, que simula el recorrido del paquete
        /// </summary>
        /// <param name="c">Objeto del tipo Correo</param>
        /// <param name="p">Objeto del tipo Paquete</param>
        /// <returns>Retorna un objeto del tipo Correo con el paquete y el hilo agregado</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paque in c.Paquetes)
            {
                if(paque == p)
                {
                    throw new TrackingIdRepetidoException("Ya existe un paquete con ese TrackingID en la lista.");
                }
            }

            c.Paquetes.Add(p);

            Thread hilo = new Thread(new ThreadStart(p.MockCicloDeVida));
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
        #endregion
    }
}
