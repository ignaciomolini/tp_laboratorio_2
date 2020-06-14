using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados
        /// <summary>
        /// Enumerado de nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad get/set del apellido con validación en el set
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad get/set de la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad get/set del dni con validación en set
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad get/set del nombre con validación en el set
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad set del dni con validación
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor con parámetros de Persona sin dni
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con parámetros de Persona con dni int
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor con parámetros de Persona con dni string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescritura del método ToString para que muestre los datos de la persona
        /// </summary>
        /// <returns>Retorna un string con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}\n");
            //sb.AppendLine($"DNI: {this.DNI}");

            return sb.ToString();
        }

        /// <summary>
        /// Método que valida que el número de dni coincida con la nacionalidad 
        /// y si este no es correcto lanza una excepción
        /// </summary>
        /// <param name="nacionaliad"></param>
        /// <param name="dato">numero a validar</param>
        /// <returns>Retorna un int con el número de dni</returns>
        private int ValidarDni(ENacionalidad nacionaliad, int dato)
        {
            int retorno;

            if((nacionaliad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) || 
               (nacionaliad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999))
            {
                retorno = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el número de DNI.");
            }

            return retorno;
        }

        /// <summary>
        /// Método que valida que el string ingresado sean solo números y que el dni coincida 
        /// con la nacionalidad, pudiendo lanzar alguna de las dos excepciones según sea el error
        /// </summary>
        /// <param name="nacionaliad"></param>
        /// <param name="dato">string a validar</param>
        /// <returns>Retorna un int con el número de dni</returns>
        private int ValidarDni(ENacionalidad nacionaliad, string dato)
        {
            int retorno;
            int aux;

            if (int.TryParse(dato, out aux))
            {
                retorno = this.ValidarDni(nacionaliad, aux);
            }
            else
            {
                throw new DniInvalidoException("El formato del DNI es invalido");
            }

            return retorno;       
        }

        /// <summary>
        /// Método que valida que string sea un nombre o un apellido, en el que pueden estar
        /// incluidos los caracteres especificados
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns>Retorna un string con el dato pasa por parámetro si este es correcto, sino vacío</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[A-Za-zÑñÁÉÍÓÚáéíóú ]*$");
            string retorno = "";

            if(r.IsMatch(dato))
            {
                retorno = dato;
            }

            return retorno;
        }
        #endregion
    }
}
