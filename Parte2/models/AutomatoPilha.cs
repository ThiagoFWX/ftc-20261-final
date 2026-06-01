using System.Collections.Generic;

public class AutomatoPilha
{
    public List<string> estados { get; set; }
    public List<char> alfabetoEntrada { get; set; }
    public List<char> alfabetoPilha { get; set; }
    public Dictionary<(string, char, char), List<TransicaoPilha>> transicoes { get; set; }
    public string estadoInicial { get; set; }
    public char simboloInicialPilha { get; set; }

    public AutomatoPilha(List<string> estados,
        List<char> alfabetoEntrada,
        List<char> alfabetoPilha,
        Dictionary<(string, char, char), List<TransicaoPilha>> transicoes,
        string estadoInicial,
        char simboloInicialPilha)
    {
        this.estados = estados;
        this.alfabetoEntrada = alfabetoEntrada;
        this.alfabetoPilha = alfabetoPilha;
        this.transicoes = transicoes;
        this.estadoInicial = estadoInicial;
        this.simboloInicialPilha = simboloInicialPilha;
    }

    public List<TransicaoPilha> ObterTransicoes(string estado, char simboloEntrada, char topoPilha)
    {
        var chave = (estado, simboloEntrada, topoPilha);

        if (this.transicoes.ContainsKey(chave))
        {
            possiveisTransicoes.AddRange(this.transicoes[chave]);
        }

        var chaveLambda = (estado, '\0', topoPilha);

        if (this.transicoes.ContainsKey(chaveLambda))
        {
            possiveisTransicoes.AddRange(this.transicoes[chaveLambda]);
        }

        return possiveisTransicoes;
    }
}