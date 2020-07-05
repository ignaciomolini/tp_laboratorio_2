using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        /// <summary>
        /// Delegado para el evento InformeErrorBDD
        /// </summary>
        /// <param name="informe"></param>
        /// <param name="ex"></param>
        #region Delegados
        public delegate void DelegadoErrorBDD(string informe, Exception ex);
        #endregion

        /// <summary>
        /// Evento que informa si hubo un error al insertar informacion en la base de datos
        /// </summary>
        #region Eventos
        public static event DelegadoErrorBDD InformeErrorBDD;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estatico que estable la conexion a la base de datos
        /// y le asigna al comando la conexion y el tipo
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.conexion = new SqlConnection("Data Source = .; Database = correo-sp-2017; Trusted_Connection = True;");
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
            PaqueteDAO.comando.CommandType = CommandType.Text;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que insertar un paquete a la base de datos 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Retorna un bool en true si lo pudo agregar o en false si no pudo</returns>
        public static bool Insertar(Paquete p)
        {
            bool seInserto = false;

            try
            {
                PaqueteDAO.comando.CommandText = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) " +
                    " VALUES (@direccionEntrega, @trackingID, 'Ignacio Molini')";
                PaqueteDAO.comando.Parameters.Clear();
                PaqueteDAO.comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                PaqueteDAO.comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
                seInserto = true;
            }
            catch(Exception ex)
            {
                PaqueteDAO.InformeErrorBDD.Invoke("Error al insertar el paquete en la base de datos.", ex);
            }
            finally
            {
                if(PaqueteDAO.conexion.State != ConnectionState.Closed)
                {
                    PaqueteDAO.conexion.Close();
                }
            }

            return seInserto;
        }
        #endregion
    }
}
