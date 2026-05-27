using System;

public class AfdSimulatorService
{
    public AFD Afd { get; set; }

    public Estado EstadoAtual { get; set; }

    public List<Estado> Rastro { get; set; }

    public AfdSimulatorService(AFD afd)
    {
        Afd = afd;
        EstadoAtual = afd.EstadoInicial;
        Rastro = new List<Estado>();
    }

    public bool Simular(string cadeia)
    {
        EstadoAtual = Afd.EstadoInicial;

        Rastro.Clear();

        RegistrarRastro(EstadoAtual);

        foreach (char simbolo in cadeia)
        {
            if (!Afd.Alfabeto.Contains(simbolo))
            {
                Console.WriteLine(
                    $"Símbolo inválido encontrado: {simbolo}");

                return false;
            }

            Transicao transicao =
                Afd.BuscarTransicao(
                    EstadoAtual,
                    simbolo);

            if (transicao == null)
            {
                return false;
            }

            EstadoAtual =
                transicao.EstadoDestino;

            RegistrarRastro(EstadoAtual);
        }

        return EstadoAtual.EhFinal;
    }

    public void RegistrarRastro(Estado estado)
    {
        Rastro.Add(estado);
    }
}
