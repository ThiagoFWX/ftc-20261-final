using System;
using System.Collections.Generic;
using System.Text;

namespace Parte3.models
{
    public class Cabecote
    {
        public int Posicao { get; set; }

        public Cabecote()
        {
            Posicao = 0;
        }

        public void Mover(char direcao)
        {
            if (direcao == 'R')
            {
                Posicao++;
            } else if (direcao == 'L')
            {
                Posicao--;
            }
        }

        public override string ToString()
        {
            return Posicao.ToString();
        }
    }
}
