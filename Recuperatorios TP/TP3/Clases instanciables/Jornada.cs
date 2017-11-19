using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace Clases_instanciables
{
    public class Jornada
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Atributos de la clase Jornada, Lista de alumnos de la jornada, 
        /// Clase de la jornada, Profesor de la jornada.
        /// </summary>
        #region Atributos
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

        /// <summary>
        /// Dos constructores publicos, uno para iniciar la lista de alumnos y otro para generar al alumno.
        /// </summary>
        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        /// <summary>
        /// Full properties para Lista de alumnos, Clase, y Profesores
        /// </summary>
        #region Propiedades
        public List<Alumno> Alumnos
        {
            get 
            {
                return this._alumnos; 
            }
            set 
            { 
                this._alumnos = value; 
            }
        }

        public Universidad.EClases Clase
        {
            get 
            { 
                return this._clase; 
            }
            set 
            { 
                this._clase = value; 
            }
        }

        public Profesor Instructor
        {
            get 
            { 
                return this._instructor; 
            }
            set 
            { 
                this._instructor = value; 
            }
        }
        #endregion

        /// <summary>
        /// Metodos para convertir los datos de jornada en un archivo TXT y podes leerlos.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        #region Metodos_Archivos
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            bool resultado = false;
            if (!txt.guardar("Jornada.txt", jornada.ToString()))
                Console.WriteLine("Error al guardar TXT");
            else
                resultado = true;
            return resultado;
        }

        public static string Leer()
        {
            Texto txt = new Texto();
            string datos;
            if (!txt.leer("Jornada.txt", out datos))
                return "Error al leer TXT";
            else
                return datos;
        }
        #endregion

        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE: " + this._clase + " ");
            sb.AppendLine(Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in this._alumnos)
                sb.AppendLine(a.ToString());
            sb.AppendLine("\n\n<------------------------------------------------>\n");
            return sb.ToString();
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            bool resultado = false;
            foreach (Alumno alumno in j.Alumnos)
                if (!(a == alumno))
                    resultado = true;
            return resultado;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool resultado = false;
            foreach (Alumno alumno in j.Alumnos)
                if (a == alumno)
                    resultado = true;
            return resultado;
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j.Alumnos.Count.Equals(0))
            {
                j.Alumnos.Add(a);
            }
            else
            {
                if (j == a)
                    return j;
                else
                    j.Alumnos.Add(a);
            }
            return j;
        } 
         
       }
}
