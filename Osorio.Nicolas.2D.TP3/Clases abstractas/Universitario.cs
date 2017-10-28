using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private int _legajo;


        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }


        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this._legajo);
            return sb.ToString(); 
        }

        protected abstract string ParticiparEnClase();


        public static bool operator !=(Universitario pg1, Universitario pg2)
        { 
            bool resultado = false;
            if(!(pg1.GetType().Equals(pg2.GetType()) && (pg1._legajo.Equals(pg2._legajo) || pg1.DNI.Equals(pg2.DNI))))
                resultado = true;
            return resultado;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        { 
            bool resultado = false;
            if(pg1.GetType().Equals(pg2.GetType()) && (pg1._legajo.Equals(pg2._legajo) || pg1.DNI.Equals(pg2.DNI)))
                resultado = true;
            return resultado;
        }


    }
}
