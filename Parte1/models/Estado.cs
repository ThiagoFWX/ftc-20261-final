using System;

public class Estado
{
    public string Nome { get; set; }

    public bool EhFinal { get; set; }

    public Estado(string nome, bool ehFinal)
    {
        Nome = nome;
        EhFinal = ehFinal;
    }

    public override string ToString()
    {
        return Nome;
    }

}
