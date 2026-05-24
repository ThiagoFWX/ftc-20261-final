namespace Parte2.Services;

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

        bool estaNaSecaoCorreta = false;

        foreach (string linhaOriginal in linhas)
        {
            string linha = linhaOriginal.Trim();

            if (linha == "")
            {
                continue;
            }

            if (linha.StartsWith("[") && linha.EndsWith("]"))
            {
                string secaoAtual = linha.Replace("[", "").Replace("]", "");
                estaNaSecaoCorreta = secaoAtual.Equals(nomeSecao, StringComparison.OrdinalIgnoreCase);
                continue;
            }

            if (estaNaSecaoCorreta)
            {
                if (linha == "ε")
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
