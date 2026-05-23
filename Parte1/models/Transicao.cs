using System;

public class Transicao
{
	public Estado estadoOrigem { get; set; }
    public Estado estadoDestino {  get; set; }
    public char simbolo {  get; set; }
    public override string ToString()
    {
        return "(" + simbolo +","+ estadoOrigem+ ")" + "=" + estadoDestino;
    }
    public Transicao(Estado estadoOrigem, Estado estadoDestino, char simbolo)
	{
		this.estadoOrigem= estadoOrigem;
        this.estadoDestino = estadoDestino;
        this.simbolo = simbolo;

    }
}
