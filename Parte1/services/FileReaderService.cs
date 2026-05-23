using System;

public class FIleReaderService
{
	public string entrada { get; set; }
    public FIleReaderService(string entrada)
	{
		this.entrada = entrada;
	}
	public List<String> lerEntrada()
    {
        List<String> linhas = new List<String>();
        using (StreamReader sr = new StreamReader(entrada))
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                linhas.Add(linha);
            }
        }
        return linhas;
    }
}
