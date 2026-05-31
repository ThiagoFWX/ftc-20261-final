public class SimuladorAutomatoPilhaService
{
    private AutomatoPilha automato;

    public SimuladorAutomatoPilhaService(AutomatoPilha automato)
    {
        this.automato = automato;
    }

    public Stack<string> Simular(string entrada)
    {
        string estadoAtual = automato.estadoInicial;

        var pilha = new Stack<string>();

        pilha.Push("Z");

        Console.WriteLine($"Estado inicial: {estadoAtual}");
        Console.WriteLine($"Entrada: {entrada}");

        for (int i = 0; i < entrada.Length; i++)
        {
            char simbolo = entrada[i];

            Console.WriteLine($"Lendo o símbolo: {simbolo}");
        }

        return pilha;
    }
}