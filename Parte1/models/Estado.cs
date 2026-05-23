using System;

public class Estado
{
    public string nome
	{
		get;
        set;
    }

	public bool indicador {  get; set; }
    public override string ToString()
    {
        return nome;
    }
    public Estado(string nome, bool indicador)
    {
        this.nome = nome;
        this.indicador = indicador;
    }
	
}
