using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion

        public enum ENacionalidad { Argentino, Extranjero }

        #region Constructores
        public Persona()
        {
            this._nombre = "";
            this._apellido = "";
            this._dni = 0;

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this._dni = DNI;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Propiedades
        public string Apellido
        {
            get 
            { 
                return this._apellido; 
            }
            set 
            {
                this._apellido = ValidarNombreApellido(this.Apellido); 
            }
        }

        public int DNI
        {
            get 
            { 
                return this._dni; 
            }
            set 
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get 
            { 
                return this._nacionalidad; 
            }
            set 
            { 
                this._nacionalidad = value; 
            }
        }

        public string Nombre
        {
            get 
            {
                return this._nombre; 
            }
            set 
            {
                this._nombre = ValidarNombreApellido(this.Nombre);
            }
        }

        public string StringToDNI
        {
            set 
            {
                this.DNI = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} ",this.Apellido, this.Nombre);
            sb.AppendLine("\nNACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString(); 
        }

        private static int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dni < 1 || dni > 89999999)
                        throw new NacionalidadInvalidaException();
                    break;
                case ENacionalidad.Extranjero:
                    if (dni < 89999999 || dni > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dni;
        }

        private static int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int numeroDni = 0;
            if (dni.Length < 1 || dni.Length > 8)
                throw new DniInvalidoException(dni.ToString());
            else
                numeroDni = Int32.Parse(dni);

            return ValidarDni(nacionalidad, numeroDni);
        }

        private static string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }
        
    }
}
