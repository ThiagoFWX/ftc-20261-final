using Parte1.models;

AFDConfigLoaderService loader =
    new AFDConfigLoaderService();

AFD afd =
    loader.CarregarAFD(
        "config/afd.json");

FileReaderService reader =
    new FileReaderService();

List<string> entradas =
    reader.LerEntradas(
        "data/entradas.txt");

AfdSimulatorService simulator =
    new AfdSimulatorService(afd);

foreach (string cadeia in entradas)
{
    bool aceita =
        simulator.Simular(cadeia);

    Console.WriteLine(
        $"Cadeia: {cadeia}");

    Console.WriteLine(
        aceita ? "ACEITA" : "REJEITA");

    Console.WriteLine(
        "Rastro:");

    foreach (Estado estado in simulator.Rastro)
    {
        Console.Write(
            estado + " ");
    }

    Console.WriteLine();
    Console.WriteLine("----------------");
}