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

    // Retorna o restante da entrada a partir da posição atual
    public string ObterEntradaRestante(string cadeia)
    {
        if (this.posicaoEntrada >= cadeia.Length)
        {
            return "ε"; // símbolo vazio
        }
        return cadeia.Substring(this.posicaoEntrada);
    }

    // Retorna o conteúdo da pilha como string (topo -> base)
    public string ObterConteudoPilha()
    {
        if (this.pilha.Count == 0)
        {
            return "ε"; // pilha vazia
        }

        char[] pilhaArr = this.pilha.ToArray();

        // Inverte para mostrar na ordem correta
        Array.Reverse(pilhaArr); 

        return new string(pilhaArr);
    }

    // Gera uma chave textual da configuração
    public string ObterChaveVisitada()
    {
        return $"Estado: {this.estado} | Entrada: '{this.posicaoEntrada}' | Pilha: [{ObterConteudoPilha()}]";
    }
}