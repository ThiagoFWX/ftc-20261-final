public class TransicaoPilha
{
    public string estadoOrigem { get; set; }
    public char simboloEntrada { get; set; }
    public char topoPilha { get; set; }
    public string proximoEstado { get; set; }
    public string acaoPilha { get; set; }

    public TransicaoPilha(string estadoOrigem, char simboloEntrada, char topoPilha, string proximoEstado, string acaoPilha)
    {
        this.estadoOrigem = estadoOrigem;
        this.simboloEntrada = simboloEntrada;
        this.topoPilha = topoPilha;
        this.proximoEstado = proximoEstado;
        this.acaoPilha = acaoPilha;
    }

    // Verifica se a transição é um movimento λ (lambda)
    public bool EhMovimentoLambda()
    {
        return this.simboloEntrada == '\0';
    }
}