using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Laboratorio_2_Osorio_Nicolas_2D
{
    public class Numero
    {
        private double _numero;
        public Numero()
        {
            this._numero = 0;
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }
        public Numero(string numero)
        {
            setNumero(numero);
        }

        public double getNumero()
        {
            return this._numero;
        }
        private double validarNumero(string numeroCampo)
        {
            double numDouble;
            if (Double.TryParse(numeroCampo, out numDouble))
            {
                return numDouble;
            }
            else
                return 0;
        }

        private void setNumero(string numero)
        {
            if (validarNumero(numero) != 0)
            {
                this._numero = validarNumero(numero);
            }
            else
            {
                this._numero = 0;
            }
        }
    }
}
