using Parte2.Models;
using Parte2.Services;

namespace Parte2;

public class Program
{
    public static void Main(string[] args)
    {
        FileReaderService fileReaderService = new FileReaderService();
        ApSimulatorService apSimulatorService = new ApSimulatorService(500);

        string caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "data", "entradas_ap.txt");

        List<string> cadeiasL2 = fileReaderService.LerCadeiasDaSecao(caminhoArquivo, "L2");
        List<string> cadeiasL3 = fileReaderService.LerCadeiasDaSecao(caminhoArquivo, "L3");

        AutomatoPilha automatoL2 = CriarAutomatoParaAnBn();
        AutomatoPilha automatoL3 = CriarAutomatoParaPalindromos();

        Console.WriteLine("========================================");
        Console.WriteLine("TESTES DA LINGUAGEM L2 = { a^n b^n | n >= 1 }");
        Console.WriteLine("========================================");

        foreach (string cadeia in cadeiasL2)
        {
            apSimulatorService.Aceitar(automatoL2, cadeia);
            Console.WriteLine();
        }

        Console.WriteLine("========================================");
        Console.WriteLine("TESTES DA LINGUAGEM L3 = PALÍNDROMOS");
        Console.WriteLine("========================================");

        foreach (string cadeia in cadeiasL3)
        {
            apSimulatorService.Aceitar(automatoL3, cadeia);
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Execução finalizada.");
        Console.WriteLine("Pressione ENTER para sair.");
        Console.ReadLine();

    }

    private static AutomatoPilha CriarAutomatoParaAnBn()
    {
        List<string> estados = new List<string>
       {
           EstadoPilha.LendoAs,
           EstadoPilha.LendoBs
       };

        List<char> alfabetoEntrada = new List<char>
       {
           'a',
           'b'
       };

        List<char> alfabetoPilha = new List<char>
       {
           'Z',
           'A'
       };

        List<TransicaoPilha> transicoes = new List<TransicaoPilha>
       {
           // Ao ler 'a' com Z no topo, empilha A acima de Z.
           new TransicaoPilha(
               EstadoPilha.LendoAs,
               'a',
               'Z',
               EstadoPilha.LendoAs,
               "AZ"
           ),

           // Ao ler outro 'a', empilha mais um A.
           new TransicaoPilha(
               EstadoPilha.LendoAs,
               'a',
               'A',
               EstadoPilha.LendoAs,
               "AA"
           ),

           // Ao encontrar o primeiro 'b', começa a desempilhar os A.
           new TransicaoPilha(
               EstadoPilha.LendoAs,
               'b',
               'A',
               EstadoPilha.LendoBs,
               ""
           ),

           // Para cada 'b', remove um A da pilha.
           new TransicaoPilha(
               EstadoPilha.LendoBs,
               'b',
               'A',
               EstadoPilha.LendoBs,
               ""
           ),

           // Quando a entrada acaba e só sobra Z, remove Z por lambda.
           new TransicaoPilha(
               EstadoPilha.LendoBs,
               '\0',
               'Z',
               EstadoPilha.LendoBs,
               ""
           )
       };

        return new AutomatoPilha(
            "AP para L2 = { a^n b^n | n >= 1 }",
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
        List<string> estados = new List<string>
       {
           EstadoPilha.EmpilhandoPalindromo,
           EstadoPilha.DesempilhandoPalindromo
       };

        List<char> alfabetoEntrada = new List<char>
       {
           'a',
           'b'
       };

        List<char> alfabetoPilha = new List<char>
       {
           'Z',
           'a',
           'b'
       };

        List<TransicaoPilha> transicoes = new List<TransicaoPilha>();

        char[] simbolosDaPilha =
        {
           'Z',
           'a',
           'b'
       };

        foreach (char simboloTopo in simbolosDaPilha)
        {
            // Enquanto está na primeira metade, empilha cada 'a' lido.
            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo,
                'a',
                simboloTopo,
                EstadoPilha.EmpilhandoPalindromo,
                "a" + simboloTopo
            ));

            // Enquanto está na primeira metade, empilha cada 'b' lido.
            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo,
                'b',
                simboloTopo,
                EstadoPilha.EmpilhandoPalindromo,
                "b" + simboloTopo
            ));

            // Caso de palíndromo com tamanho par:
            // muda para a fase de comparação sem consumir símbolo.
            // Essa transição não existe para Z, para não aceitar a cadeia vazia.
            if (simboloTopo != 'Z')
            {
                transicoes.Add(new TransicaoPilha(
                    EstadoPilha.EmpilhandoPalindromo,
                    '\0',
                    simboloTopo,
                    EstadoPilha.DesempilhandoPalindromo,
                    simboloTopo.ToString()
                ));
            }

            // Caso de palíndromo com tamanho ímpar:
            // consome o símbolo do meio sem alterar a pilha.
            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo,
                'a',
                simboloTopo,
                EstadoPilha.DesempilhandoPalindromo,
                simboloTopo.ToString()
            ));

            transicoes.Add(new TransicaoPilha(
                EstadoPilha.EmpilhandoPalindromo,
                'b',
                simboloTopo,
                EstadoPilha.DesempilhandoPalindromo,
                simboloTopo.ToString()
            ));
        }

        // Na segunda metade, compara 'a' da entrada com 'a' do topo da pilha.
        transicoes.Add(new TransicaoPilha(
            EstadoPilha.DesempilhandoPalindromo,
            'a',
            'a',
            EstadoPilha.DesempilhandoPalindromo,
            ""
        ));

        // Na segunda metade, compara 'b' da entrada com 'b' do topo da pilha.
        transicoes.Add(new TransicaoPilha(
            EstadoPilha.DesempilhandoPalindromo,
            'b',
            'b',
            EstadoPilha.DesempilhandoPalindromo,
            ""
        ));

        // Quando a entrada acaba e só sobra Z, remove Z por lambda.
        transicoes.Add(new TransicaoPilha(
            EstadoPilha.DesempilhandoPalindromo,
            '\0',
            'Z',
            EstadoPilha.DesempilhandoPalindromo,
            ""
        ));

        return new AutomatoPilha(
            "AP para L3 = palíndromos sobre {a,b}",
            estados,
            alfabetoEntrada,
            alfabetoPilha,
            transicoes,
            EstadoPilha.EmpilhandoPalindromo,
            'Z'
        );
    }
}
