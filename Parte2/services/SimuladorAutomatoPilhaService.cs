namespace Parte2.Models;

using System;
using System.Collections.Generic;
using System.Linq;

public class SimuladorAutomatoPilhaService
{
    // Limite para evitar loops infinitos
    private int limitePassos;

    public SimuladorAutomatoPilhaService(int limitePassos)
    {
        this.limitePassos = limitePassos;
    }

    // Executa a simulação do autômato com pilha
    public bool Simular(AutomatoPilha automato, string cadeiaEntrada)
    {
        Console.WriteLine("\nAutômato: " + automato.nome);
        Console.WriteLine("Cadeia: " + (cadeiaEntrada == "" ? "ε" : cadeiaEntrada));
        Console.WriteLine();

        // Verifica se a entrada contém apenas símbolos válidos
        if (!CadeiaSimbolosValidos(automato, cadeiaEntrada))
        {
            Console.WriteLine("REJEITA");
            return false;
        }

        Queue<ConfiguracaoInstantanea> filaConfiguracoes = new Queue<ConfiguracaoInstantanea>();
        HashSet<string> configuracoesVisitadas = new HashSet<string>();

        // Inicializa a pilha com o símbolo inicial
        Stack<char> pilhaInicial = new Stack<char>();
        pilhaInicial.Push(automato.simboloInicialPilha);

        ConfiguracaoInstantanea configuracaoInicial = new ConfiguracaoInstantanea(
           automato.estadoInicial,
           0,
           pilhaInicial
       );

        filaConfiguracoes.Enqueue(configuracaoInicial);

        int qntPassosExecutados = 0;

        while (filaConfiguracoes.Count > 0 && qntPassosExecutados < this.limitePassos)
        {
            ConfiguracaoInstantanea configAtual = filaConfiguracoes.Dequeue();

            string idConfiguracao = configAtual.ObterChaveVisitada();

            // Evita processar configurações repetidas
            if (configuracoesVisitadas.Contains(idConfiguracao))
            {
                continue;
            }

            configuracoesVisitadas.Add(idConfiguracao);

            ExibirConfigAtual(configAtual, cadeiaEntrada, qntPassosExecutados);

            // Aceita quando toda a entrada foi lida e a pilha está vazia
            if (LeuCadeias(configAtual, cadeiaEntrada) && configAtual.pilha.Count == 0)
            {
                Console.WriteLine("\nACEITA");
                return true;
            }

            if (configAtual.pilha.Count == 0)
            {
                qntPassosExecutados++;
                continue;
            }

            char topoPilha = configAtual.pilha.Peek();
            char simboloAtualEntrada = ObterSimboloAtualEntrada(configAtual, cadeiaEntrada);

            // Busca as transições possíveis
            List<TransicaoPilha> transicoesDisponiveis = automato.ObterTransicoes(
                configAtual.estado,
                simboloAtualEntrada,
                topoPilha
            );

            foreach (TransicaoPilha transicao in transicoesDisponiveis)
            {
                ConfiguracaoInstantanea novaConfiguracao = GerarNovaConfiguracao(
                    configAtual,
                    transicao
                );

                filaConfiguracoes.Enqueue(novaConfiguracao);
            }

            qntPassosExecutados++;
        }

        Console.WriteLine("\nREJEITA");

        if (qntPassosExecutados >= this.limitePassos)
        {
            Console.WriteLine("Limite de passos atingido");
        }

        return false;
    }

    // Gera a próxima configuração após aplicar uma transição
    private ConfiguracaoInstantanea GerarNovaConfiguracao(
        ConfiguracaoInstantanea configAtual,
        TransicaoPilha transicao)
    {
        Stack<char> novaPilha = CopiarPilha(configAtual.pilha);

        novaPilha.Pop();

        // Empilha os novos símbolos definidos na transição
        for (int i = transicao.acaoPilha.Length - 1; i >= 0; i--)
        {
            novaPilha.Push(transicao.acaoPilha[i]);
        }

        int novaPosicaoEntrada = configAtual.posicaoEntrada;

        // Avança a leitura se não for uma transição λ
        if (!transicao.EhMovimentoLambda())
        {
            novaPosicaoEntrada++;
        }

        return new ConfiguracaoInstantanea(
            transicao.proximoEstado,
            novaPosicaoEntrada,
            novaPilha
        );
    }

    // Avança a leitura se não for uma transição λ
    private Stack<char> CopiarPilha(Stack<char> pilhaOriginal)
    {
        Stack<char> novaPilha = new Stack<char>();
        char[] elementos = pilhaOriginal.ToArray();

        for (int i = elementos.Length - 1; i >= 0; i--)
        {
            novaPilha.Push(elementos[i]);
        }

        return novaPilha;
    }

    // Obtém o símbolo atual da entrada
    private char ObterSimboloAtualEntrada(
        ConfiguracaoInstantanea configAtual,
        string cadeiaEntrada)
    {
        if (configAtual.posicaoEntrada >= cadeiaEntrada.Length)
        {
            return '\0'; 
        }

        return cadeiaEntrada[configAtual.posicaoEntrada];
    }

    // Verifica se toda a entrada já foi consumida
    private bool LeuCadeias(
        ConfiguracaoInstantanea configAtual,
        string cadeiaEntrada)
    {
        return configAtual.posicaoEntrada == cadeiaEntrada.Length;
    }

    // Valida se a entrada pertence ao alfabeto do autômato
    private bool CadeiaSimbolosValidos(
        AutomatoPilha automato,
        string cadeiaEntrada)
    {
        foreach (char simbolo in cadeiaEntrada)
        {
            if (!automato.alfabetoEntrada.Contains(simbolo))
                return false;
        }

        return true;
    }

    // Exibe a configuração atual da simulação
    private void ExibirConfigAtual(
        ConfiguracaoInstantanea configuracao,
        string cadeiaEntrada,
        int numeroDoPasso)
    {
        Console.WriteLine("Passo: " + numeroDoPasso);
        Console.WriteLine("Estado atual: " + configuracao.estado);
        Console.WriteLine("Entrada restante: " + configuracao.ObterEntradaRestante(cadeiaEntrada));
        Console.WriteLine("Conteúdo da pilha: " + configuracao.ObterConteudoPilha());
        Console.WriteLine("----------------------------------------");
    }
}