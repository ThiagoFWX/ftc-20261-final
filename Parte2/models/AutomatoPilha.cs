using System.Collections.Generic;

namespace Parte2.Models;

public class AutomatoPilha
{
    public string nome { get; set; }
    public List<string> estados { get; set; }
    public List<char> alfabetoEntrada { get; set; }
    public List<char> alfabetoPilha { get; set; }
    public List<TransicaoPilha> transicoes { get; set; }
    public string estadoInicial { get; set; }
    public char simboloInicialPilha { get; set; }

    public AutomatoPilha(string nome, List<string> estados, List<char> alfabetoEntrada, List<char> alfabetoPilha, List<TransicaoPilha> transicoes, string estadoInicial, char simboloInicialPilha)
    {
        this.nome = nome;
        this.estados = estados;
        this.alfabetoEntrada = alfabetoEntrada;
        this.alfabetoPilha = alfabetoPilha;
        this.transicoes = transicoes;
        this.estadoInicial = estadoInicial;
        this.simboloInicialPilha = simboloInicialPilha;
    }

    public List<TransicaoPilha> ObterTransicoes(string estado, char simboloEntrada, char topoPilha)
    {
        List<TransicaoPilha> possiveisTransicoes = new List<TransicaoPilha>();

        foreach (TransicaoPilha transicao in this.transicoes)
        {
            bool lambda = transicoes.EhMovimentoLambda();

            if (transicao.estadoOrigem == estado 
                && transicao.topoPilha == topoPilha 
                && (transicao.simboloEntrada == simboloEntrada || lambda))
            {
                possiveisTransicoes.Add(transicao);
            }
        }

        return possiveisTransicoes;
    }
}