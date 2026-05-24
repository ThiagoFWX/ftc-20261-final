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
        // Futuramente:
        // 1. Percorrer símbolos
        // 2. Buscar transições
        // 3. Atualizar estado
        // 4. Registrar rastro
        // 5. Retornar aceita/rejeita

        return false;
    }

    public void RegistrarRastro(Estado estado)
    {
        Rastro.Add(estado);
    }
}
