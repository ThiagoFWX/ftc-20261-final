using Parte3.models;
using Parte3.services;

namespace Parte3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExecutarMT("config/mt.json", "data/entradas_mt.txt", "MT - Reconhecimento aⁿbⁿcⁿ", true);
            ExecutarMT("config/mt_unario.json", "data/entradas_unario.txt", "MT - Funcao f(n) = n + 1", false);

            Console.ReadKey();
        }

        static void ExecutarMT(string arquivoMt, string arquivoEntradas, string titulo, bool mostrarAceitacao)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine(titulo);
            Console.WriteLine("=================================");
            Console.WriteLine();

            MtConfigLoaderService loader = new MtConfigLoaderService();

            MaquinaTuring mt = loader.CarregarMT(arquivoMt);

            FileReaderService reader = new FileReaderService();

            List<string> entradas = reader.LerEntradas(arquivoEntradas);

            MtSimulatorService simulator = new MtSimulatorService(mt);

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
                if (mostrarAceitacao)
                {
                    Console.WriteLine(aceita ? "RESULTADO: ACEITA" : "RESULTADO: REJEITA");
                }
                else
                {
                    Console.WriteLine($"SAIDA: {simulator.Fita}");
                }
                Console.WriteLine("=================================");
                Console.WriteLine();
            }
        }
        }
    }