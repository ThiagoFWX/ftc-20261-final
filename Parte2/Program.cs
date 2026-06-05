using Parte2.Models;

namespace Parte2;

class Program
{
    static void Main(string[] args)
    {
        FileReaderService fileReaderService = new FileReaderService();
        SimuladorAutomatoPilhaService simulador = new SimuladorAutomatoPilhaService(500);
        string caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "data", "entradas.txt");

        List<string> entradasL2 = fileReaderService.LerEntradas(caminhoArquivo, "L2");
        List<string> entradasL3 = fileReaderService.LerEntradas(caminhoArquivo, "L3");

        AutomatoPilha automatoL2 = CriarAutomatoParaAnBn();
        AutomatoPilha automatoL3 = CriarAutomatoParaPalindromos();

        Console.WriteLine("========================================");
        Console.WriteLine("LINGUAGEM L2 = { a^n b^n | n >= 1 }");
        Console.WriteLine("========================================");

        foreach (string cadeia in entradasL2)
        {
            simulador.Simular(automatoL2, cadeia);
            Console.WriteLine();
        }

        Console.WriteLine("========================================");
        Console.WriteLine("LINGUAGEM L3 = { w ∈ {a, b}∗ | w = wR, |w| ≥ 1 }");
        Console.WriteLine("========================================");

        foreach (string cadeia in entradasL3)
        {
            simulador.Simular(automatoL3, cadeia);
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Execução finalizada.");
        Console.ReadLine();
    }

    private static AutomatoPilha CriarAutomatoParaAnBn()
    {
        List<string> estados = new()
        {
            EstadoPilha.LendoAs,
            EstadoPilha.LendoBs
        };

        List<char> alfabetoEntrada = new() { 'a', 'b' };
        List<char> alfabetoPilha = new() { 'Z', 'A' };

        List<TransicaoPilha> transicoes = new()
        {
            new TransicaoPilha(EstadoPilha.LendoAs, 'a', 'Z', EstadoPilha.LendoAs, "AZ"),
            new TransicaoPilha(EstadoPilha.LendoAs, 'a', 'A', EstadoPilha.LendoAs, "AA"),
            new TransicaoPilha(EstadoPilha.LendoAs, 'b', 'A', EstadoPilha.LendoBs, ""),
            new TransicaoPilha(EstadoPilha.LendoBs, 'b', 'A', EstadoPilha.LendoBs, ""),
            new TransicaoPilha(EstadoPilha.LendoBs, '\0', 'Z', EstadoPilha.LendoBs, "")
        };

        return new AutomatoPilha(
            "L2",
            estados,
            alfabetoEntrada,
            alfabetoPilha,
            transicoes,
            EstadoPilha.LendoAs,
            'Z'
        );
    }

    private static AutomatoPilha CriarAutomatoParaPalindromos()
    {
        List<string> estados = new()
        {
            EstadoPilha.EmpilhandoPalindromo,
            EstadoPilha.DesempilhandoPalindromo
        };

        List<char> alfabetoEntrada = new() { 'a', 'b' };
        List<char> alfabetoPilha = new() { 'Z', 'a', 'b' };

        List<TransicaoPilha> transicoes = new();

        char[] simbolos = { 'Z', 'a', 'b' };

        foreach (char topo in simbolos)
        {
            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo, 'a', topo,
                EstadoPilha.EmpilhandoPalindromo, "a" + topo));

            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo, 'b', topo,
                EstadoPilha.EmpilhandoPalindromo, "b" + topo));

            if (topo != 'Z')
            {
                transicoes.Add(new TransicaoPilha(
                    EstadoPilha.EmpilhandoPalindromo, '\0', topo,
                    EstadoPilha.DesempilhandoPalindromo, topo.ToString()));
            }

            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo, 'a', topo,
                EstadoPilha.DesempilhandoPalindromo, topo.ToString()));

            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo, 'b', topo,
                EstadoPilha.DesempilhandoPalindromo, topo.ToString()));
        }

        transicoes.Add(new TransicaoPilha(
            EstadoPilha.DesempilhandoPalindromo, 'a', 'a',
            EstadoPilha.DesempilhandoPalindromo, ""));

        transicoes.Add(new TransicaoPilha(
            EstadoPilha.DesempilhandoPalindromo, 'b', 'b',
            EstadoPilha.DesempilhandoPalindromo, ""));

        transicoes.Add(new TransicaoPilha(
            EstadoPilha.DesempilhandoPalindromo, '\0', 'Z',
            EstadoPilha.DesempilhandoPalindromo, ""));

        return new AutomatoPilha(
            "L3",
            estados,
            alfabetoEntrada,
            alfabetoPilha,
            transicoes,
            EstadoPilha.EmpilhandoPalindromo,
            'Z'
        );
    }
}