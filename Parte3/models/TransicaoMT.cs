using System;
using System.Collections.Generic;
using System.Text;

namespace Parte3.models
{
    public class TransicaoMT
    {
        public EstadoMT EstadoOrigem { get; set; }
        public EstadoMT EstadoDestino { get; set; }
        public char SimboloLido { get; set; }
        public char NovoSimbolo { get; set; }
        public char Direcao { get; set; }

        public TransicaoMT(EstadoMT estadoOrigem, EstadoMT estadoDestino, char simboloLido, char novoSimbolo, char direcao)
        {
            EstadoOrigem = estadoOrigem;
            EstadoDestino = estadoDestino;
            SimboloLido = simboloLido;
            NovoSimbolo = novoSimbolo;
            Direcao = direcao;
        }

        // Retorna a transição no formato formal da MT
        public override string ToString()
        {
            return $"δ({EstadoOrigem},{SimboloLido}) → ({EstadoDestino},{NovoSimbolo},{Direcao})";
        }
    }
}
