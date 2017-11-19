using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_instanciables
{
    public sealed class Alumno : Universitario
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        public Alumno()
        { 
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString(); 
        }


        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this._claseQueToma;
        }


        public override string ToString()
        { 
            return this.MostrarDatos(); 
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool resultado = false;
            if (!(a._claseQueToma.Equals(clase)))
                resultado = true;
            return resultado;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool resultado = false;
            if (a._claseQueToma.Equals(clase) && a._estadoCuenta != EEstadoCuenta.Deudor)
                resultado = true;
            return resultado;
        }


    }
}
