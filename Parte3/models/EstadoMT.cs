using System;
using System.Collections.Generic;
using System.Text;

namespace Parte3.models
{

    public class EstadoMT
    {
        public string Nome { get; set; }
        public bool EhAceitacao { get; set; }
        public bool EhRejeicao { get; set; }
        public EstadoMT(string nome, bool ehAceitacao, bool ehRejeicao) {
            Nome = nome;
            EhAceitacao = ehAceitacao;
            EhRejeicao = ehRejeicao;
        }
        public override string ToString()
        {
            return Nome;
        }
    }
}
