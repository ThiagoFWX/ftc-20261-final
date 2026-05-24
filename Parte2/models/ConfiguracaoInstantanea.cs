using System.Text;

namespace Parte2.Models;

public class ConfiguracaoInstantanea
{
    public string EstadoAtual { get; set; }
    public int PosicaoEntrada { get; set; }
    public Stack<char> Pilha { get; set; }

    public ConfiguracaoInstantanea(string estadoAtual, int posicaoEntrada, Stack<char> pilha)
    {
        EstadoAtual = estadoAtual;
        PosicaoEntrada = posicaoEntrada;
        Pilha = pilha;
    }

    public string ObterEntradaRestante(string cadeia)
    {
        if (PosicaoEntrada >= cadeia.Length)
        {
            return "ε";
        }

        return cadeia.Substring(PosicaoEntrada);
    }

    public string ObterConteudoPilha()
    {
        if (Pilha.Count == 0)
        {
            return "ε";
        }

        StringBuilder conteudo = new StringBuilder();

        foreach (char simbolo in Pilha)
        {
            conteudo.Append(simbolo);
        }

        return conteudo.ToString();
    }

    public string ObterChaveVisitada()
    {
        return EstadoAtual + "|" + PosicaoEntrada + "|" + ObterConteudoPilha();
    }
}
