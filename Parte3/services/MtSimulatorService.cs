using Parte3.models;

namespace Parte3.services
{
    public class MtSimulatorService
    {
        public MaquinaTuring MT
        {
            get;
            set;
        }

        public EstadoMT EstadoAtual
        {
            get;
            set;
        }

        public Fita Fita
        {
            get;
            set;
        }

        public Cabecote Cabecote
        {
            get;
            set;
        }

        public int Passos
        {
            get;
            set;
        }

        public List<string> Rastro
        {
            get;
            set;
        }

        public int LimitePassos
        {
            get;
            set;
        }

        public MtSimulatorService(
            MaquinaTuring mt,
            int limite = 1000)
        {
            MT =
                mt;

            EstadoAtual =
                mt.EstadoInicial;

            Cabecote =
                new Cabecote();

            Passos =
                0;

            Rastro =
                new();

            LimitePassos =
                limite;
        }
        public bool Simular(string entrada)
        {
            EstadoAtual =
                MT.EstadoInicial;

            Passos = 0;

            Rastro.Clear();

            Cabecote =
                new Cabecote();

            Fita =
                new Fita(entrada);

            while (
                Passos
                <
                LimitePassos)
            {
                RegistrarRastro();

                if (
                    EstadoAtual
                    .EhAceitacao)
                {
                    return true;
                }

                if (
                    EstadoAtual
                    .EhRejeicao)
                {
                    return false;
                }

                char simbolo =
                    Fita.Ler(
                        Cabecote
                        .Posicao);

                TransicaoMT
                    transicao =
                    MT
                    .BuscarTransicao(
                        EstadoAtual,
                        simbolo);

                if (
                    transicao
                    ==
                    null)
                {
                    return false;
                }

                ExecutarTransicao(
                    transicao);

                Passos++;
            }

            return false;
        }
        private void
        ExecutarTransicao(TransicaoMT t)
        {
            Fita.Escrever(
                Cabecote.Posicao,
                t.NovoSimbolo);

            Cabecote.Mover(
                t.Direcao);

            EstadoAtual =
                t.EstadoDestino;
        }
        private void
        RegistrarRastro()
        {
            Rastro.Add(

        $"Passo {Passos}"

        +

        $" | Estado: {EstadoAtual}"

        +

        $" | Cabeçote: {Cabecote}"

        +

        $" | Fita: {Fita}"

         );
        }
    }
}
