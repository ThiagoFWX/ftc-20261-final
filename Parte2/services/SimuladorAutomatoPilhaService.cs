namespace Parte2.Models;

using System;
using System.Collections.Generic;
using System.Linq;

public class SimuladorAutomatoPilhaService
{
    private int limitePassos;

    public SimuladorAutomatoPilhaService(int limitePassos)
    {
        this.limitePassos = limitePassos;
    }

    public bool Simular(AutomatoPilha automato, string cadeiaEntrada)
    {
        Console.WriteLine("\nAutômato: " + automato.nome);
        Console.WriteLine("Cadeia: " + (cadeiaEntrada == "" ? "ε" : cadeiaEntrada));
        Console.WriteLine();

        if (!CadeiaSimbolosValidos(automato, cadeiaEntrada))
        {
            Console.WriteLine("REJEITA");
            return false;
        }

        Queue<ConfiguracaoInstantanea> filaConfiguracoes = new Queue<ConfiguracaoInstantanea>();
        HashSet<string> configuracoesVisitadas = new HashSet<string>();
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

            if (configuracoesVisitadas.Contains(idConfiguracao))
            {
                continue;
            }

            configuracoesVisitadas.Add(idConfiguracao);

            ExibirConfigAtual(configAtual, cadeiaEntrada, qntPassosExecutados);

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

    private ConfiguracaoInstantanea GerarNovaConfiguracao(
        ConfiguracaoInstantanea configAtual,
        TransicaoPilha transicao)
    {
        Stack<char> novaPilha = CopiarPilha(configAtual.pilha);

        novaPilha.Pop();

        for (int i = transicao.acaoPilha.Length - 1; i >= 0; i--)
        {
            novaPilha.Push(transicao.acaoPilha[i]);
        }

        int novaPosicaoEntrada = configAtual.posicaoEntrada;

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

    private bool LeuCadeias(
        ConfiguracaoInstantanea configAtual,
        string cadeiaEntrada)
    {
        return configAtual.posicaoEntrada == cadeiaEntrada.Length;
    }

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