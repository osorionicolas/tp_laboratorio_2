using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Mazo
    {
        private int _cantidadCartas;
        private static Random _random;
        private Cartas[] _mazo;
        
        public int Cantidad
        {
            get { return _cantidadCartas; }
        }

        public Mazo()
        {
            this._mazo = new Cartas [40];
            this._cantidadCartas = 40;
        }

        static Mazo()
        {
            _random = new Random();
        }

        public void AgregarCartas()
        {
            for (int x = 0; x < this.Cantidad; x++)
            {
                foreach (Cartas.Valores valores in Enum.GetValues(typeof(Cartas.Valores)))
                {
                    foreach (Cartas.Palos palos in Enum.GetValues(typeof(Cartas.Palos)))
                    {
                        Cartas carta = new Cartas(valores, palos);
                        carta.AsignarPuntaje();
                        if (!(this._mazo.Contains(carta)))
                        {
                            this._mazo[x] = carta;
                            x++;
                        }
                    }
                }
            }
        }
        public void MezclarCartas()
        {
            for (int i = 0; i < this._cantidadCartas; i++)
            {
                int r = _random.Next(this._cantidadCartas);
                Cartas c = this._mazo[i];
                this._mazo[i] = this._mazo[r];
                this._mazo[r] = c;
            }
        }
        public void Repartir(Mano m)
        {
            for (int x = 0; x < 3; x++)
            {
                m.MostrarMano[x] = null;
            }
            while (object.ReferenceEquals(m.MostrarMano[2], null))
            {
                int r = _random.Next(0, this._cantidadCartas - 1);
                if (!(object.ReferenceEquals(this._mazo[r], null)))
                {
                    Cartas carta = this._mazo[r];
                    m += carta;
                    this._mazo[r] = null;
                }
            }     
        }
    }
}
