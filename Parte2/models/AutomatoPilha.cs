using System.Collections.Generic;

public class AutomatoPilha
{
    public List<string> estados { get; set; }
    public List<char> alfabetoEntrada { get; set; }
    public List<char> alfabetoPilha { get; set; }
    public Dictionary<(string, char, char), List<TransicaoPilha>> transicoes { get; set; }
    public string estadoInicial { get; set; }
    public char simboloInicial { get; set; }
    public List<string> estadosAceitacao { get; set; }

    public AutomatoPilha()
    {
        this.estados = new List<string>();
        this.alfabetoEntrada = new List<char>();
        this.alfabetoPilha = new List<char>();
        this.transicoes = new Dictionary<(string, char, char), List<TransicaoPilha>>();
        this.estadosAceitacao = new List<string>();
    }
}