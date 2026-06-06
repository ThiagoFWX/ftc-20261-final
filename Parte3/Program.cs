using Parte3.models;
using Parte3.services;

namespace Parte3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Executa a MT de reconhecimento aⁿbⁿcⁿ
            ExecutarMT("config/mt.json", "data/entradas_mt.txt", "MT - Reconhecimento aⁿbⁿcⁿ", true);

            // Executa a MT da função f(n) = n + 1 em unário
            ExecutarMT("config/mt_unario.json", "data/entradas_unario.txt", "MT - Funcao f(n) = n + 1", false);

            Console.ReadKey();
        }

        // Carrega e executa uma Máquina de Turing
        static void ExecutarMT(string arquivoMt, string arquivoEntradas, string titulo, bool mostrarAceitacao)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine(titulo);
            Console.WriteLine("=================================");
            Console.WriteLine();

            // Carrega a configuração da MT
            MtConfigLoaderService loader = new MtConfigLoaderService();

            MaquinaTuring mt = loader.CarregarMT(arquivoMt);

            // Lê as entradas de teste
            FileReaderService reader = new FileReaderService();

            List<string> entradas = reader.LerEntradas(arquivoEntradas);
            
            // Cria o simulador da MT
            MtSimulatorService simulator = new MtSimulatorService(mt);

            // Executa todas as entradas
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

                // Exibe o resultado conforme o tipo da MT
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