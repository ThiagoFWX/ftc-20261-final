using System.Collections.Generic;

public class AutomatoPilha
{
    public string EstadoInicial { get; set; }

    public List<string> EstadosFinais { get; set; }

    public List<TransicaoPilha> Transicoes { get; set; }
}