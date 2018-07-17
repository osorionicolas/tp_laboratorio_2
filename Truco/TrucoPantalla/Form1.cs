using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Truco;
using System.Threading;

namespace TrucoPantalla
{
    public partial class Truco : Form
    {
        public delegate void Ganador();
        public event Ganador GanadorPartidaEvent;
        Mazo mazo;
        Mano manoUsuario;
        Mano manoMaquina;
        Jugada jugada;
        private int _puntosTotales = 0;
        Thread threadJugada;
        private static Random _randomTime;

        public Truco(string nombreUsuario, bool flor, int puntos)
        {
            InitializeComponent();
            lblUsuario.Text = nombreUsuario;
            if (flor == false)
                btnFlor.Enabled = false;
            this._puntosTotales = puntos;
            mazo = new Mazo();
            manoMaquina = new Mano();
            manoUsuario = new Mano();
            _randomTime = new Random();
            CheckForIllegalCrossThreadCalls = false;
            this.RepartirCartas();
        }

        public void RepartirCartas()
        {
            jugada = new Jugada();
            manoUsuario.Inicializar();
            manoMaquina.Inicializar();
            lblPuntos.Text = manoUsuario.PuntosTotales.ToString();
            lblPuntosMaquina.Text = manoMaquina.PuntosTotales.ToString();

            mazo.AgregarCartas();
            mazo.MezclarCartas();

            mazo.Repartir(this.manoMaquina);
            mazo.Repartir(this.manoUsuario);
            this.SetCartas();

            manoMaquina.ProbabilidadCarga();
            manoUsuario.ProbabilidadCarga();

            this.UsuarioTurno();
            manoUsuario.QuienEsMano = true;
        }
        #region Botones
        private void btnRetirarse_Click(object sender, EventArgs e)
        {
            if (manoUsuario.Turno == true)
            {
                manoMaquina.GanadorRonda = true;
                if (jugada.NumeroDeVuelta == 1)
                    manoMaquina.Puntos = 1;
                this.TerminarRonda();
            }
        }

        private void btnFlor_Click(object sender, EventArgs e)
        {
            if (this.manoUsuario.Turno == true && jugada.NumeroDeVuelta == 1)
            {
                if (Cantos.Flor(manoUsuario, manoMaquina) == 0)
                {
                    MessageBox.Show("Flor");
                    manoUsuario.Puntos = 4;
                }
                else if (Cantos.Flor(manoUsuario, manoMaquina) == 1)
                {
                    MessageBox.Show("Contraflor");
                }
                else if (Cantos.Flor(manoUsuario, manoMaquina) == -1)
                {
                    MessageBox.Show("Flor mal cantada pierde 4 puntos");
                    manoUsuario.Puntos = -4;
                }
                btnFlor.Click -= btnFlor_Click;
            }
        }

        private void btnEnvido_Click(object sender, EventArgs e)
        {
            if ((manoUsuario.Turno == true || manoUsuario.Respuesta == true) && jugada.Envido == false && jugada.NumeroDeVuelta == 1)
            {
                MessageBox.Show("Envido");
                this.LlamarEnvido(2);
            }
            jugada.Envido = true;
        }

        private void btnRealEnvido_Click(object sender, EventArgs e)
        {
            if (jugada.Envido == false)
            {
                if (this.manoUsuario.Turno == true || manoUsuario.Respuesta == true && jugada.NumeroDeVuelta == 1)
                {
                    MessageBox.Show("Real Envido");
                    this.LlamarEnvido(3);
                }
            }
            jugada.Envido = true;
        }

        private void btnFaltaEnvido_Click(object sender, EventArgs e)
        {
            if (jugada.Envido == false)
            {
                if (this.manoUsuario.Turno == true || this.manoUsuario.Respuesta == true && jugada.NumeroDeVuelta == 1)
                {
                    MessageBox.Show("Falta Envido");
                    Cantos.faltaEnvido = true;
                    this.LlamarEnvido(this._puntosTotales);
                }
            }
            jugada.Envido = true;
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            if (this.manoUsuario.Turno == true && jugada.Truco == 0)
            {
                MessageBox.Show("Truco");
                this.LlamarTruco(1);
            }
        }

        private void btnReTruco_Click(object sender, EventArgs e)
        {
            if ((this.manoUsuario.Respuesta == true && jugada.Truco == 2) || (manoUsuario.Turno == true && jugada.Truco == 2))
            {
                MessageBox.Show("Quiero re Truco");
                this.LlamarTruco(2);
                btnReTruco.Click -= btnReTruco_Click; 
            }
        }

        private void btnValeCuatro_Click(object sender, EventArgs e)
        {
            if ((this.manoUsuario.Respuesta == true && jugada.Truco == 3) || (manoUsuario.Turno == true && jugada.Truco == 3))
            {
                MessageBox.Show("Quiero vale cuatro");
                this.LlamarTruco(3);
                btnValeCuatro.Click -= btnValeCuatro_Click; 
            }
        }
        #endregion
        #region Imagenes
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void SetCartas()
        {
            Image cartaDadaVuelta = resizeImage(Properties.Resources.carta, new Size(84, 140));
            this.picBoxMaquina1.Image = cartaDadaVuelta;
            this.picBoxMaquina2.Image = cartaDadaVuelta;
            this.picBoxMaquina3.Image = cartaDadaVuelta;
                        
            this.picMaquina1.Image = null;
            this.picMaquina2.Image = null;
            this.picMaquina3.Image = null;

            this.picJugada1.Image = null;
            this.picJugada2.Image = null;
            this.picJugada3.Image = null;

            Cartas auxCarta1 = this.manoUsuario.MostrarMano[0];
            string aux = string.Format("{0}{1}", auxCarta1.Valor, auxCarta1.Palo);
            Image carta = resizeImage(Image.FromFile(@"Cartas\" + aux + ".jpg"), new Size(84, 140));
            this.picBoxUsuario1.Image = carta;

            Cartas auxCarta2 = this.manoUsuario.MostrarMano[1];
            string aux2 = string.Format("{0}{1}", auxCarta2.Valor, auxCarta2.Palo);
            Image carta2 = resizeImage(Image.FromFile(@"Cartas\" + aux2 + ".jpg"), new Size(84, 140));
            this.picBoxUsuario2.Image = carta2;

            Cartas auxCarta3 = this.manoUsuario.MostrarMano[2];
            string aux3 = string.Format("{0}{1}", auxCarta3.Valor, auxCarta3.Palo);
            Image carta3 = resizeImage(Image.FromFile(@"Cartas\" + aux3 + ".jpg"), new Size(84, 140));
            this.picBoxUsuario3.Image = carta3;
        }
        #endregion
        #region Cartas Usuario
        private void picBoxUsuario1_Click(object sender, EventArgs e)
        {
            if (manoUsuario.Turno == true)
            {
                picBoxUsuario1.Click -= picBoxUsuario1_Click;
                this.CartaFull(0);
            }
        }

        private void picBoxUsuario2_Click(object sender, EventArgs e)
        {
            if (manoUsuario.Turno == true)
            {
                picBoxUsuario2.Click -= picBoxUsuario2_Click;
                this.CartaFull(1);
            }
        }

        private void picBoxUsuario3_Click(object sender, EventArgs e)
        {
            if (manoUsuario.Turno == true)
            {
                picBoxUsuario3.Click -= picBoxUsuario3_Click;
                this.CartaFull(2);
            }
        }
        #endregion

        public void TerminarRonda()
        {
            if (manoUsuario.GanadorVuelta == 2)
                manoUsuario.GanadorRonda = true;
            else if (manoMaquina.GanadorVuelta == 2)
                manoMaquina.GanadorRonda = true;
            
            if ((manoUsuario.GanadorVuelta == 0 && manoMaquina.GanadorVuelta == 0)
            && ((object.ReferenceEquals(manoMaquina.MostrarMano[0], null) && object.ReferenceEquals(manoMaquina.MostrarMano[1], null) && object.ReferenceEquals(manoMaquina.MostrarMano[2], null) 
            && object.ReferenceEquals(manoUsuario.MostrarMano[0], null) && object.ReferenceEquals(manoUsuario.MostrarMano[1], null) && object.ReferenceEquals(manoUsuario.MostrarMano[2], null))))
            {
                if (manoUsuario.QuienEsMano == true)
                    manoUsuario.GanadorRonda = true;
                else if (manoMaquina.QuienEsMano == true)
                    manoMaquina.GanadorRonda = true;
            }
                       
            if(manoUsuario.GanadorRonda == false && manoMaquina.GanadorRonda == false)
            {
                //arreglar
                jugada.NumeroDeVuelta = 1;
                if (manoMaquina.Turno == true)
                {
                    this.JugadaMaquina();
                }
            }
            else if(manoUsuario.GanadorRonda == true || manoMaquina.GanadorRonda == true)
            {
                if(manoUsuario.GanadorRonda == true)
                {
                    manoUsuario.Puntos = 1;
                    MessageBox.Show("El usuario gano la mano");
                }
                else if (manoMaquina.GanadorRonda == true)
                {
                    manoMaquina.Puntos = 1;
                    MessageBox.Show("La maquina gano la mano");
                }
                if (jugada.Envido == true && manoMaquina.Tanto > manoUsuario.Tanto)
                {
                    //Mostrar cartas de la maquina en caso de que haya ganado el envido
                }
                this.UsuarioTurno();
                picBoxUsuario1.Click += picBoxUsuario1_Click;
                picBoxUsuario2.Click += picBoxUsuario2_Click;
                picBoxUsuario3.Click += picBoxUsuario3_Click;
                jugada.ValidaciónTruco(manoUsuario, manoMaquina);
                this.RepartirCartas();
             }
        }

        public void GanadorPartida()
        {
            if (manoUsuario.PuntosTotales >= this._puntosTotales)
            {
                DialogResult resultado = MessageBox.Show(this.lblUsuario.Text + " es el ganador de la partida!!!\n\n Queres jugar otra partida?", "Ganador", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                }
                else
                {
                    Application.Exit();
                }
            }
            else if (manoMaquina.PuntosTotales >= this._puntosTotales)
            {
                DialogResult resultado = MessageBox.Show(this.lblMaquina.Text + " es el ganador de la partida!!!", "Perdedor", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                }
                else
                {
                    Application.Exit();
                }
            }
        }
        #region Cantos
        private void LlamarEnvido(int puntos)
        {
            Cantos.Envido(this.manoMaquina);
            if (manoMaquina.Tanto > 20)
            {
                Tanto tanto = new Tanto();
                tanto.ShowDialog();
                manoUsuario.Tanto = tanto.Valor;
                int resultado = Cantos.EnvidoValidacion(this.manoUsuario, this.manoMaquina, puntos);

                if (resultado == 0)
                {
                    MessageBox.Show("Son buenas");
                }
                else if (resultado != 0)
                {
                    MessageBox.Show("Las mias son mejores. Tanto: " + resultado);
                }
            }
            else
            {
                MessageBox.Show("No quiero");
            }
        }

        private void LlamarTruco(int puntos)
        {
            if (Cantos.Truco(jugada, puntos, manoUsuario, manoMaquina) == 0)
            {
                MessageBox.Show("No quiero");
                manoUsuario.PuntosTotales = 1;
                this.RepartirCartas();
            }
            else if (Cantos.Truco(jugada, puntos, manoUsuario, manoMaquina) == 1)
            {
                jugada.Truco = puntos;
                MessageBox.Show("Quiero");
            }
        }
        #endregion

        public void JugadaMaquinaRespuesta()
        {
            manoMaquina.TurnoRespuesta = true;
            if (manoMaquina.Turno == true)
            {
                Cartas cartaAux = this.JugadaMaquinaCartaQueTira();
                manoMaquina.UltimaCarta = cartaAux;

                this.ValidaciónJugada();
                for (int i = 0; i < 3; i++)
                {
                    if (!(object.ReferenceEquals(manoMaquina.MostrarMano[i], null)) && manoMaquina.MostrarMano[i] == cartaAux)
                    {
                        manoMaquina.MostrarMano[i] = null;
                    }
                }
                jugada.JugadaCompleta();
            }
        }

        public void JugadaMaquina()
        {
            manoMaquina.TurnoRespuesta = false;
            if (manoMaquina.Turno == true)
            {
                Cartas cartaAux = this.JugadaMaquinaCartaQueTira();
                manoMaquina.UltimaCarta = cartaAux;
                for (int i = 0; i < 3; i++)
                {
                    if (!(object.ReferenceEquals(manoMaquina.MostrarMano[i], null)) && manoMaquina.MostrarMano[i] == cartaAux)
                    {
                        manoMaquina.MostrarMano[i] = null;
                        break;
                    }
                }
                this.UsuarioTurno();
                manoUsuario.TurnoRespuesta = true;
            }
        }

        private Cartas JugadaMaquinaCartaQueTira()
        {
            bool flagCarta = false;
            Thread.Sleep(_randomTime.Next(1, 2) * 1000);
            Cartas cartaAux = manoMaquina.Jugada(manoUsuario, manoMaquina);
            //arreglar
            if (manoUsuario.MostrarMano[manoUsuario.CartaIndice] > cartaAux && manoMaquina.Respuesta == true)
            {
                if ((manoUsuario.GanadorPrimeraVuelta == manoMaquina.GanadorPrimeraVuelta && jugada.NumeroDeVuelta != 1 && manoMaquina.TurnoRespuesta == true)
                || (manoUsuario.GanadorPrimeraVuelta == true && jugada.NumeroDeVuelta == 2)
                || (manoUsuario.GanadorVuelta == manoMaquina.GanadorVuelta && jugada.NumeroDeVuelta != 1))
                {
                    manoUsuario.GanadorRonda = true;
                    MessageBox.Show("Me retiro");
                    this.TerminarRonda();
                    threadJugada.Abort();
                }
            }
            string aux = string.Format("{0}{1}", cartaAux.Valor, cartaAux.Palo);
            Image carta = resizeImage(Image.FromFile(@"Cartas\" + aux + ".jpg"), new Size(84, 140));
            if (this.picMaquina1.Image == null && flagCarta == false)
            {
                this.picMaquina1.Image = carta;
                this.picBoxMaquina1.Image = null;
                flagCarta = true;
            }

            else if (this.picMaquina2.Image == null && flagCarta == false)
            {
                this.picMaquina2.Image = carta;
                this.picBoxMaquina2.Image = null;
                flagCarta = true;
            }
            else if (this.picMaquina3.Image == null && flagCarta == false)
            {
                this.picMaquina3.Image = carta;
                this.picBoxMaquina3.Image = null;
                flagCarta = true;
            }
            flagCarta = false;
            return cartaAux;
        }
        #region Turno
        private void UsuarioTurno()
        {
            manoUsuario.Turno = true;
            manoMaquina.Turno = false;
        }
        private void MaquinaTurno()
        {
            manoMaquina.Turno = true;
            manoUsuario.Turno = false;
        }
        #endregion

        private void CartaUno()
        {
            if (this.picJugada1.Image == null)
                this.picJugada1.Image = this.picBoxUsuario1.Image;

            else if (this.picJugada2.Image == null)
                this.picJugada2.Image = this.picBoxUsuario1.Image;

            else if (this.picJugada3.Image == null)
                this.picJugada3.Image = this.picBoxUsuario1.Image;

            this.picBoxUsuario1.Image = null;
        }
        private void CartaDos()
        {
            if (this.picJugada1.Image == null)
                this.picJugada1.Image = this.picBoxUsuario2.Image;

            else if (this.picJugada2.Image == null)
                this.picJugada2.Image = this.picBoxUsuario2.Image;

            else if (this.picJugada3.Image == null)
                this.picJugada3.Image = this.picBoxUsuario2.Image;
            
            this.picBoxUsuario2.Image = null;
        }
        private void CartaTres()
        {
            if (this.picJugada1.Image == null)
                this.picJugada1.Image = this.picBoxUsuario3.Image;

            else if (this.picJugada2.Image == null)
                this.picJugada2.Image = this.picBoxUsuario3.Image;

            else if (this.picJugada3.Image == null)
                this.picJugada3.Image = this.picBoxUsuario3.Image;

            this.picBoxUsuario3.Image = null;
        }
        private void CartaFull(int indice)
        {
            jugada.JugadaEvent += new JugadaDelegate(this.TerminarRonda);
            manoUsuario.CartaIndice = indice;
            if (manoUsuario.Turno == true && manoUsuario.TurnoRespuesta == false)
            {
                if (indice == 0)
                    this.CartaUno();
                else if (indice == 1)
                    this.CartaDos();
                else if (indice == 2)
                    this.CartaTres();

                this.threadJugada = new Thread(this.JugadaMaquinaRespuesta);
                this.MaquinaTurno();
                this.threadJugada.Start();
            }
            else if (manoUsuario.Turno == true && manoUsuario.TurnoRespuesta == true)
            {
                if (indice == 0)
                    this.CartaUno();
                else if (indice == 1)
                    this.CartaDos();
                else if (indice == 2)
                    this.CartaTres();

                this.ValidaciónJugada();
                this.TerminarRonda();
            }
        }
        
        public void ValidaciónJugada()
        {
            if (manoUsuario.MostrarMano[manoUsuario.CartaIndice] < manoMaquina.UltimaCarta)
            {
                manoMaquina.GanadorVuelta++;
                manoUsuario.TurnoRespuesta = false;
                this.MaquinaTurno();
                if (manoMaquina.GanadorPrimeraVuelta == false && manoUsuario.GanadorPrimeraVuelta == false && jugada.NumeroDeVuelta == 1)
                    manoMaquina.GanadorPrimeraVuelta = true;
            }
            else if (manoUsuario.MostrarMano[manoUsuario.CartaIndice] > manoMaquina.UltimaCarta)
            {
                manoUsuario.GanadorVuelta++;
                manoUsuario.TurnoRespuesta = false;
                this.UsuarioTurno();
                if (manoMaquina.GanadorPrimeraVuelta == false && manoUsuario.GanadorPrimeraVuelta == false && jugada.NumeroDeVuelta == 1)
                    manoUsuario.GanadorPrimeraVuelta = true;
            }
            else if (manoUsuario.MostrarMano[manoUsuario.CartaIndice] == manoMaquina.UltimaCarta)
            {
               if (manoUsuario.GanadorPrimeraVuelta == true)
               {
                   manoUsuario.GanadorRonda = true;
                   this.TerminarRonda();
               }
               else if (manoMaquina.GanadorPrimeraVuelta == true)
               {
                   manoMaquina.GanadorRonda = true;
                   this.TerminarRonda();
               }
               else
               {
                   if (manoUsuario.QuienEsMano == true)
                   {
                       this.UsuarioTurno();
                   }
                   else if(manoMaquina.QuienEsMano == true)
                   {
                       this.MaquinaTurno();
                   }
               }
            }
         }

        private void ToolStripItemLista_Click(object sender, EventArgs e)
        {

        }
    }
}
