using System;
using System.Collections.Generic;
using System.Text;

namespace Parte3.models
{
    public class MaquinaTuring
    {
        public List<EstadoMT> Estados
        {
            get;
            set;
        }

        public List<char> AlfabetoEntrada
        {
            get;
            set;
        }

        public List<char> AlfabetoFita
        {
            get;
            set;
        }

        public List<TransicaoMT> Transicoes
        {
            get;
            set;
        }

        public EstadoMT EstadoInicial
        {
            get;
            set;
        }

        public EstadoMT EstadoAceitacao
        {
            get;
            set;
        }

        public EstadoMT EstadoRejeicao
        {
            get;
            set;
        }

        public MaquinaTuring(
            List<EstadoMT> estados,
            List<char> alfabetoEntrada,
            List<char> alfabetoFita,
            List<TransicaoMT> transicoes,
            EstadoMT estadoInicial,
            EstadoMT estadoAceitacao,
            EstadoMT estadoRejeicao)
        {
            Estados = estados;

            AlfabetoEntrada =
                alfabetoEntrada;

            AlfabetoFita =
                alfabetoFita;

            Transicoes =
                transicoes;

            EstadoInicial =
                estadoInicial;

            EstadoAceitacao =
                estadoAceitacao;

            EstadoRejeicao =
                estadoRejeicao;
        }

        public TransicaoMT
            BuscarTransicao(
            EstadoMT estado,
            char simbolo)
        {
            foreach (
                TransicaoMT transicao
                in Transicoes)
            {
                if (
                    transicao
                    .EstadoOrigem
                    .Nome
                    ==
                    estado
                    .Nome

                    &&

                    transicao
                    .SimboloLido
                    ==
                    simbolo
                    )
                {
                    return transicao;
                }
            }

            return null;
        }
    }
}
