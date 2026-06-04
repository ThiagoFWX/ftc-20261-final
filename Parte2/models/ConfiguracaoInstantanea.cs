using System.Text;

namespace Parte2.Models;

public class ConfiguracaoInstantanea
{
    public string estado { get; set; }
    public int posicaoEntrada { get; set; }
    public Stack<char> pilha { get; set; }

    public ConfiguracaoInstantanea(string estado, int posicaoEntrada, Stack<char> pilha)
    {
        this.estado = estado;
        this.posicaoEntrada = posicaoEntrada;
        this.pilha = pilha;
    }

    public string ObterEntradaRestante(string cadeia)
    {
        if (this.posicaoEntrada >= cadeia.Length)
        {
            return "ε";
        }
        return cadeia.Substring(this.posicaoEntrada);
    }

    public string ObterConteudoPilha()
    {
        if (this.pilha.Count == 0)
        {
            return "ε";
        }

        char[] pilhaArr = this.pilha.ToArray();
        Array.Reverse(pilhaArr); 

        return new string(pilhaArr);
    }

    public string ObterChaveVisitada()
    {
        return $"Estado: {this.estado} | Entrada: '{this.posicaoEntrada}' | Pilha: [{ObterConteudoPilha()}]";
    }
}