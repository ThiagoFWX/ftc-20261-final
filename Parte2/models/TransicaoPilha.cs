public class TransicaoPilha
{
    public string estadoAtual { get; set; }
    public char simboloEntrada { get; set; }
    public char topoPilha { get; set; }
    public string proximoEstado { get; set; }
    public string acaoPilha { get; set; }

    public TransicaoPilha(string estadoAtual, char simboloEntrada, char topoPilha, string proximoEstado, string acaoPilha)
    {
        this.estadoAtual = estadoAtual;
        this.simboloEntrada = simboloEntrada;
        this.topoPilha = topoPilha;
        this.proximoEstado = proximoEstado;
        this.acaoPilha = acaoPilha;
    }
}