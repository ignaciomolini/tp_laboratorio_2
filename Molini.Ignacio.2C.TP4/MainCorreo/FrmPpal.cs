using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        /// <summary>
        /// Constructor por defecto que incializa los componentes, instancia el correo y 
        /// suscribe un manejador al evento InformeErrorBDD
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            PaqueteDAO.InformeErrorBDD += PaqueteDAO_InformeErrorBDD;
        }

        /// <summary>
        /// Metodo que maneja el evento InformeErrorBDD mostrando los errores ocurridos
        /// </summary>
        /// <param name="informe"></param>
        /// <param name="ex"></param>
        private void PaqueteDAO_InformeErrorBDD(string informe, Exception ex)
        {
            string mensajeError = $"{informe}\n{ex.Message}";
            MessageBox.Show(mensajeError, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Metodo que actualiza los estados de los paquetes en los listBox
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach(Paquete paque in this.correo.Paquetes)
            {
                switch (paque.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paque);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paque);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paque);
                        break;
                }
            }
        }

        /// <summary>
        /// Metodo que muestra la informacion del objeto que recibe por parametro
        /// en el richTextBox y guarda la informacion en un archivo de texto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento">Objeto que impleta la interfaz</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\salida.txt";
            if(elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    this.rtbMostrar.Text.Guardar(path);
                }
                catch(Exception)
                {
                    MessageBox.Show("Error al guardar en el archivo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Metodo que maneja el evento InformaEstado actualizando los estados de los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Metodo que maneja el evento Click del boton agregar creando un paquete con los
        /// datos del mtxtTrackingID y del txtDireccion, que luego agrega a la lista de paquetes 
        /// del correo y ademas suscribiendo un manejador al evento InformaEstado y 
        /// actualizando el estado de los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.mtxtTrackingID.Text.Contains(" ") || this.mtxtTrackingID.Text.Length < 12)
            {
                MessageBox.Show("Debe completar el TrackingID.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(this.txtDireccion.Text == "")
            {
                MessageBox.Show("Debe completar la dirección.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                paquete.InformaEstado += this.paq_InformaEstado;

                try
                {
                    this.correo += paquete;
                }
                catch(TrackingIdRepetidoException ex)
                {
                    MessageBox.Show(ex.Message, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.ActualizarEstados();
            }     
        }

        /// <summary>
        /// Metodo que maneja el evento Click del boton mostrar todos mostrando la informacion
        /// de todos los paquetes del correo en el richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Metodo que maneja el evento Click del ToolStripMenuItem mostrando la informacion
        /// del paquete selecciona en el richTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Metodo que cierra todos los hilos abiertos antes de cerrar el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }        
    }
}
