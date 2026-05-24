using System;

public class AFD
{
    public List<Estado> ConjuntoEstados { get; set; }

    public List<char> Alfabeto { get; set; }

    public List<Transicao> Transicoes { get; set; }

    public Estado EstadoInicial { get; set; }

    public List<Estado> EstadosFinais { get; set; }

    public AFD(
        List<Estado> conjuntoEstados,
        List<char> alfabeto,
        List<Transicao> transicoes,
        Estado estadoInicial,
        List<Estado> estadosFinais)
    {
        ConjuntoEstados = conjuntoEstados;
        Alfabeto = alfabeto;
        Transicoes = transicoes;
        EstadoInicial = estadoInicial;
        EstadosFinais = estadosFinais;
    }

    public Transicao BuscarTransicao(
        Estado estadoOrigem,
        char simbolo)
    {
        foreach (Transicao transicao in Transicoes)
        {
            if (
                transicao.EstadoOrigem.Nome == estadoOrigem.Nome &&
                transicao.Simbolo == simbolo)
            {
                return transicao;
            }
        }

        return null;
    }
}
