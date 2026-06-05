namespace Parte3.services
{
    public class FileReaderService
    {
        public List<string>
            LerEntradas(
            string caminhoArquivo)
        {
            List<string>
                entradas =
                new();

            using (
                StreamReader
                reader =
                new StreamReader(
                    caminhoArquivo))
            {
                string linha;

                while (
                    (
                    linha =
                    reader.ReadLine()
                    )
                    !=
                    null)
                {
                    if (
                        !string
                        .IsNullOrWhiteSpace(
                            linha))
                    {
                        entradas
                        .Add(
                            linha
                            .Trim());
                    }
                }
            }

            return entradas;
        }
    }
}