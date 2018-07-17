using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public delegate void JugadaDelegate();        
    public class Jugada
    {
        static int _truco;
        private int _numeroDeVuelta;
        public event JugadaDelegate JugadaEvent;
        static bool _envido;
        static bool _flor;

        public Jugada()
        {
            _truco = 0;
            _envido = false;
            _flor = false;
            this._numeroDeVuelta = 1;
            Cantos.faltaEnvido = false;
        }

        public int Truco
        {
            get { return _truco; }
            set { _truco = value; }
        }

        public bool Envido
        {
            get { return _envido; }
            set { _envido = value; }
        }
        public bool Flor
        {
            get { return _flor; }
            set { _flor = value; }
        }
        public int NumeroDeVuelta
        {
            get { return this._numeroDeVuelta; }
            set { this._numeroDeVuelta += value; }
        }
        public void JugadaCompleta()
        {
            this.JugadaEvent.Invoke();
        }

        public void ValidaciónTruco(Mano usuario, Mano maquina)
        {
            if (this.Truco == 1 && usuario.GanadorRonda == true)
            {
                usuario.Puntos = 1;
            }
            else if (this.Truco == 1 && maquina.GanadorRonda == true)
            {
                maquina.Puntos = 1;
            }
            else if (this.Truco == 2 && usuario.GanadorRonda == true)
            {
                usuario.Puntos = 2;
            }
            else if (this.Truco == 2 && maquina.GanadorRonda == true)
            {
                maquina.Puntos = 2;
            }
            else if (this.Truco == 3 && usuario.GanadorRonda == true)
            {
                usuario.Puntos = 3;
            }
            else if (this.Truco == 3 && maquina.GanadorRonda == true)
            {
                maquina.Puntos = 3;
            }
        }
    }
}
