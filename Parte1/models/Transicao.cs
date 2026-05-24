using System;

public class Transicao
{
    public Estado EstadoOrigem { get; set; }

    public char Simbolo { get; set; }

    public Estado EstadoDestino { get; set; }

    public Transicao(
        Estado estadoOrigem,
        char simbolo,
        Estado estadoDestino)
    {
        EstadoOrigem = estadoOrigem;
        Simbolo = simbolo;
        EstadoDestino = estadoDestino;
    }

    public override string ToString()
    {
        return $"δ({EstadoOrigem}, {Simbolo}) = {EstadoDestino}";
    }
}
