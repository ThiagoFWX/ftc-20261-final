using Parte3.models;

namespace Parte3.services
{
    public class MtSimulatorService
    {
        public MaquinaTuring MT { get; set; }
        public EstadoMT EstadoAtual { get; set; }
        public Fita Fita { get; set; }
        public Cabecote Cabecote { get; set; }
        public int Passos { get; set; }
        public List<string> Rastro { get; set; }
        public int LimitePassos { get; set; }

        public MtSimulatorService(MaquinaTuring mt, int limite = 1000)
        {
            MT = mt;
            EstadoAtual = mt.EstadoInicial;
            Cabecote = new Cabecote();
            Passos = 0;
            Rastro = new();
            LimitePassos = limite;
        }

        // Executa a MT para uma determinada entrada
        public bool Simular(string entrada)
        {
            EstadoAtual = MT.EstadoInicial;
            Passos = 1;
            Rastro.Clear();
            Cabecote = new Cabecote();
            Fita = new Fita(entrada);

            RegistrarRastro();

            while (Passos < LimitePassos)
            {
                // Verifica se a entrada foi aceita
                if (EstadoAtual.EhAceitacao)
                {
                    return true;
                }

                // Verifica se a entrada foi rejeitada
                if (EstadoAtual.EhRejeicao)
                {
                    return false;
                }

                char simbolo = Fita.Ler(Cabecote.Posicao);

                // Procura uma transição válida
                TransicaoMT transicao = MT.BuscarTransicao(EstadoAtual, simbolo);

                if (transicao == null)
                {
                    return false;
                }

                ExecutarTransicao(transicao);

                Passos++;
                RegistrarRastro();
            }

            return false;
        }

        // Executa uma transição da MT
        private void ExecutarTransicao(TransicaoMT t)
        {
            Fita.Escrever(Cabecote.Posicao, t.NovoSimbolo);
            Cabecote.Mover(t.Direcao);
            EstadoAtual = t.EstadoDestino;
        }

        // Registra o estado atual para rastreamento
        private void RegistrarRastro()
        {
            string fitaFormatada = "";

            int menor = Fita.Celulas.Count > 0 ? Fita.Celulas.Keys.Min() : 0;

            int maior = Fita.Celulas.Count > 0 ? Fita.Celulas.Keys.Max() : 0;

            for (int i = menor; i <= maior; i++)
            {
                char simbolo = Fita.Ler(i);

                // Destaca a posição atual do cabeçote
                if (i == Cabecote.Posicao)
                {
                    fitaFormatada += $"[{simbolo}]";
                }
                else
                {
                    fitaFormatada += simbolo;
                }
            }

            Rastro.Add($"Passo {Passos} | Estado: {EstadoAtual.Nome} | Cabeçote: {Cabecote.Posicao} | Fita: {fitaFormatada}");
        }
    }
}
