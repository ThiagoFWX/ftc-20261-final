using System;

public class FileReaderService
{
    public List<string> LerEntradas(string caminhoArquivo)
    {
        List<string> linhas = new List<string>();

        using (StreamReader streamReader =
               new StreamReader(caminhoArquivo))
        {
            string linha;

            while ((linha = streamReader.ReadLine()) != null)
            {
                linhas.Add(linha);
            }
        }

        return linhas;
    }
}
