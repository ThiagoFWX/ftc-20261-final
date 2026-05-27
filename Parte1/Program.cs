using Parte1.models;

namespace Parte1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Carregar AFD do JSON
            AFDConfigLoaderService loader =
                new AFDConfigLoaderService();

            AFD afd =
                loader.CarregarAFD(
                    "config/afd.json");

            // Ler entradas
            FileReaderService reader =
                new FileReaderService();

            List<string> entradas =
                reader.LerEntradas(
                    "data/entradas.txt");

            // Criar simulador
            AfdSimulatorService simulator =
                new AfdSimulatorService(afd);

            // Simular cada cadeia
            foreach (string cadeia in entradas)
            {
                bool aceita =
                    simulator.Simular(cadeia);

                Console.WriteLine(
                    "=================================");

                Console.WriteLine(
                    $"Cadeia: {cadeia}");

                Console.WriteLine();

                Console.WriteLine(
                    "Rastreamento:");

                foreach (string passo in simulator.Rastro)
                {
                    Console.WriteLine(passo);
                }

                Console.WriteLine();

                Console.WriteLine(
                    $"Estado Final: {simulator.EstadoAtual}");

                Console.WriteLine();

                Console.WriteLine(
                    aceita
                    ? "Resultado: ACEITA"
                    : "Resultado: REJEITA");

                Console.WriteLine(
                    "=================================");

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}