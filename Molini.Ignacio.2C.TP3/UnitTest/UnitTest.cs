using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;
using Archivos;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Método para probar que lista de alumnos está instanciada
        /// </summary>
        [TestMethod]
        public void TestListaAlumnosInstanciada()
        {
            //arrenge
            Universidad uni;
            //act
            uni = new Universidad();
            //assert
            Assert.IsNotNull(uni.Alumnos);
        }

        /// <summary>
        /// Método para probar que lista de profesores está instanciada
        /// </summary>
        [TestMethod]
        public void TestListaProfesoresInstanciada()
        {
            //arrenge
            Universidad uni;
            //act
            uni = new Universidad();
            //assert
            Assert.IsNotNull(uni.Instructores);
        }

        /// <summary>
        /// Método para probar que se lanzo la excepción al poner un dni que no se corresponda con la nacionalidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            //arrenge
            Profesor profe;
            //act
            profe = new Profesor(2, "Jose", "Acosta", "12344543", EntidadesAbstractas.Persona.ENacionalidad.Extranjero);
            //assert     
        }

        /// <summary>
        /// Método para probar que se lanzo la excepción al poner un dni con caracteres que no corresponden
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            //arrenge
            Alumno alumno;
            //act
            alumno = new Alumno(5, "Ramiro", "Diaz", "364343b432", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            //assert     
        }

        /// <summary>
        /// Método para probar que se lanzo la excepción al agregar un alumno repetido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            //arrenge
            Alumno alumno;
            Universidad uni;
            //act
            alumno = new Alumno(1, "Ramiro", "Diaz", "36343432", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            uni = new Universidad();

            uni += alumno;
            uni += alumno;
            //assert     
        }

        /// <summary>
        /// Método para probar que se lanzo la excepción al agregar una jornada sin que haya un profesor 
        /// para dar la clase asignada
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            //arrenge
            Universidad uni;
            //act
            uni = new Universidad();
           
            uni += Universidad.EClases.Laboratorio;      
            //assert     
        }

        /// <summary>
        /// Método para probar que se lanzo la excepción al haber un error a la hora de trabajar con archivos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestArchivosException()
        {
            //arrenge
            Texto texto;
            //act
            texto = new Texto();

            texto.Leer("ArchivoQueNoExiste.txt", out string dato);  
            //assert     
        }
    }
}
