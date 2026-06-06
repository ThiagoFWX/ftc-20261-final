using Parte3.models;
using Parte3.services;

namespace Parte3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Carrega configuração da MT
            MtConfigLoaderService loader = new MtConfigLoaderService();

            MaquinaTuring mt = loader.CarregarMT("config/mt.json");

            // Ler entradas
            FileReaderService reader = new FileReaderService();

            List<string> entradas = reader.LerEntradas("data/entradas_mt.txt");


            // Criar simulador
            MtSimulatorService simulator = new MtSimulatorService(mt);

            // Executar todas entradas
            foreach (string entrada in entradas)
            {
                bool aceita = simulator.Simular(entrada);

                Console.WriteLine();
                Console.WriteLine("=================================");
                Console.WriteLine($"Entrada: {entrada}");
                Console.WriteLine();
                Console.WriteLine("RASTREAMENTO:");
                Console.WriteLine();

                foreach (string passo in simulator.Rastro)
                {
                    Console.WriteLine(passo);
                }

                Console.WriteLine();
                Console.WriteLine(aceita ? "RESULTADO: ACEITA" : "RESULTADO: REJEITA");
                Console.WriteLine("=================================");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}