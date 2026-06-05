using System;
using System.Collections.Generic;
using System.Text;

namespace Parte3.models
{
    public class MaquinaTuring
    {
        public List<EstadoMT> ConjuntoEstados { get; set; }

        public List<char> Alfabeto { get; set; }

        public List<TransicaoMT> Transicoes { get; set; }

        public EstadoMT EstadoInicial { get; set; }

        public List<EstadoMT> EstadosFinais { get; set; }

        public MaquinaTuring(
            List<EstadoMT> conjuntoEstados,
            List<char> alfabeto,
            List<TransicaoMT> transicoes,
            List<EstadoMT> estadosFinais,
            List<EstadoMT> estadosRejeicao)
        {
            ConjuntoEstados = conjuntoEstados;
            Alfabeto = alfabeto;
            Transicoes = transicoes;
            EstadosFinais = estadosFinais;
        }
    }
}
