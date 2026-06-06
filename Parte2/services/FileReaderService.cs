using System;
using System.Collections.Generic;
using System.IO;

public class FileReaderService
{
    // Lê as cadeias de uma seção específica do arquivo
    public List<string> LerEntradas(string caminhoArquivo, string nomeSecao)
    {
        List<string> cadeias = new List<string>();

        // Verifica se o arquivo existe
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

            // Ignora linhas vazias
            if (linha == "")
            {
                continue;
            }

            // Identifica mudança de seção
            if (linha.StartsWith("[") && linha.EndsWith("]"))
            {
                string secaoAtual = linha.Substring(1, linha.Length - 2);
                secaoAtiva = secaoAtual.ToLower() == nomeSecao.ToLower();
                continue;
            }

            // Lê apenas as cadeias da seção selecionada
            if (secaoAtiva)
            {
                // Converte E ou ε para cadeia vazia
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