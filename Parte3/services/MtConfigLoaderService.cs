using Parte3.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Parte3.services
{
    public class MtConfigLoaderService
    {
        public MaquinaTuring
            CarregarMT(
            string caminho)
        {
            string json =
                File.ReadAllText(
                    caminho);

            MtJsonModel mtJson =
                JsonSerializer
                .Deserialize<
                MtJsonModel>(
                json);

            if (
                mtJson == null)
            {
                throw new Exception(
                    "Erro ao carregar MT");
            }

            List<EstadoMT>
                estados =
                new();

            foreach (
                string nome
                in mtJson.estados)
            {
                estados.Add(
                    new EstadoMT(
                        nome,

                        nome ==
                        mtJson
                        .estadoAceitacao,

                        nome ==
                        mtJson
                        .estadoRejeicao
                    )
                );
            }

            EstadoMT inicial =
                estados
                .First(
                    x =>
                    x.Nome
                    ==
                    mtJson
                    .estadoInicial);

            EstadoMT aceitacao =
                estados
                .First(
                    x =>
                    x.EhAceitacao);

            EstadoMT rejeicao =
                estados
                .First(
                    x =>
                    x.EhRejeicao);

            return
                new MaquinaTuring(
                    estados,

                    mtJson
                    .alfabetoEntrada,

                    mtJson
                    .alfabetoFita,

                    new List<
                    TransicaoMT>(),

                    inicial,

                    aceitacao,

                    rejeicao
                );
        }
    }
}
