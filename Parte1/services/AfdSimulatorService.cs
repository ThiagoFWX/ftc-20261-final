using System;

public class AfdSimulatorService
{
    public AFD Afd { get; set; }

    public Estado EstadoAtual { get; set; }

    public List<string> Rastro { get; set; }

    public AfdSimulatorService(AFD afd)
    {
        Afd = afd;

        EstadoAtual = afd.EstadoInicial;

        Rastro = new List<string>();
    }

    public bool Simular(string cadeia)
    {
        EstadoAtual = Afd.EstadoInicial;

        Rastro.Clear();

        foreach (char simbolo in cadeia)
        {
            // Validação do alfabeto
            if (!Afd.Alfabeto.Contains(simbolo))
            {
                Console.WriteLine(
                    $"Símbolo inválido encontrado: {simbolo}");

                return false;
            }

            // Busca transição
            Transicao transicao =
                Afd.BuscarTransicao(
                    EstadoAtual,
                    simbolo);

            // Se não existir transição
            if (transicao == null)
            {
                return false;
            }

            // Registrar rastreamento
            RegistrarRastro(
                transicao.EstadoOrigem,
                simbolo,
                transicao.EstadoDestino);

            // Atualizar estado atual
            EstadoAtual =
                transicao.EstadoDestino;
        }

        // Verifica se terminou em estado final
        return EstadoAtual.EhFinal;
    }

    public void RegistrarRastro(
        Estado origem,
        char simbolo,
        Estado destino)
    {
        Rastro.Add(
            $"{origem} --{simbolo}--> {destino}");
    }
}
