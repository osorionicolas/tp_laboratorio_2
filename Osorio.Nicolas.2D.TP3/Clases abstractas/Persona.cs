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
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
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
                this._dni = ValidarDni(this.Nacionalidad, value);
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

        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".","");
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;
            //*****OPCION 1*****
            //if(!Int32.TryParse(dato, out numeroDni))
            //    throw new DniInvalidoException();
            //*****OPCION 2*****
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch(Exception e)
            {
                throw new DniInvalidoException(dato.ToString(),e);
            }
            
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
