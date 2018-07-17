using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public static class Cantos
    {
        public static bool faltaEnvido = false;

        public static void FaltaEnvido(Mano usuario, Mano maquina, int puntosTotalesPartida)
        {
            if (puntosTotalesPartida == 15)
            {
            }
            else if (puntosTotalesPartida == 30 && (usuario.PuntosTotales < 15 && maquina.PuntosTotales < 15))
            {

            }
            else if (puntosTotalesPartida == 30 && (usuario.PuntosTotales >= 15 && maquina.PuntosTotales >= 15))
            {
            }
        }
        public static int Truco(Jugada jugada, int puntos, Mano usuario, Mano maquina)
        {
            int resultado = 0;
            if(maquina.Probabilidad > 15 || maquina.Probabilidad > usuario.Probabilidad) 
                resultado = 1;
            
            return resultado;
       }

        public static void Envido(Mano maquina)
        {
            //agregar mas logica porque sino toma solo la primer combinacion en caso de haber 2
            if (maquina.MostrarMano[0].Palo == maquina.MostrarMano[1].Palo)
            {
                maquina.Tanto = maquina.MostrarMano[0] + maquina.MostrarMano[1];
            }
            else if (maquina.MostrarMano[0].Palo == maquina.MostrarMano[2].Palo)
            {
                maquina.Tanto = maquina.MostrarMano[0] + maquina.MostrarMano[2];
            }
            else if (maquina.MostrarMano[1].Palo == maquina.MostrarMano[2].Palo)
            {
                maquina.Tanto = maquina.MostrarMano[1] + maquina.MostrarMano[2];
            }
            else
            {
                Cartas aux = new Cartas();
                for (int i = 0; i < 3; i++)
                {
                    if ((int)maquina.MostrarMano[i].valor < 10)
                    {
                        aux = maquina.MostrarMano[i];
                        break;
                    }
                }
                if (!(object.ReferenceEquals(aux, null)))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if ((int)maquina.MostrarMano[i].valor < 10)
                        {
                            if ((int)maquina.MostrarMano[i].valor > (int)aux.valor)
                                aux = maquina.MostrarMano[i];
                        }
                    }
                }
                maquina.Tanto = (int)aux.valor;
            }
        }
        public static int EnvidoValidacion(Mano usuario, Mano maquina, int puntos)
        {
            int resultado = 0;
            if (usuario.Tanto > maquina.Tanto)
            {
                usuario.Puntos = puntos;
            }
            else if (usuario.Tanto < maquina.Tanto)
            {
                maquina.Puntos = puntos;
                resultado = maquina.Tanto;
            }
            else if (usuario.Tanto == maquina.Tanto)
            {
                if (usuario.QuienEsMano == true)
                {
                    usuario.Puntos = puntos;
                }
                else if (maquina.QuienEsMano == true)
                {
                    maquina.Puntos = puntos;
                    resultado = maquina.Tanto;
                }
            }
            return resultado;
        }

        public static int Flor(Mano usuario, Mano maquina)
        {
            int resultado = 0;
            if (maquina.MostrarMano[0].Palo == maquina.MostrarMano[1].Palo && maquina.MostrarMano[0].Palo == maquina.MostrarMano[2].Palo && maquina.MostrarMano[1].Palo == maquina.MostrarMano[2].Palo)
            {
                resultado = 1;
            }
            if (!(usuario.MostrarMano[0].Palo == usuario.MostrarMano[1].Palo && usuario.MostrarMano[0].Palo == usuario.MostrarMano[2].Palo && usuario.MostrarMano[1].Palo == usuario.MostrarMano[2].Palo))
            {
                resultado = -1;
            }
            return resultado;
        }
    }
}
