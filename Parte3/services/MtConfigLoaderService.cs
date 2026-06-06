using Parte3.models;
using System.Text.Json;

namespace Parte3.services
{
    public class MtConfigLoaderService
    {
        public MaquinaTuring CarregarMT(string caminho)
        {
            string json = File.ReadAllText(caminho);

            MtJsonModel mtJson = JsonSerializer.Deserialize<MtJsonModel>(json);

            if (mtJson == null)
            {
                throw new Exception("Erro ao carregar MT");
            }

            // Criar estados
            List<EstadoMT> estados = new();

            foreach (string nome in mtJson.estados)
            {
                estados.Add(new EstadoMT(nome, nome == mtJson.estadoAceitacao, nome == mtJson.estadoRejeicao));
            }

            // Buscar estados especiais
            EstadoMT inicial = estados.First(x => x.Nome == mtJson.estadoInicial);

            EstadoMT aceitacao = estados.First(x => x.EhAceitacao);

            EstadoMT rejeicao = estados.First(x => x.EhRejeicao);

            // Criar transições
            List<TransicaoMT> transicoes = new();

            foreach (TransicaoMtJsonModel t in mtJson.transicoes)
            {
                EstadoMT origem = estados.First(x => x.Nome == t.origem);

                EstadoMT destino = estados.First(x => x.Nome == t.destino);

                transicoes.Add(new TransicaoMT(origem, destino, t.simbolo, t.novoSimbolo, t.direcao));
            }

            // Retornar máquina pronta
            return new MaquinaTuring(estados, mtJson.alfabetoEntrada, mtJson.alfabetoFita, transicoes, inicial, aceitacao, rejeicao);
        }
    }
}