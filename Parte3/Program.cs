using Parte3.models;
using Parte3.services;

namespace Parte3
{
    internal class Program
    {
        static void Main(
        string[] args)
        {
            MtConfigLoaderService
            loader
            =
            new();

            MaquinaTuring mt =
            loader.CarregarMT(
            "config/mt.json");

            MtSimulatorService
            sim =
            new(
            mt);

            bool aceita =
            sim.Simular(
            "a");

            foreach (
            string passo
            in sim.Rastro)
            {
                Console.WriteLine(
                passo);
            }

            Console.WriteLine();

            Console.WriteLine(

            aceita

            ?

            "ACEITA"

            :

            "REJEITA"

            );

            Console.ReadKey();
        }
    }
}