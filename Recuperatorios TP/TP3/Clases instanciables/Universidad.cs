using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_instanciables
{
    
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// Atributos de Universidad, Lista de alumnos inscriptos, Lista de jornadas dentro de la universidad 
        /// y lista de profesores inscriptos.
        /// </summary>
        #region Atributos
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;
        #endregion

        /// <summary>
        /// Constructor de Universidad para inicializar las listas.
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

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

        public List<Profesor> Instructores
        {
            get 
            { 
                return this._profesores; 
            }
            set 
            { 
                this._profesores = value; 
            }
        }

        public List<Jornada> Jornadas
        {
            get
            { 
                return this._jornada; 
            }
            set
            { 
                this._jornada = value; 
            }
        }

        public Jornada this[int i]
        {
            get
            { 
                return this._jornada[i]; 
            }
            set
            {
                this._jornada[i] = value; 
            }
        }
        #endregion

        /// <summary>
        /// Metodos para convertir los datos de Universidad en un archivo XML.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        #region Metodos_Archivos
        public static bool Guardar(Universidad gim)
        {
            bool resultado = false;
            XML<Universidad> xml = new XML<Universidad>();
            if (!xml.guardar("Universidad.xml", gim))
                Console.WriteLine("Error al guardar XML");
            else
                resultado = true;
            return resultado;
        }
        #endregion

        /// <summary>
        /// Metodo para mostrar los datos de la universidad
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada j in gim.Jornadas)
                sb.AppendLine(j.ToString());
            return sb.ToString(); ;
        }


        public override string ToString()
        {
            return MostrarDatos(this); 
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            bool resultado = false;
            foreach (Alumno alumno in g.Alumnos)
                if (!(a==alumno))
                    resultado = true;
            return resultado;
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            for (int i = 0; i < g.Instructores.Count; i++)
            {
                if (!(g.Instructores[i] == clase))
                    return g.Instructores[i];
                else
                    throw new SinProfesorException();
            }
            return g.Instructores[1];
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            bool resultado = false;
            foreach (Profesor prof in g.Instructores)
                if (!(i.Equals(prof)))
                    resultado = true;
            return resultado;
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();
            

            else
                g.Alumnos.Add(a);
            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = (g == clase);
            Jornada j = new Jornada(clase, p);
            g.Jornadas.Add(j);
            foreach (Alumno a in g.Alumnos)
                if (a == clase)
                     j += a;

            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (i == profesor)
                    return g;
            }
            g.Instructores.Add(i);
            return g;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool resultado = false;
            foreach (Alumno alumno in g.Alumnos)
            {
                if (a == alumno)
                    resultado = true;
            }
            return resultado;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            for (int i = 0; i < g.Instructores.Count; i++)
            {
                if (g.Instructores[i] == clase)
                {
                    return g.Instructores[i];
                }
            }

            throw new SinProfesorException();
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool resultado = false;
            foreach (Profesor prof in g.Instructores)
                if (i.Equals(prof))
                    resultado = true;
            return resultado;
        }

        
    }
}
