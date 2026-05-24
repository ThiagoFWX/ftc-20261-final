namespace Parte2.Models;

public class AutomatoPilha
{
    public string Nome { get; set; }
    public List<string> Estados { get; set; }
    public List<char> AlfabetoEntrada { get; set; }
    public List<char> AlfabetoPilha { get; set; }
    public List<TransicaoPilha> Transicoes { get; set; }
    public string EstadoInicial { get; set; }
    public char SimboloInicialPilha { get; set; }

    public AutomatoPilha(
        string nome,
        List<string> estados,
        List<char> alfabetoEntrada,
        List<char> alfabetoPilha,
        List<TransicaoPilha> transicoes,
        string estadoInicial,
        char simboloInicialPilha)
    {
        Nome = nome;
        Estados = estados;
        AlfabetoEntrada = alfabetoEntrada;
        AlfabetoPilha = alfabetoPilha;
        Transicoes = transicoes;
        EstadoInicial = estadoInicial;
        SimboloInicialPilha = simboloInicialPilha;
    }

    public List<TransicaoPilha> ObterTransicoesPossiveis(
        string estadoAtual,
        char simboloEntrada,
        char simboloTopoPilha)
    {
        List<TransicaoPilha> transicoesPossiveis = new List<TransicaoPilha>();

        foreach (TransicaoPilha transicao in Transicoes)
        {
            bool mesmoEstado = transicao.EstadoOrigem == estadoAtual;
            bool mesmoTopo = transicao.SimboloTopoPilha == simboloTopoPilha;
            bool mesmoSimboloEntrada = transicao.SimboloEntrada == simboloEntrada;
            bool movimentoLambda = transicao.EhMovimentoLambda();

            if (mesmoEstado && mesmoTopo && (mesmoSimboloEntrada || movimentoLambda))
            {
                transicoesPossiveis.Add(transicao);
            }
        }

        return transicoesPossiveis;
    }
}
