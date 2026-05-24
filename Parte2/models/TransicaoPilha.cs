namespace Parte2.Models;

public class TransicaoPilha
{
    public string EstadoOrigem { get; set; }
    public char SimboloEntrada { get; set; }
    public char SimboloTopoPilha { get; set; }
    public string EstadoDestino { get; set; }
    public string SimbolosParaEmpilhar { get; set; }

    public TransicaoPilha(
        string estadoOrigem,
        char simboloEntrada,
        char simboloTopoPilha,
        string estadoDestino,
        string simbolosParaEmpilhar)
    {
        EstadoOrigem = estadoOrigem;
        SimboloEntrada = simboloEntrada;
        SimboloTopoPilha = simboloTopoPilha;
        EstadoDestino = estadoDestino;
        SimbolosParaEmpilhar = simbolosParaEmpilhar;
    }

    public bool EhMovimentoLambda()
    {
        return SimboloEntrada == '\0';
    }
}
