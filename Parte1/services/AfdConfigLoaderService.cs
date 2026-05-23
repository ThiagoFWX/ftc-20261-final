using System;

public class AFDConfigLoaderService
{
    public AFD afd { get; set; }
    public Estado estadoAtual { get; set; }
    public AFDConfigLoaderService(AFD afd,Estado estadoAtual)
	{
        this.afd = afd;
        this.estadoAtual = estadoAtual;
	}
    public AFD carregarAFD()
    {
        return afd;
    }
}
