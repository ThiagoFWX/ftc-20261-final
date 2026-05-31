using System.Collections.Generic;

public class AutomatoPilha
{
    public string estadoInicial { get; set; }

    public List<string> estadosFinais { get; set; }

    public List<TransicaoPilha> transicoes { get; set; }
}