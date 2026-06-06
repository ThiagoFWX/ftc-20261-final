namespace Parte3.services
{
    public class FileReaderService
    {
        // Lê todas as entradas do arquivo de testes
        public List<string> LerEntradas(string caminhoArquivo)
        {
            List<string> entradas = new();

            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                string linha;

                // Lê cada linha do arquivos
                while ((linha = reader.ReadLine()) != null)
                {
                    // Ignora linhas vazias
                    if (!string.IsNullOrWhiteSpace(linha))
                    {
                        entradas.Add(linha.Trim());
                    }
                }
            }

            return entradas;
        }
    }
}