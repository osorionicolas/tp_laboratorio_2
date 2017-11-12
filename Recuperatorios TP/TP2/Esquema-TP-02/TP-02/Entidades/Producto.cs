using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public enum EMarca
        {Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico}
        EMarca _marca;
        string _codigoDeBarras = string.Empty;
        ConsoleColor _colorPrimarioEmpaque;

        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = codigo;
            this._colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected virtual short CantidadCalorias { get { return 4; } }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", this._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", this._marca);
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", this._colorPrimarioEmpaque);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        public static explicit operator string(Producto p)
        {
            return p.Mostrar();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras != v2._codigoDeBarras);
        }
    }
}
