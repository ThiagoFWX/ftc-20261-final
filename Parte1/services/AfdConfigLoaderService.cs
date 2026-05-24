using Parte1.models;
using System;
using System.Text.Json;

public class AFDConfigLoaderService
{
    public AFD CarregarAFD(string caminhoJson)
    {
        string json = File.ReadAllText(caminhoJson);

        AfdJsonModel afdJson =
            JsonSerializer.Deserialize<AfdJsonModel>(json);

        List<Estado> estados = new List<Estado>();

        foreach (string nomeEstado in afdJson.estados)
        {
            bool ehFinal =
                afdJson.estadosFinais.Contains(nomeEstado);

            estados.Add(
                new Estado(nomeEstado, ehFinal));
        }

        Estado estadoInicial =
            estados.First(
                e => e.Nome == afdJson.estadoInicial);

        List<Estado> estadosFinais =
            estados.Where(
                e => e.EhFinal).ToList();

        List<Transicao> transicoes =
            new List<Transicao>();

        foreach (TransicaoJsonModel transicaoJson
                 in afdJson.transicoes)
        {
            Estado origem =
                estados.First(
                    e => e.Nome == transicaoJson.origem);

            Estado destino =
                estados.First(
                    e => e.Nome == transicaoJson.destino);

            transicoes.Add(
                new Transicao(
                    origem,
                    transicaoJson.simbolo,
                    destino));
        }

        return new AFD(
            estados,
            afdJson.alfabeto,
            transicoes,
            estadoInicial,
            estadosFinais);
    }
}
