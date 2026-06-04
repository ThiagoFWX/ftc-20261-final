using System;
using System.Collections.Generic;
using System.IO;

public class FileReaderService
{
    public List<string> LerCadeiasDaSecao(string caminhoArquivo, string nomeSecao)
    {
        List<string> cadeias = new List<string>();

        if (!File.Exists(caminhoArquivo))
        {
            Console.WriteLine("Arquivo não encontrado: " + caminhoArquivo);
            return cadeias;
        }

        string[] linhas = File.ReadAllLines(caminhoArquivo);

        bool secaoAtiva = false;

        foreach (string linhaOriginal in linhas)
        {
            string linha = linhaOriginal.Trim();

            if (linha == "")
            {
                continue;
            }

            if (linha.StartsWith("[") && linha.EndsWith("]"))
            {
                string secaoAtual = linha.Substring(1, linha.Length - 2);
                secaoAtiva = secaoAtual.ToLower() == nomeSecao.ToLower();
                continue;
            }

            if (secaoAtiva)
            {
                if (linha == "E" || linha == "ε")
                {
                    cadeias.Add("");
                }
                else
                {
                    cadeias.Add(linha);
                }
            }
        }

        return cadeias;
    }
}