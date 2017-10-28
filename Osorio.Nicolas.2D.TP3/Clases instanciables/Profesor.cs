using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_instanciables
{
    public sealed class Profesor : Universitario
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
        /// Atributos de la clase Profesor, Queue con un maximo de dos clases aleatorias que puede tomar el profesor.
        /// Random para generar las clases random.
        /// </summary>
        #region Atributos
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Constructores
        public Profesor(){}
        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        #endregion

        /// <summary>
        /// Pasa los valores del enumerador a un array de cadenas para lugar tomar los nombres, 
        /// genera un indice random y compara la cadena con el nombre del enumerador
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                string[] clases = Enum.GetNames(typeof(Universidad.EClases));
                int randomEnum = _random.Next(clases.Length);
                string res = clases[_random.Next(0, clases.Length - 1)];
                if (res == "Laboratorio")
                    this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                else if (res == "SPD")
                    this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
                else if (res == "Legislacion")
                    this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                if (res == "Programacion")
                    this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
            }
        }

        protected override string ParticiparEnClase()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del dia: ");
            foreach (Universidad.EClases clase in this._clasesDelDia)
                sb.AppendLine(clase.ToString());
            return sb.ToString();
            
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("POR " + base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString(); ;
        }

        

        public override string ToString()
        { 
            return this.MostrarDatos(); 
        }

        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            bool resultado = false;
            foreach (Universidad.EClases c in p._clasesDelDia)
            {
                if (!(clase == c))
                    resultado = true;
            }
            return resultado;
        }

        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            bool resultado = false;
            foreach (Universidad.EClases c in p._clasesDelDia)
            {
            if(clase == c)
                resultado = true;
            }
            return resultado;
        }

    }
}
