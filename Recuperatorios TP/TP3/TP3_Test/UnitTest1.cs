using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_instanciables;
using Excepciones;
using EntidadesAbstractas;
using Archivos;

namespace TP3_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DNI_Nacionalidad()
        {
            try
            {
                Profesor a1 = new Profesor(1, "Juan", "Lopez", "99999999999999999",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod()]
        public void UniversidadAlumnoNull()
        {
            Universidad universidad = new Universidad();
            try
            {
                Alumno alumnoNull = null;
                universidad += alumnoNull;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }
        }

        [TestMethod()]
        public void AlumnoNacionalidad()
        {
            try
            {
                Alumno alumno = new Alumno(9, "Lautaro", "Arias", "98765432", Persona.ENacionalidad.Argentino,Universidad.EClases.SPD);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }

        [TestMethod()]
        public void LeerArchivoInexistente()
        {
            Texto txt = new Texto();
            string datos;
            
            try
            {
                txt.leer("Prueba.txt", out datos);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }
        }
                


    }
}
