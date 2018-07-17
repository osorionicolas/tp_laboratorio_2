using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Mano : Maquina
    {

        private Cartas[] _cartas;
        private int _puntos;
        private int _puntosTotales;
        private int _tanto;
        private bool _mano;
        private bool _turno;
        private bool _respuesta;
        private int _cartaIndice;
        private bool _ganadorRonda;
        private int _ganadorVuelta;
        private bool _turnoRespuesta;
        private Cartas _ultimaCarta;
        private bool _primerVuelta;


        private int _probabilidadVictoria;

        public Mano()
        {
            this._cartas = new Cartas[3];
            this._puntos = 0;
            this._puntosTotales = 0;
            this._tanto = Tanto;
            //MODIFICAR
            this._mano = false;
            this._turno = false;
            this._primerVuelta = false;
            
            this._respuesta = this.Respuesta;
            _cartaIndice = 0;
            this._ganadorRonda = this.GanadorRonda;
            this._turnoRespuesta = this.TurnoRespuesta;
            _ultimaCarta = UltimaCarta;
            this._probabilidadVictoria = 0;
        }

        public Cartas UltimaCarta
        {
            get { return _ultimaCarta; }
            set { _ultimaCarta = value; }
        }

        public Cartas[] MostrarMano
        {
            get 
            { 
                return this._cartas; 
            }
        }
        public void Inicializar()
        {
            this.PuntosTotales = this._puntos;
            this._puntos = 0;
            this.GanadorVuelta = 0;
            this.GanadorRonda = false;
            this._tanto = 0;
            this._respuesta = false;
            this._turnoRespuesta = false;
            this._probabilidadVictoria = 0;
            this._primerVuelta = false;

            this.MostrarMano[0] = null;
            this.MostrarMano[1] = null;
            this.MostrarMano[2] = null;
        }

        public int Puntos
        {
            set 
            { this._puntos += value; }
        }
        public int PuntosTotales
        {
            get { return this._puntosTotales; }
            set 
            { 
                this._puntosTotales += value;
                if (this._puntosTotales < 0)
                    this._puntosTotales = 0;
            }
        }

        public int Tanto
        {
            get { return this._tanto; }
            set { this._tanto = value; }
        }

        public bool QuienEsMano
        {
            get { return this._mano; }
            set { this._mano = value; }
        }

        public bool Turno
        {
            get { return this._turno; }
            set { this._turno = value; }
        }

        public bool TurnoRespuesta
        {
            get { return this._turnoRespuesta; }
            set { this._turnoRespuesta = value; }
        }

        public bool Respuesta
        {
            get { return this._respuesta; }
            set { this._respuesta = value; }
        }

        public int CartaIndice
        {
            get { return this._cartaIndice; }
            set { this._cartaIndice = value; }
        }

        public bool GanadorRonda
        {
            get { return this._ganadorRonda; }
            set { this._ganadorRonda = value; }
        }
        public int GanadorVuelta
        {
            get { return this._ganadorVuelta; }
            set { this._ganadorVuelta = value; }
        }

        public int Probabilidad
        {
            get { return this._probabilidadVictoria; }
        }

        public void ProbabilidadCarga()
        {
            for (int i = 0; i < 3; i++)
            {
                this._probabilidadVictoria += this.MostrarMano[i].ValorPuntaje;
            } 
        }

        public bool GanadorPrimeraVuelta
        {
            get { return _primerVuelta; }
            set { _primerVuelta = value; }
        }

        public static Mano operator +(Mano m, Cartas c)
        {
            for (int i = 0; i < 3; i++)
            {
                if (object.ReferenceEquals(m.MostrarMano[i], null))
                { 
                    if (!(m.MostrarMano.Contains(c)))
                    {
                        m.MostrarMano[i] = c;
                        break;
                    }
                }
            }
            return m;
        }
    }
}
