using Parte2.Models;

namespace Parte2.Services;

public class ApSimulatorService
{
    private readonly int limitePassos;

    public ApSimulatorService(int limitePassos)
    {
        this.limitePassos = limitePassos;
    }

    public bool Aceitar(AutomatoPilha automatoPilha, string cadeia)
    {
        Console.WriteLine();
        Console.WriteLine("Autômato: " + automatoPilha.Nome);
        Console.WriteLine("Cadeia: " + ObterTextoCadeia(cadeia));
        Console.WriteLine();

        if (!CadeiaPossuiApenasSimbolosDoAlfabeto(automatoPilha, cadeia))
        {
            Console.WriteLine("Resultado: REJEITA");
            Console.WriteLine("Motivo: a cadeia possui símbolo fora do alfabeto.");
            return false;
        }

        Queue<ConfiguracaoInstantanea> filaConfiguracoes = new Queue<ConfiguracaoInstantanea>();
        HashSet<string> configuracoesVisitadas = new HashSet<string>();

        Stack<char> pilhaInicial = new Stack<char>();
        pilhaInicial.Push(automatoPilha.SimboloInicialPilha);

        ConfiguracaoInstantanea configuracaoInicial = new ConfiguracaoInstantanea(
            automatoPilha.EstadoInicial,
            0,
            pilhaInicial
        );

        filaConfiguracoes.Enqueue(configuracaoInicial);

        int quantidadePassos = 0;

        while (filaConfiguracoes.Count > 0 && quantidadePassos < limitePassos)
        {
            ConfiguracaoInstantanea configuracaoAtual = filaConfiguracoes.Dequeue();

            string chaveVisitada = configuracaoAtual.ObterChaveVisitada();

            if (configuracoesVisitadas.Contains(chaveVisitada))
            {
                continue;
            }

            configuracoesVisitadas.Add(chaveVisitada);

            ExibirConfiguracao(configuracaoAtual, cadeia, quantidadePassos);

            if (CadeiaFoiTodaLida(configuracaoAtual, cadeia) && configuracaoAtual.Pilha.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Resultado: ACEITA");
                return true;
            }

            if (configuracaoAtual.Pilha.Count == 0)
            {
                quantidadePassos++;
                continue;
            }

            char simboloTopoPilha = configuracaoAtual.Pilha.Peek();
            char simboloEntradaAtual = ObterSimboloEntradaAtual(configuracaoAtual, cadeia);

            List<TransicaoPilha> transicoesPossiveis = automatoPilha.ObterTransicoesPossiveis(
                configuracaoAtual.EstadoAtual,
                simboloEntradaAtual,
                simboloTopoPilha
            );

            foreach (TransicaoPilha transicao in transicoesPossiveis)
            {
                ConfiguracaoInstantanea novaConfiguracao = CriarNovaConfiguracao(
                    configuracaoAtual,
                    transicao
                );

                filaConfiguracoes.Enqueue(novaConfiguracao);
            }

            quantidadePassos++;
        }

        Console.WriteLine();
        Console.WriteLine("Resultado: REJEITA");

        if (quantidadePassos >= limitePassos)
        {
            Console.WriteLine("Motivo: limite de passos atingido.");
        }

        return false;
    }

    private ConfiguracaoInstantanea CriarNovaConfiguracao(
        ConfiguracaoInstantanea configuracaoAtual,
        TransicaoPilha transicao)
    {
        Stack<char> novaPilha = CopiarPilha(configuracaoAtual.Pilha);

        novaPilha.Pop();

        for (int i = transicao.SimbolosParaEmpilhar.Length - 1; i >= 0; i--)
        {
            novaPilha.Push(transicao.SimbolosParaEmpilhar[i]);
        }

        int novaPosicaoEntrada = configuracaoAtual.PosicaoEntrada;

        if (!transicao.EhMovimentoLambda())
        {
            novaPosicaoEntrada++;
        }

        return new ConfiguracaoInstantanea(
            transicao.EstadoDestino,
            novaPosicaoEntrada,
            novaPilha
        );
    }

    private Stack<char> CopiarPilha(Stack<char> pilhaOriginal)
    {
        Stack<char> novaPilha = new Stack<char>();

        char[] simbolos = pilhaOriginal.ToArray();

        for (int i = simbolos.Length - 1; i >= 0; i--)
        {
            novaPilha.Push(simbolos[i]);
        }

        return novaPilha;
    }

    private char ObterSimboloEntradaAtual(ConfiguracaoInstantanea configuracaoAtual, string cadeia)
    {
        if (configuracaoAtual.PosicaoEntrada >= cadeia.Length)
        {
            return '\0';
        }

        return cadeia[configuracaoAtual.PosicaoEntrada];
    }

    private bool CadeiaFoiTodaLida(ConfiguracaoInstantanea configuracaoAtual, string cadeia)
    {
        return configuracaoAtual.PosicaoEntrada == cadeia.Length;
    }

    private bool CadeiaPossuiApenasSimbolosDoAlfabeto(AutomatoPilha automatoPilha, string cadeia)
    {
        foreach (char simbolo in cadeia)
        {
            if (!automatoPilha.AlfabetoEntrada.Contains(simbolo))
            {
                return false;
            }
        }

        return true;
    }

    private void ExibirConfiguracao(
        ConfiguracaoInstantanea configuracao,
        string cadeia,
        int passo)
    {
        Console.WriteLine("Passo: " + passo);
        Console.WriteLine("Estado atual: " + configuracao.EstadoAtual);
        Console.WriteLine("Entrada restante: " + configuracao.ObterEntradaRestante(cadeia));
        Console.WriteLine("Pilha: " + configuracao.ObterConteudoPilha());
        Console.WriteLine("----------------------------------------");
    }

    private string ObterTextoCadeia(string cadeia)
    {
        if (cadeia == "")
        {
            return "ε";
        }

        return cadeia;
    }
}
