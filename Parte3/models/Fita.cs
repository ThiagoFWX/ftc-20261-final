using System;
using System.Collections.Generic;
using System.Text;

namespace Parte3.models
{
    public class Fita
    {
        public Dictionary<int, string> Celulas { get; set; }
        public char Branco { get; set; }

        public Fita(string entrada, char branco = '_')
        {
            Branco = branco;
            Celulas = new Dictionary<int, string>();

            // Carrega a entrada inicial na fita
            for (int i = 0; i < entrada.Length; i++)
            {
                Celulas[i] = entrada[i].ToString();
            }
        }

        // Lê o símbolo da posição informada
        public char Ler(int posicao)
        {
            if (Celulas.ContainsKey(posicao))
            {
                return Celulas[posicao][0];
            }
            return Branco;
        }

        // Escreve um símbolo na posição informada
        public void Escrever(int posicao, char simbolo)
        {
            Celulas[posicao] = simbolo.ToString();
        }

        // Retorna o conteúdo atual da fita
        public override string ToString()
        {
            if (Celulas.Count == 0)
            {
                return Branco.ToString();
            }

            int menor = Celulas.Keys.Min();
            int maior = Celulas.Keys.Max();
            string resultado = "";

            for (int i = menor; i <= maior; i++)
            {
                resultado += Ler(i);
            }
            return resultado;
        }
    }
}
