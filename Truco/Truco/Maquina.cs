using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Maquina
    {
        //Verifica la menor de las cartas que le pueden ganar a la del usuario si no posee una carta que le gane a la del usuario tira la menor
        public Cartas Jugada(Mano usuario, Mano maquina)
        {
            Cartas cartaAux = new Cartas();
            foreach (Cartas carta in maquina.MostrarMano)
            {
                if (!(object.ReferenceEquals(carta, null)) && carta > usuario.MostrarMano[usuario.CartaIndice])
                {
                    if (cartaAux.valor == 0 || carta < cartaAux)
                        cartaAux = carta;
                }

                if (cartaAux.valor == 0)
                {
                    if (!(object.ReferenceEquals(carta, null)) && carta < usuario.MostrarMano[usuario.CartaIndice])
                    {
                        if (cartaAux.valor == 0 || carta < cartaAux)
                            cartaAux = carta;
                    }
                    else if (!(object.ReferenceEquals(carta, null)) && carta == usuario.MostrarMano[usuario.CartaIndice])
                    {
                        if (cartaAux.valor == 0 || carta == cartaAux)
                            cartaAux = carta;
                    }
                }
            }
            return cartaAux;
        }
    }
}