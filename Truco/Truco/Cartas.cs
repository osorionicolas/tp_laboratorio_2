using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Cartas
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public enum Palos { Espada, Oro, Copa, Basto }
        public enum Valores { Uno = 1, Dos = 2, Tres = 3, Cuatro = 4, Cinco = 5, Seis = 6, Siete = 7, Diez = 10, Once = 11, Doce = 12 }
        
        public Valores valor;
        private Palos _palo;
        private int _valorPuntaje;

        public Cartas(Valores valor, Palos palo)
        {
            this.valor = valor;
            this._palo = palo;
        }
        public Cartas()
        {
        }

        public string Valor
        {
            get { return this.valor.ToString(); }
        }

        public int ValorPuntaje
        {
            get { return this._valorPuntaje; }
        }
        public string Palo
        {
            get { return this._palo.ToString(); }
        }

        public void AsignarPuntaje()
        {
            if (this.valor == Valores.Cuatro)
                this._valorPuntaje = 1;
            if (this.valor == Valores.Cinco)
                this._valorPuntaje = 2;
            if (this.valor == Valores.Seis)
                this._valorPuntaje = 3;
            if ((this.valor == Valores.Siete && this._palo == Palos.Basto) || (this.valor == Valores.Siete && this._palo == Palos.Copa))
                this._valorPuntaje = 4;
            if (this.valor == Valores.Diez)
                this._valorPuntaje = 5;
            if (this.valor == Valores.Once)
                this._valorPuntaje = 6;
            if (this.valor == Valores.Doce)
                this._valorPuntaje = 7;
            if ((this.valor == Valores.Uno && this._palo == Palos.Copa) || (this.valor == Valores.Uno && this._palo == Palos.Oro))
                this._valorPuntaje = 8;
            if (this.valor == Valores.Dos)
                this._valorPuntaje = 9;
            if (this.valor == Valores.Tres)
                this._valorPuntaje = 10;
            if (this.valor == Valores.Siete && this._palo == Palos.Oro)
                this._valorPuntaje = 11;
            if (this.valor == Valores.Siete && this._palo == Palos.Espada)
                this._valorPuntaje = 12;
            if (this.valor == Valores.Uno && this._palo == Palos.Basto)
                this._valorPuntaje = 13;
            if (this.valor == Valores.Uno && this._palo == Palos.Espada)
                this._valorPuntaje = 14;
        }

       public static bool operator ==(Cartas c1, Cartas c2)
        {
            bool resultado = false;
            if (c1.ValorPuntaje == c2.ValorPuntaje)
                resultado = true;
            return resultado;
        }

       public static bool operator !=(Cartas c1, Cartas c2)
       {
           bool resultado = false;

           if (c1.ValorPuntaje != c2.ValorPuntaje)
               resultado = true;
           return resultado;
       }

       public static bool operator <(Cartas c1, Cartas c2)
       {
           bool resultado = false;
           if (c1._valorPuntaje < c2._valorPuntaje)
               resultado = true;

           return resultado;
       }

       public static bool operator >(Cartas c1, Cartas c2)
       {
           bool resultado = false;
           if (c1._valorPuntaje > c2._valorPuntaje)
               resultado = true;

           return resultado;
       }

        public static int operator +(Cartas c1, Cartas c2)
        {
            int resultado = 0;
            if ((c1.ValorPuntaje < 5 || c1.ValorPuntaje > 7) && (c2.ValorPuntaje < 5  || c2.ValorPuntaje > 7))
            {
                resultado = 20 + (int)c1.valor + (int)c2.valor;                
            }
            else if ((c1.ValorPuntaje > 5 && c1.ValorPuntaje < 7) || (c2.ValorPuntaje > 5 && c2.ValorPuntaje < 7))
            {
                if ((int)c1.valor == 11 || (int)c1.valor == 12)
                {
                    resultado = 10 + 10 + (int)c2.valor;
                }
                else if ((int)c2.valor == 11 || (int)c2.valor == 12)
                {
                    resultado = 10 + (int)c1.valor + 10;
                }
            }
            return resultado;
        }
    }
}
