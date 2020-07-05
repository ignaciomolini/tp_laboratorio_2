using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Enumerados
        /// <summary>
        /// Enumerado con los estados del paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        /// <summary>
        /// Delegado para el evento InformaEstado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Delegados
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        /// <summary>
        /// Evento que informa el estado actual del paquete
        /// </summary>
        #region Eventos
        public event DelegadoEstado InformaEstado;
        #endregion  

        /// <summary>
        /// Propiedad get/set de la direccion de entrega
        /// </summary>
        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad get/set del estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad get/set del TrackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor con parametros que llena todos los campos
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que simula el recorrido de los paquetes y los inserta en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while(this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformaEstado.Invoke(this, null);
            }

            PaqueteDAO.Insertar(this);            
        }

        /// <summary>
        /// Metodo que muestra los datos del paquete
        /// </summary>
        /// <param name="elemento">Objeto que implementa la interfaz</param>
        /// <returns>Retorna un string con los datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return String.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
        }

        /// <summary>
        /// Sobreescritura del metodo ToString para mostrar los datos del paquete
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador == para comparar si los paquetes son iguales por medio
        /// del TrackingID
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Paquete a comparar</param>
        /// <returns>Retorna un bool en true si son iguales o en false si no lo son</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Sobrecarga del operador != para comparar si los paquetes son distintos por medio
        /// del TrackingID
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Paquete a comparar</param>
        /// <returns>Retorna un bool en true si son distintos o en false si no lo son</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
