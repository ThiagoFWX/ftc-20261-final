using System;

public class AFD
{
    public List<Estado> conjuntoEstados { get; set; }
    public List<char> alfabeto { get; set; }
    public List<Transicao> transicoes { get; set; }
    public Estado estadoInicial { get; set; }
    public List<Estado> estadosFinais { get; set; }
    public AFD(List<Estado> conjuntoEstados,List<char> alfabeto,List<Transicao> transicoes,Estado estadoInicial,
    List<Estado> estadosFinais)
	{
		this.conjuntoEstados = conjuntoEstados;
        this.alfabeto = alfabeto;
        this.transicoes = transicoes;
        this.estadosFinais = estadosFinais;
    }

    public Transicao getTransicao(Estado estadoOrigem, char simbolo)
    {
        foreach (Transicao t in transicoes)
        {
            if (t.estadoOrigem == estadoOrigem && t.simbolo == simbolo)
            {
                return t;
            }
        }
        return null;
    }
}
